using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TransportToStadiumSimulation.Annotations;
using TransportToStadiumSimulation.dataObjects;

namespace TransportToStadiumSimulation.entities
{
    public class BusStop: IBusStopData
    {
        public int Id { get; }
        public string Name { get; }
        public int PassengerCount => passengerQueue.Count;       

        public int MaxPassengersCount { get; }
        private Queue<Passenger> passengerQueue;

        public BusStop(int id, string name, int maxPassengersCount)
        {
            Name = name;
            MaxPassengersCount = maxPassengersCount;
            Id = id;
            passengerQueue = new Queue<Passenger>();
        }

        public void EnqueuePassenger(Passenger passenger)
        {
            passengerQueue.Enqueue(passenger);            
        }

        public Passenger DequeuePassenger()
        {
            Passenger passenger = passengerQueue.Dequeue();            
            return passenger;
        }      
    }
}
