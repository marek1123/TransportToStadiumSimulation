using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportToStadiumSimulation.simulation
{
    public class BusStopsMap
    {
        public BusStopNavigationNode[] StartsOfTheLines { get; private set; }
        private readonly double timeUnitsInMinute = 60;

        public void CreateBusStopsMap(LinesConfiguration linesConfiguration)
        {
            StartsOfTheLines = new BusStopNavigationNode[3];            
            StartsOfTheLines[0] = CreateLineMap(linesConfiguration.LineANames, linesConfiguration.LineATimes, new BusStopNavigationNode(25 * timeUnitsInMinute, "st"));
            StartsOfTheLines[1] = CreateLineMap(linesConfiguration.LineBNames, linesConfiguration.LineBTimes, new BusStopNavigationNode(10 * timeUnitsInMinute, "st"));
            StartsOfTheLines[2] = CreateLineMap(linesConfiguration.LineCNames, linesConfiguration.LineCTimes, new BusStopNavigationNode(30 * timeUnitsInMinute, "st"));
        }

        private BusStopNavigationNode CreateLineMap(string[] names, double[] times, BusStopNavigationNode endBusStop)
        {
            string name = names[0];
            double timeToNext = times[0] * timeUnitsInMinute;            

            var initNode = new BusStopNavigationNode(timeToNext, name);
            var node = initNode;

            for (int i = 1; i < names.Length; i++)
            {
                name = names[i];
                timeToNext = times[i] * timeUnitsInMinute;                

                var nextNode = new BusStopNavigationNode(timeToNext, name);
                node.Next = nextNode;
                node = nextNode;
            }

            node.Next = endBusStop;
            endBusStop.Next = initNode;

            return initNode;
        }

    }
}
