using System.Linq;
using System.Windows.Forms;
using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace managers
{
	//meta! id="4"
	public class BusStopsManager : Manager
    {
        private static double boardMicrobusIfWaitedTime = 360;

        private MySimulation MySimulation => (MySimulation) MySim;

		public BusStopsManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="ModelAgent", id="16", type="Request"
		public void ProcessHandleVehicleOnBusStop(MessageForm message)
		{            
            VehicleArrived((MyMessage) message);            
        }

        private void VehicleArrived(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;
            BusStop busStop = MyAgent.BusStops[vehicle.CurrentBusStopId];
            myMessage.BusStop = busStop;

            SetWaitingState(vehicle);

            if (busStop.IsEmpty)
            {
                HandleCanBoardButBusStopEmpty(myMessage);
                return;
            }                        

            while (vehicle.FreeDoorsCount > 0 && !vehicle.IsFull && !busStop.IsEmpty)
            {
                TryStartBoarding((MyMessage)myMessage.CreateCopy());                
            }

            if (!vehicle.IsFull && vehicle.FreeDoorsCount > 0)
            {
                MyAgent.FreeBusStopsVehicles[busStop.Id].Add(vehicle.Id, myMessage);
            }
        }

        private void SetWaitingState(Vehicle vehicle)
        {
            if (MySimulation.WaitingOnBusStop && vehicle.Type == VehicleType.PublicCarrierVehicle)
            {
                vehicle.WaitingState = VehicleWaitingState.DidNotWait;
            }
            else
            {
                vehicle.WaitingState = VehicleWaitingState.FinishedWaiting;
            }
        }

        private void StartWaiting(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;
            vehicle.WaitingState = VehicleWaitingState.IsWaiting;
            myMessage.Addressee = MyAgent.BusWaitingFinishedScheduler;
            StartContinualAssistant(myMessage);
        }

		//meta! sender="ModelAgent", id="13", type="Notice"
		public void ProcessPassengerArrived(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            int busStopId = myMessage.BusStopId;
            MyAgent.BusStops[busStopId].EnqueuePassenger(myMessage.Passenger);

            if (MyAgent.FreeBusStopsVehicles[busStopId].Count > 0)
            {
                // TODO not first
                MyMessage vehicleMessage = MyAgent.FreeBusStopsVehicles[busStopId].First().Value;                
                TryStartBoarding((MyMessage) vehicleMessage.CreateCopy());                
            }                        
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="BoardingFinishedScheduler", id="40", type="Finish"
		public void ProcessFinishBoardingFinishedScheduler(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            Vehicle vehicle = myMessage.Vehicle;
            BusStop busStop = myMessage.BusStop;
            vehicle.FreeDoorsCount++;

            if (vehicle.IsFull)
            {
                HandleVehicleFull(myMessage);                
                return;
            }

            // vehicle is not full and there are free doors
            if (busStop.IsEmpty)
            {
                HandleCanBoardButBusStopEmpty(myMessage);
                return;
            }

            // vehicle is not full, freeDoorsCount > 0, bus stop is not empty
            TryStartBoarding(myMessage);
        }

        /// <summary>
        /// Vehicle is not full, has minimally one free door and bus stop is not empty.
        /// </summary>
        /// <param name="message"></param>
        private void TryStartBoarding(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;
            BusStop busStop = myMessage.BusStop;

            // if private vehicle
            if (vehicle.Type == VehicleType.PrivateCarrierVehicle &&
                busStop.PeekPassenger().SumTimeInState(PassengerState.WaitingAtBusStop) < boardMicrobusIfWaitedTime)
            {
                Response(myMessage);
                return;
            }

            myMessage.Addressee = MyAgent.BoardingFinishedScheduler;
            vehicle.FreeDoorsCount--;

            // board passenger and update stat
            Passenger passenger = busStop.DequeuePassenger();
            passenger.EnterState(PassengerState.Riding);
            MyAgent.WaitingTimeRepStat.AddSample(passenger.SumTimeInState(PassengerState.WaitingAtBusStop));
            vehicle.BoardPassenger(passenger);

            StartContinualAssistant(myMessage);

            if (vehicle.IsFull || vehicle.FreeDoorsCount == 0)
            {
                MyAgent.FreeBusStopsVehicles[busStop.Id].Remove(vehicle.Id);
            }
        }

        private void HandleCanBoardButBusStopEmpty(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;
            BusStop busStop = myMessage.BusStop;

            if (vehicle.WaitingState == VehicleWaitingState.FinishedWaiting && vehicle.FreeDoorsCount == vehicle.DoorsCount)
            {                
                VehicleLeaves(myMessage);
                return;
            }

            if (vehicle.WaitingState == VehicleWaitingState.DidNotWait)
            {
                StartWaiting((MyMessage)myMessage.CreateCopy());
            }

            if (!MyAgent.FreeBusStopsVehicles[busStop.Id].ContainsKey(vehicle.Id))
            {
                MyAgent.FreeBusStopsVehicles[busStop.Id].Add(vehicle.Id, myMessage);
            }            
        }

        private void HandleVehicleFull(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;

            if (vehicle.FreeDoorsCount == vehicle.DoorsCount)
            {
                // vehicle is full and all passengers finished boarding
                VehicleLeaves(myMessage);                
            }            
        }

        private void VehicleLeaves(MyMessage myMessage)
        {
            BusStop busStop = myMessage.BusStop;
            Vehicle vehicle = myMessage.Vehicle;
            MyAgent.FreeBusStopsVehicles[busStop.Id].Remove(vehicle.Id);
            myMessage.Code = Mc.HandleVehicleOnBusStop;
            Response(myMessage);
        }

		//meta! sender="BusWaitingFinishedScheduler", id="52", type="Finish"
		public void ProcessFinishBusWaitingFinishedScheduler(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            Vehicle vehicle = myMessage.Vehicle;
            vehicle.WaitingState = VehicleWaitingState.FinishedWaiting;

            if (vehicle.FreeDoorsCount == vehicle.DoorsCount)
            {
                VehicleLeaves(myMessage);
            }
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.HandleVehicleOnBusStop:
				ProcessHandleVehicleOnBusStop(message);
			break;

			case Mc.PassengerArrived:
				ProcessPassengerArrived(message);
			break;

			case Mc.Finish:
				switch (message.Sender.Id)
				{
				case SimId.BoardingFinishedScheduler:
					ProcessFinishBoardingFinishedScheduler(message);
				break;

				case SimId.BusWaitingFinishedScheduler:
					ProcessFinishBusWaitingFinishedScheduler(message);
				break;
				}
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new BusStopsAgent MyAgent
		{
			get
			{
				return (BusStopsAgent)base.MyAgent;
			}
		}
	}
}