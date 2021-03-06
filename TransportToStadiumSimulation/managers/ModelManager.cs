using OSPABA;
using simulation;
using agents;

namespace managers
{
	//meta! id="1"
	public class ModelManager : Manager
	{
		public ModelManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
            MyAgent.ModelManager = this;
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

        public void InitEnvironmentAgent()
        {
            MyMessage message = new MyMessage(MySim)
            {
                Code = Mc.Init, AddresseeId = SimId.VehiclesAgent
            };
            Notice(message);
        }

        public void InitVehiclesAgent()
        {
            MyMessage message = new MyMessage(MySim)
            {
                Code = Mc.Init, AddresseeId = SimId.ExternalEnvironmentAgent
            };
            Notice(message);
        }

        //meta! sender="BusStopsAgent", id="16", type="Response"
        public void ProcessHandleVehicleOnBusStopBusStopsAgent(MessageForm message)
		{
            Response(message);
        }

		//meta! sender="StadiumAgent", id="17", type="Response"
		public void ProcessHandleVehicleOnBusStopStadiumAgent(MessageForm message)
		{
            Response(message);
        }

		//meta! sender="VehiclesAgent", id="14", type="Request"
		public void ProcessHandleVehicleOnBusStopVehiclesAgent(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            if (myMessage.Vehicle.IsAtStadium)
            {
                message.AddresseeId = SimId.StadiumAgent;
            }
            else
            {
                message.AddresseeId = SimId.BusStopsAgent;
            }            
            Request(message);
        }

		//meta! sender="ExternalEnvironmentAgent", id="12", type="Notice"
		public void ProcessPassengerArrived(MessageForm message)
        {
            message.AddresseeId = SimId.BusStopsAgent;
            Notice(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="StadiumAgent", id="42", type="Notice"
		public void ProcessPassengerAtStadium(MessageForm message)
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
			case Mc.PassengerArrived:
				ProcessPassengerArrived(message);
			break;

			case Mc.HandleVehicleOnBusStop:
				switch (message.Sender.Id)
				{
				case SimId.StadiumAgent:
					ProcessHandleVehicleOnBusStopStadiumAgent(message);
				break;

				case SimId.VehiclesAgent:
					ProcessHandleVehicleOnBusStopVehiclesAgent(message);
				break;

				case SimId.BusStopsAgent:
					ProcessHandleVehicleOnBusStopBusStopsAgent(message);
				break;
				}
			break;

			case Mc.PassengerAtStadium:
				ProcessPassengerAtStadium(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new ModelAgent MyAgent
		{
			get
			{
				return (ModelAgent)base.MyAgent;
			}
		}
	}
}