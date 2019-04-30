using managers;
using OSPABA;
using simulation;

namespace agents
{
    //meta! id="4"
    public class BusStopsAgent : Agent
    {
        public BusStopsAgent(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        public override void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        private void Init()
        {
            new BusStopsManager(SimId.BusStopsManager, MySim, this);
            AddOwnMessage(Mc.HandleVehicleOnBusStop);
            AddOwnMessage(Mc.PassengerArrived);
        }

        //meta! tag="end"
    }
}