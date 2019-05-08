using OSPABA;
using TransportToStadiumSimulation.entities;

namespace simulation
{
	public class MyMessage : MessageForm
	{
        public Vehicle Vehicle { get; set; }
        public BusStop BusStop { get; set; }
        public Passenger Passenger { get; set; }
        public int BusStopId { get; set; }

        public MyMessage(Simulation sim) :
			base(sim)
		{
		}

		public MyMessage(MyMessage original) :
			base(original)
		{
			// copy() is called in superclass
		}

		override public MessageForm CreateCopy()
		{
			return new MyMessage(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			MyMessage original = (MyMessage)message;
            // Copy attributes
            Vehicle = original.Vehicle;
            Passenger = original.Passenger;
            BusStopId = original.BusStopId;
            BusStop = original.BusStop;
        }
	}
}