namespace TransportToStadiumSimulation.dataObjects
{
    public interface IBusStopData
    {
        string Name { get; }
        int PassengersCount { get; }
        int MaxPassengersCount { get; }
    }
}
