namespace TransportToStadiumSimulation.simulation
{
    public class BusStopNavigationNode
    {
        public BusStopNavigationNode Next { get; set; }
        public double TimeToNext { get; }

        public string Name { get; }
        public int Id { get; }

        public BusStopNavigationNode(double timeToNext, string name, int id)
        {            
            TimeToNext = timeToNext;
            Name = name;
            Id = id;
        }
    }
}
