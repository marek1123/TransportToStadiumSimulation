namespace TransportToStadiumSimulation.simulation
{
    public class BusStopNavigationNode
    {
        public BusStopNavigationNode Next { get; set; }
        public double TimeToNext { get; }

        public string Name { get; }        

        public BusStopNavigationNode(double timeToNext, string name)
        {            
            TimeToNext = timeToNext;
            Name = name;            
        }
    }
}
