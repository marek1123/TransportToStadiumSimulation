using OSPABA;
using simulation;
using agents;
using continualAssistants;
using instantAssistants;
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

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
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
