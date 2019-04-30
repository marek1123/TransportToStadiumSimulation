using agents;
using OSPABA;

namespace managers
{
    //meta! id="6"
    public class ExternalEnvironmentManager : Manager
    {
        public ExternalEnvironmentManager(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        //meta! tag="end"
        public new ExternalEnvironmentAgent MyAgent => (ExternalEnvironmentAgent) base.MyAgent;

        public override void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null) PetriNet.Clear();
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        public void Init()
        {
        }

        public override void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                default:
                    ProcessDefault(message);
                    break;
            }
        }
    }
}