using TransportToStadiumSimulation.entities;

namespace TransportToStadiumSimulation.dataObjects
{
    public interface IVehicleData
    {
        int Id { get; }
        VehicleType Type { get; }
        int DoorsCount { get; }
        VehicleState State { get; }
        VehicleWaitingState WaitingState { get; }
        string LastBustStop { get; }
        string NextBusStop { get; }                        
        int Capacity { get; }
        int PassengersCount { get; }
        string PercentageOfRideFinished { get; }
    }
}
