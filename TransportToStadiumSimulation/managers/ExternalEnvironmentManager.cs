using OSPABA;
using agents;
using simulation;

namespace managers
{
	//meta! id="6"
	public class ExternalEnvironmentManager : Manager
	{
		public ExternalEnvironmentManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication

            var myMessage = new MyMessage(MySim);
            myMessage.Addressee = MyAgent.PassengerArrivalProcess;
            myMessage.Code = Mc.PassengerArrived;
            Notice(myMessage);           

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="PassengerArrivalProcess", id="30", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
		}

		//meta! sender="PassengerArrivalProcess", id="31", type="Notice"
		public void ProcessPassengerArrived(MessageForm message)
        {
            message.AddresseeId = SimId.BusStopsAgent;
            Notice(message);
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

			case Mc.PassengerArrived:
				ProcessPassengerArrived(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new ExternalEnvironmentAgent MyAgent
		{
			get
			{
				return (ExternalEnvironmentAgent)base.MyAgent;
			}
		}
	}
}