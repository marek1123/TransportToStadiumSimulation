using simulation;
using TransportToStadiumSimulation.dataObjects;
using TransportToStadiumSimulation.simulation;
using TransportToStadiumSimulation.simulation.configuration;
using TransportToStadiumSimulation.utils;

namespace TransportToStadiumSimulation.entities
{
    public class Vehicle: StateMachine<VehicleState>, IVehicleData
    {
        public Navigation Navigation { get; }
        public bool IsAtStadium => Navigation.CurrentBusStopNavigationNode.Name == "st";
        private readonly MySimulation mySimulation;

        public Vehicle(MySimulation mySimulation, int id, VehicleType type, int doorsCount, int capacity, Navigation navigation): 
            base(VehicleState.OnTheBusStop, mySimulation.CurrentTime)
        {

            this.mySimulation = mySimulation;
            this.Navigation = navigation;
            Type = type;
            DoorsCount = doorsCount;
            Capacity = capacity;
            Id = id;            
            PassengersCount = 0;
        }

        public int Id { get; }
        public VehicleType Type { get; }
        public int DoorsCount { get; }
        public VehicleState State => CurrentState;
        public string LastBustStop => Navigation.CurrentBusStopNavigationNode.Name;
        public string NextBusStop => Navigation.Next.Name;
        public int Capacity { get; }
        public int PassengersCount { get; }
        public string PercentageOfRideFinished => PercentsFormatter.ToPercents(PercentageFinished());

        public void MoveToNext()
        {
            Navigation.MoveToNext();
        }

        protected override double CurrentTime => mySimulation.CurrentTime;
    }
}
