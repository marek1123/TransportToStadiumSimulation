namespace TransportToStadiumSimulation.simulation.configuration
{
    public class BusStopsMap
    {
        public BusStopNavigationNode[] StartsOfTheLines { get; private set; }        

        public void CreateBusStopsMap(LinesConfiguration linesConfiguration)
        {
            StartsOfTheLines = new BusStopNavigationNode[3];

            int endBusStopId = linesConfiguration.GetIdByName("st");            

            StartsOfTheLines[0] = CreateLineMap(linesConfiguration, linesConfiguration.LineANames, linesConfiguration.LineATimes, new BusStopNavigationNode(endBusStopId, 1500, "st"));
            StartsOfTheLines[1] = CreateLineMap(linesConfiguration, linesConfiguration.LineBNames, linesConfiguration.LineBTimes, new BusStopNavigationNode(endBusStopId, 600, "st"));
            StartsOfTheLines[2] = CreateLineMap(linesConfiguration, linesConfiguration.LineCNames, linesConfiguration.LineCTimes, new BusStopNavigationNode(endBusStopId, 1800, "st"));
        }

        private BusStopNavigationNode CreateLineMap(LinesConfiguration configuration, string[] names, double[] times, BusStopNavigationNode endBusStop)
        {
            string name = names[0];
            double timeToNext = times[0];             

            var initNode = new BusStopNavigationNode(configuration.GetIdByName(name), timeToNext, name);
            var node = initNode;

            for (int i = 1; i < names.Length; i++)
            {
                name = names[i];
                timeToNext = times[i];                

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
