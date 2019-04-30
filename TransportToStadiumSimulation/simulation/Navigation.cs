namespace TransportToStadiumSimulation.simulation
{
    public class Navigation
    {
        public BusStopNavigationNode CurrentBusStopNavigationNode { get; private set; }

        public Navigation(BusStopNavigationNode startBusStop)
        {
            CurrentBusStopNavigationNode = startBusStop;
        }

        public BusStopNavigationNode Next => CurrentBusStopNavigationNode.Next;

        public double TimeToNext => CurrentBusStopNavigationNode.TimeToNext;

        public void MoveToNext()
        {
            CurrentBusStopNavigationNode = CurrentBusStopNavigationNode.Next;
        }
    }
}
