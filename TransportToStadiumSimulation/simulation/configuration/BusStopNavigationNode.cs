namespace TransportToStadiumSimulation.simulation.configuration
{
    public class BusStopNavigationNode
    {
        public int Id { get; }
        public BusStopNavigationNode Next { get; set; }
        public double TimeToNext { get; }

        public string Name { get; }        

        public BusStopNavigationNode(int id, double timeToNext, string name)
        {            
            TimeToNext = timeToNext;
            Name = name;
            Id = id;
        }
    }
}
