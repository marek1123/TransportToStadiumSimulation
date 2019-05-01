namespace TransportToStadiumSimulation.simulation.configuration
{
    public class BusStopConfiguration
    {
        public int Id { get; }
        public string Name { get; }        
        public int MaxPassengersCount { get; }
        public double TimeToStadium { get; set; }

        public bool IsEndBusStop => Name == "st";
        public BusStopConfiguration(int id, string name, int maxPassengersCount, double timeToStadium)
        {
            Id = id;
            Name = name;
            MaxPassengersCount = maxPassengersCount;
            TimeToStadium = timeToStadium;
        }
    }
}
