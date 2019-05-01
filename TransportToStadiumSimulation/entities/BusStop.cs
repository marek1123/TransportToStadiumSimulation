using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportToStadiumSimulation.dataObjects;

namespace TransportToStadiumSimulation.entities
{
    public class BusStop: IBusStopData
    {
        public int Id { get; }
        public string Name { get; }
        public int MaxPassengersCount { get; }

        public BusStop(int id, string name, int maxPassengersCount)
        {
            Name = name;
            MaxPassengersCount = maxPassengersCount;
            Id = id;
        }        
    }
}
