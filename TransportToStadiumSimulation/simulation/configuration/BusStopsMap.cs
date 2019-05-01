using System.Collections.Generic;

namespace TransportToStadiumSimulation.simulation.configuration
{
    public class BusStopsMap
    {
        public BusStopNavigationNode[] StartsOfTheLines { get; private set; }
        private readonly double timeUnitsInMinute = 60;

        public void CreateBusStopsMap(LinesConfiguration linesConfiguration)
        {
            StartsOfTheLines = new BusStopNavigationNode[3];

            int endBusStopId = linesConfiguration.GetIdByName("st");            

            StartsOfTheLines[0] = CreateLineMap(linesConfiguration, linesConfiguration.LineANames, linesConfiguration.LineATimes, new BusStopNavigationNode(endBusStopId, 25 * timeUnitsInMinute, "st"));
            StartsOfTheLines[1] = CreateLineMap(linesConfiguration, linesConfiguration.LineBNames, linesConfiguration.LineBTimes, new BusStopNavigationNode(endBusStopId, 10 * timeUnitsInMinute, "st"));
            StartsOfTheLines[2] = CreateLineMap(linesConfiguration, linesConfiguration.LineCNames, linesConfiguration.LineCTimes, new BusStopNavigationNode(endBusStopId, 30 * timeUnitsInMinute, "st"));
        }

        private BusStopNavigationNode CreateLineMap(LinesConfiguration configuration, string[] names, double[] times, BusStopNavigationNode endBusStop)
        {
            string name = names[0];
            double timeToNext = times[0] * timeUnitsInMinute;             

            var initNode = new BusStopNavigationNode(configuration.GetIdByName(name), timeToNext, name);
            var node = initNode;

            for (int i = 1; i < names.Length; i++)
            {
                name = names[i];
                timeToNext = times[i] * timeUnitsInMinute;                

                var nextNode = new BusStopNavigationNode(configuration.GetIdByName(name), timeToNext, name);
                node.Next = nextNode;
                node = nextNode;
            }

            node.Next = endBusStop;
            endBusStop.Next = initNode;

            return initNode;
        }
    }
}
