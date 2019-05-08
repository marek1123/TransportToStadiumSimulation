using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace continualAssistants
{
	//meta! id="24"
	public class NextStopArrivalScheduler : Scheduler
	{
		public NextStopArrivalScheduler(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
            MyAgent.AddOwnMessage(Mc.VehicleArrivedToBusStop);
            MyAgent.NextStopArrivalScheduler = this;
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="VehiclesAgent", id="25", type="Start"
		public void ProcessStart(MessageForm message)
		{
            var myMessage = (MyMessage)message;
            double duration = myMessage.Vehicle.TimeToNext;
            myMessage.Vehicle.EnterState(VehicleState.Riding, duration);
            message.Code = Mc.VehicleArrivedToBusStop;
            Hold(duration, message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
                case Mc.VehicleArrivedToBusStop:
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