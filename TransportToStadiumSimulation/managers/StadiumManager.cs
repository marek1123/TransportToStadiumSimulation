using OSPABA;
using simulation;
using agents;

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
            // TODO do not return immediately, but process            
            Response(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
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
