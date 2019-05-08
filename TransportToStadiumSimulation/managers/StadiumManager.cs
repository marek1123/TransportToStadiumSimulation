using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace managers
{
	//meta! id="5"
	public class StadiumManager : Manager
	{
		public StadiumManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="ModelAgent", id="17", type="Request"
		public void ProcessHandleVehicleOnBusStop(MessageForm message)
		{            
            var myMessage = (MyMessage) message;
            Vehicle vehicle = myMessage.Vehicle;

            if (vehicle.IsEmpty)
            {
                Response(myMessage);
                return;
            }

            while (vehicle.FreeDoorsCount > 0 && !vehicle.IsEmpty)
            {                                
                StartUnboarding((MyMessage) myMessage.CreateCopy());
            }
        }

        private void StartUnboarding(MyMessage message)
        {
            Vehicle vehicle = message.Vehicle;
            vehicle.FreeDoorsCount--;
            message.Passenger = vehicle.UnboardPassenger();
            message.Addressee = MyAgent.UnboardingFinishedScheduler;
            StartContinualAssistant(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="UnboardingFinishedScheduler", id="50", type="Finish"
		public void ProcessFinish(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            Vehicle vehicle = myMessage.Vehicle;
            vehicle.FreeDoorsCount++;

            // notify that passenger arrived to stadium
            Passenger passenger = myMessage.Passenger;
            NotifyPassengerArrivedAtStadium(passenger);

            if (!vehicle.IsEmpty)
            {
                StartUnboarding(myMessage);
            }
            else if (vehicle.FreeDoorsCount == vehicle.DoorsCount)
            {
                Response(myMessage);
            }                        
        }

        private void NotifyPassengerArrivedAtStadium(Passenger passenger)
        {
            var myMessage = new MyMessage(MySim)
            {
                Passenger = passenger,
                AddresseeId = SimId.ModelAgent,
                Code = Mc.PassengerAtStadium
            };

            Notice(myMessage);
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

			case Mc.Finish:
				ProcessFinish(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new StadiumAgent MyAgent
		{
			get
			{
				return (StadiumAgent)base.MyAgent;
			}
		}
	}
}