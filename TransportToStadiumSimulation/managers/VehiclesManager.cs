using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace managers
{
	//meta! id="3"
	public class VehiclesManager : Manager
	{
		public VehiclesManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
            // Setup component for the next replication
            var simulation = (MySimulation)MySim;
            MyAgent.ClearVehicles();
            MyAgent.CreateVehicles(simulation);

            StartLineVehicles(0);
            StartLineVehicles(1);
            StartLineVehicles(2);

            if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

        private void StartLineVehicles(int line)
        {
            MyAgent.LineVehicles[line].ForEach(StartVehicle);
            MyAgent.LineMicrobuses[line].ForEach(StartVehicle);
        }

        private void StartVehicle(Vehicle vehicle)
        {
            MyMessage message = new MyMessage(MySim)
            {
                Code = Mc.HandleVehicleOnBusStop,
                AddresseeId = SimId.ModelAgent,
                Vehicle = vehicle
            };
            Request(message);
        }

		//meta! sender="ModelAgent", id="14", type="Response"
		public void ProcessHandleVehicleOnBusStop(MessageForm message)
		{            
            message.Addressee = MyAgent.NextStopArrivalScheduler;
            StartContinualAssistant(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="NextStopArrivalScheduler", id="25", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
            var myMessage = (MyMessage)message;
            Vehicle vehicle = myMessage.Vehicle;
            vehicle.MoveToNext();

            if (!vehicle.IsFull || vehicle.IsAtStadium)
            {
                myMessage.Vehicle.EnterState(VehicleState.OnTheBusStop);
                message.AddresseeId = SimId.ModelAgent;
                message.Code = Mc.HandleVehicleOnBusStop;
                Request(message);
            }
            else
            {
                message.Addressee = MyAgent.NextStopArrivalScheduler;
                StartContinualAssistant(message);
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
			case Mc.Finish:
				ProcessFinish(message);
			break;

			case Mc.HandleVehicleOnBusStop:
				ProcessHandleVehicleOnBusStop(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new VehiclesAgent MyAgent
		{
			get
			{
				return (VehiclesAgent)base.MyAgent;
			}
		}
	}
}