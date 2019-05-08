using System.Collections.Generic;
using simulation;
using TransportToStadiumSimulation.dataObjects;

namespace TransportToStadiumSimulation.entities
{
    public class BusStop: IBusStopData
    {
        #region IBusStopData        
        public string Name { get; }
        public int PassengersCount => passengerQueue.Count;
        public int MaxPassengersCount { get; }
        #endregion        

        public int Id { get; }
        public bool IsEmpty => passengerQueue.Count == 0;
        private readonly Queue<Passenger> passengerQueue;
        private readonly MySimulation mySimulation;

        public BusStop(MySimulation mySimulation, int id, string name, int maxPassengersCount)
        {
            this.mySimulation = mySimulation;
            Name = name;
            MaxPassengersCount = maxPassengersCount;
            Id = id;
            passengerQueue = new Queue<Passenger>();
        }

        public void EnqueuePassenger(Passenger passenger)
        {
            passengerQueue.Enqueue(passenger);
            mySimulation.BusStopsDataChanged = true;
        }

        public Passenger DequeuePassenger()
        {
            Passenger passenger = passengerQueue.Dequeue();
            mySimulation.BusStopsDataChanged = true;
            return passenger;            
        }      
    }
}
