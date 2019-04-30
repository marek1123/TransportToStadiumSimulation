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
        public string Name { get; }
        public int MaxPassengersCount { get; }

        public BusStop(string name, int maxPassengersCount)
        {
            Name = name;
            MaxPassengersCount = maxPassengersCount;
        }        
    }
}
