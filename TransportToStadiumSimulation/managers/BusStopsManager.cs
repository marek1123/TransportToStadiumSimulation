using OSPABA;
using simulation;
using agents;

namespace managers
{
	//meta! id="4"
	public class BusStopsManager : Manager
	{
		public BusStopsManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="ModelAgent", id="16", type="Request"
		public void ProcessHandleVehicleOnBusStop(MessageForm message)
		{
            // TODO do not return immediately, but process            
            Response(message);
        }

		//meta! sender="ModelAgent", id="13", type="Notice"
		public void ProcessPassengerArrived(MessageForm message)
        {
            var myMessage = (MyMessage) message;
            int busStopId = myMessage.BusStopId;
            MyAgent.BusStops[busStopId].PassengerQueue.Enqueue(myMessage.Passenger);
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

			case Mc.PassengerArrived:
				ProcessPassengerArrived(message);
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
