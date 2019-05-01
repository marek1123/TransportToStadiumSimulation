using System.Windows.Forms;
using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace continualAssistants
{
	//meta! id="29"
	public class PassengerArrivalProcess : Process
	{
		public PassengerArrivalProcess(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
        {
            MyAgent.PassengerArrivalProcess = this;

        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="ExternalEnvironmentAgent", id="30", type="Start"
		public void ProcessStart(MessageForm message)
        {                                  
            for (int busStopId = 0; busStopId < MyAgent.startTimes.Count; busStopId++)
            {
                MyMessage myMessage = new MyMessage(MySim)
                {
                    Code = Mc.PassengerArrived,                    
                    BusStopId = busStopId
                };

                Hold(MyAgent.startTimes[busStopId] - MySim.CurrentTime + MyAgent.generators[busStopId].Sample(), myMessage);
            }
		}

        private void ProcessPassengerArrived(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            int busStopId = myMessage.BusStopId;

            if (MySim.CurrentTime < MyAgent.endTimes[busStopId])
            {
                // passenger arrival process on bus stop with id busStopId ends
                return;
            }

            myMessage.Addressee = MyAgent;
            myMessage.Passenger = new Passenger();
            MyAgent.counts[busStopId]++;
            Notice(myMessage);

            PlanNext(myMessage.CreateCopy());
        }
        
        private void PlanNext(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            int busStopId = myMessage.BusStopId;            

            if (MyAgent.counts[busStopId] < MyAgent.maxCounts[busStopId])
            {
                double duration = MyAgent.generators[busStopId].Sample();
                Hold(duration, myMessage);
            }            
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
                case Mc.PassengerArrived:
                    ProcessPassengerArrived(message);                    
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
		public new ExternalEnvironmentAgent MyAgent
		{
			get
			{
				return (ExternalEnvironmentAgent)base.MyAgent;
			}
		}
	}
}
