using OSPABA;
using simulation;
using agents;
using OSPRNG;

namespace continualAssistants
{
	//meta! id="39"
	public class BoardingFinishedScheduler : Scheduler
    {
        private TriangularRNG boardingTimeGenerator;

		public BoardingFinishedScheduler(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
        {
            MyAgent.BoardingFinishedScheduler = this;
            MyAgent.AddOwnMessage(Mc.PassengerBoarded);
            boardingTimeGenerator = new TriangularRNG(0.6, 1.2, 4.2);
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="BusStopsAgent", id="40", type="Start"
		public void ProcessStart(MessageForm message)
        {
            message.Code = Mc.PassengerBoarded;
            Hold(boardingTimeGenerator.Sample(), message);
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
                case Mc.PassengerBoarded:
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
		public new BusStopsAgent MyAgent
		{
			get
			{
				return (BusStopsAgent)base.MyAgent;
			}
		}
	}
}