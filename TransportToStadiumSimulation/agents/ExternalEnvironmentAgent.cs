using managers;
using OSPABA;
using simulation;

namespace agents
{
    //meta! id="6"
    public class ExternalEnvironmentAgent : Agent
    {
        public ExternalEnvironmentAgent(int id, Simulation mySim, Agent parent) :
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
            new ExternalEnvironmentManager(SimId.ExternalEnvironmentManager, MySim, this);
        }

        //meta! tag="end"
    }
}