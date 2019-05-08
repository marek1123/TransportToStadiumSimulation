using System.Collections;
using System.Collections.Generic;
using simulation;
using TransportToStadiumSimulation.dataObjects;
using TransportToStadiumSimulation.simulation.configuration;
using TransportToStadiumSimulation.utils;

namespace TransportToStadiumSimulation.entities
{
    public class Vehicle: StateMachine<VehicleState>, IVehicleData
    {
        private Navigation Navigation { get; }        
        private readonly MySimulation mySimulation;
        private Stack<Passenger> passengers;

        #region IVehicleData
        public int Id { get; }
        public VehicleType Type { get; }
        public int DoorsCount { get; }
        public VehicleState State => CurrentState;
        public VehicleWaitingState WaitingState { get; set; }
        public string LastBustStop => Navigation.CurrentBusStopNavigationNode.Name;
        public string NextBusStop => Navigation.Next.Name;
        public int Capacity { get; }
        public int PassengersCount => passengers.Count;
        public string PercentageOfRideFinished => PercentsFormatter.ToPercents(PercentageFinished());
        #endregion

        public int FreeDoorsCount { get; set; }
        public int CurrentBusStopId => Navigation.CurrentBusStopNavigationNode.Id;
        public bool IsAtStadium => Navigation.CurrentBusStopNavigationNode.Name == "st";
        public double TimeToNext => Navigation.TimeToNext;
        public bool IsFull => passengers.Count >= Capacity;
        public bool IsEmpty => passengers.Count == 0;
        protected override double CurrentTime => mySimulation.CurrentTime;        

        public Vehicle(MySimulation mySimulation, int id, VehicleType type, int doorsCount, int capacity, Navigation navigation) :
            base(VehicleState.OnTheBusStop, mySimulation.CurrentTime)
        {

            this.mySimulation = mySimulation;
            this.Navigation = navigation;
            Type = type;
            DoorsCount = doorsCount;
            Capacity = capacity;
            Id = id;            
            FreeDoorsCount = doorsCount;
            passengers = new Stack<Passenger>();
        }

        public void MoveToNext()
        {
            Navigation.MoveToNext();
            mySimulation.VehiclesDataChanged = true;
        }

        public override void EnterState(VehicleState newState, double duration)
        {
            base.EnterState(newState, duration);
            mySimulation.VehiclesDataChanged = true;
        }

        public override void EnterState(VehicleState newState)
        {
            base.EnterState(newState);
            mySimulation.VehiclesDataChanged = true;
        }

        public void BoardPassenger(Passenger passenger)
        {
            mySimulation.VehiclesDataChanged = true;
            passengers.Push(passenger);
        }

        public Passenger UnboardPassenger()
        {
            mySimulation.VehiclesDataChanged = true;
            return passengers.Pop();
        }
    }
}
