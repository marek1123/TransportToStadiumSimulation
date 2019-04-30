using managers;
using OSPABA;
using simulation;

namespace agents
{
    //meta! id="5"
    public class StadiumAgent : Agent
    {
        public StadiumAgent(int id, Simulation mySim, Agent parent) :
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
            new StadiumManager(SimId.StadiumManager, MySim, this);
            AddOwnMessage(Mc.HandleVehicleOnBusStop);
        }

        //meta! tag="end"
    }
}