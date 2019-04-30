using managers;
using OSPABA;
using simulation;

namespace agents
{
    //meta! id="3"
    public class VehiclesAgent : Agent
    {
        public VehiclesAgent(int id, Simulation mySim, Agent parent) :
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
            new VehiclesManager(SimId.VehiclesManager, MySim, this);
            AddOwnMessage(Mc.HandleVehicleOnBusStop);
        }

        //meta! tag="end"
    }
}