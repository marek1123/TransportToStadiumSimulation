using System.Linq;
using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace managers
{
	//meta! id="4"
	public class BusStopsManager : Manager
	{
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
            StartBoarding((MyMessage) message);
            //Response(message);
        }

        private void StartBoarding(MyMessage myMessage)
        {
            Vehicle vehicle = myMessage.Vehicle;
            BusStop busStop = MyAgent.BusStops[vehicle.CurrentBusStopId];

            // TODO solve waiting scenario
            if (busStop.IsEmpty)
            {
                Response(myMessage); // vehicle leaves bus stop
                return;
            }

            myMessage.BusStop = busStop;
            myMessage.Addressee = MyAgent.BoardingFinishedScheduler;

            while (vehicle.FreeDoorsCount > 0 && !vehicle.IsFull && !busStop.IsEmpty)
            {
                vehicle.FreeDoorsCount--;
                vehicle.BoardPassenger(busStop.DequeuePassenger());
                MyMessage messageCopy = (MyMessage) myMessage.CreateCopy();
                StartContinualAssistant(messageCopy);                
            }

            if (!vehicle.IsFull && vehicle.FreeDoorsCount > 0)
            {
                MyAgent.FreeBusStopsVehicles[busStop.Id].Add(vehicle.Id, myMessage);
            }
        }

		//meta! sender="ModelAgent", id="13", type="Notice"
		public void ProcessPassengerArrived(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            int busStopId = myMessage.BusStopId;

            if (MyAgent.FreeBusStopsVehicles[busStopId].Count > 0)
            {
                // TODO not first
                MyMessage vehicleMessage = MyAgent.FreeBusStopsVehicles[busStopId].First().Value;
                Vehicle vehicle = vehicleMessage.Vehicle;
                BusStop busStop = MyAgent.BusStops[busStopId];

                vehicle.FreeDoorsCount--;
                vehicle.BoardPassenger(myMessage.Passenger);
                MyMessage messageCopy = (MyMessage)vehicleMessage.CreateCopy();
                messageCopy.Addressee = MyAgent.BoardingFinishedScheduler;
                StartContinualAssistant(messageCopy);                
                if (vehicle.IsFull || vehicle.FreeDoorsCount == 0)
                {
                    MyAgent.FreeBusStopsVehicles[busStop.Id].Remove(vehicle.Id);
                }
            }
            else
            {
                MyAgent.BusStops[busStopId].EnqueuePassenger(myMessage.Passenger);
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
                if (vehicle.FreeDoorsCount == vehicle.DoorsCount)
                {
                    // vehicle is full and all passengers finished boarding
                    Response(myMessage);
                    return;
                }

                // vehicle is full but there are still passengers boarding
                return;
            }

            // vehicle is not full and there are free doors

            // bus stop is empty
            if (busStop.IsEmpty && !MyAgent.FreeBusStopsVehicles[busStop.Id].ContainsKey(vehicle.Id))
            {
               MyAgent.FreeBusStopsVehicles[busStop.Id].Add(vehicle.Id, myMessage);
               return;
            }

            if (!busStop.IsEmpty)            
            {
                // bus stop is not empty
                myMessage.Addressee = MyAgent.BoardingFinishedScheduler;
                vehicle.FreeDoorsCount--;
                vehicle.BoardPassenger(busStop.DequeuePassenger());                
                StartContinualAssistant(message);
                if (vehicle.IsFull)
                {
                    MyAgent.FreeBusStopsVehicles[busStop.Id].Remove(vehicle.Id);
                }
            }            
        }

		//meta! sender="BusWaitingFinishedScheduler", id="52", type="Finish"
		public void ProcessFinishBusWaitingFinishedScheduler(MessageForm message)
		{
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
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

			case Mc.HandleVehicleOnBusStop:
				ProcessHandleVehicleOnBusStop(message);
			break;

			case Mc.PassengerArrived:
				ProcessPassengerArrived(message);
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