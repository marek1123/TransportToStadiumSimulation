using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	//meta! id="60"
	public class VehicleStartScheduler : Scheduler
	{
		public VehicleStartScheduler(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
        {
            MyAgent.VehicleStartScheduler = this;
            MyAgent.AddOwnMessage(Mc.VehicleStarted);
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="VehiclesAgent", id="61", type="Start"
		public void ProcessStart(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            myMessage.Code = Mc.VehicleStarted;
            double duration = myMessage.Time - MySim.CurrentTime;
            Hold(duration, myMessage);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
                case Mc.VehicleStarted:
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
		public new VehiclesAgent MyAgent
		{
			get
			{
				return (VehiclesAgent)base.MyAgent;
			}
		}
	}
}
