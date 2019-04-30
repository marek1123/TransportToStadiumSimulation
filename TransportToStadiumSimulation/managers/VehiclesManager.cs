using agents;
using OSPABA;
using simulation;

namespace managers
{
    //meta! id="3"
    public class VehiclesManager : Manager
    {
        public VehiclesManager(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        //meta! tag="end"
        public new VehiclesAgent MyAgent => (VehiclesAgent) base.MyAgent;

        public override void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null) PetriNet.Clear();
        }

        //meta! sender="ModelAgent", id="14", type="Response"
        public void ProcessHandleVehicleOnBusStop(MessageForm message)
        {
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
                case Mc.HandleVehicleOnBusStop:
                    ProcessHandleVehicleOnBusStop(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
    }
}