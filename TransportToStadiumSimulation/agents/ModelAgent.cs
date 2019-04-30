using managers;
using OSPABA;
using simulation;

namespace agents
{
    //meta! id="1"
    public class ModelAgent : Agent
    {
        public ModelAgent(int id, Simulation mySim, Agent parent) :
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
            new ModelManager(SimId.ModelManager, MySim, this);
            AddOwnMessage(Mc.HandleVehicleOnBusStop);
            AddOwnMessage(Mc.PassengerArrived);
        }

        //meta! tag="end"
    }
}