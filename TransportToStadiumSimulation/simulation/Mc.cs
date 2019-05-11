using OSPABA;
namespace simulation
{
	public class Mc : IdList
	{
		//meta! userInfo="Generated code: do not modify", tag="begin"
		public const int Init = 1006;
		public const int PassengerAtStadium = 1004;
		public const int PassengerArrived = 1001;
		public const int HandleVehicleOnBusStop = 1003;
		//meta! tag="end"

		// 1..1000 range reserved for user
        public const int VehicleArrivedToBusStop = 1;
        public const int PassengerBoarded = 2;
        public const int PassengerUnboarded = 3;
        public const int BusWaitingFinished = 4;
        public const int VehicleStarted = 5;
    }
}