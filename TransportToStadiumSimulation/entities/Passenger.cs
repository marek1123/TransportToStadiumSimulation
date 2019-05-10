using OSPABA;
using simulation;

namespace TransportToStadiumSimulation.entities
{
    public class Passenger: StateMachine<PassengerState>
    {
        private Simulation mySimulation;

        public Passenger(Simulation mySimulation) : base(PassengerState.WaitingAtBusStop, mySimulation.CurrentTime)
        {            
            this.mySimulation = mySimulation;
        }

        protected override double CurrentTime => mySimulation.CurrentTime;
    }
}
