using OSPABA;
using simulation;
using agents;
using OSPRNG;

namespace continualAssistants
{
	//meta! id="49"
	public class UnboardingFinishedScheduler : Scheduler
	{
        private TriangularRNG unboardingTimeGenerator;

        public UnboardingFinishedScheduler(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
        {
            MyAgent.UnboardingFinishedScheduler = this;
            unboardingTimeGenerator = new TriangularRNG(0.6, 1.2, 4.2);
            MyAgent.AddOwnMessage(Mc.PassengerUnboarded);
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="StadiumAgent", id="50", type="Start"
		public void ProcessStart(MessageForm message)
        {
            message.Code = Mc.PassengerUnboarded;
            Hold(unboardingTimeGenerator.Sample(), message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
                case Mc.PassengerUnboarded:
                    AssistantFinished(message);
                    break;
			}
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Start:
				ProcessStart(message);
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