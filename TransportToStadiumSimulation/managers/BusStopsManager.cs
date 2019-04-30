using agents;
using OSPABA;
using simulation;

namespace managers
{
    //meta! id="4"
    public class BusStopsManager : Manager
    {
        public BusStopsManager(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        //meta! tag="end"
        public new BusStopsAgent MyAgent => (BusStopsAgent) base.MyAgent;

        public override void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null) PetriNet.Clear();
        }

        //meta! sender="ModelAgent", id="16", type="Request"
        public void ProcessHandleVehicleOnBusStop(MessageForm message)
        {
        }

        //meta! sender="ModelAgent", id="13", type="Notice"
        public void ProcessPassengerArrived(MessageForm message)
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

                case Mc.PassengerArrived:
                    ProcessPassengerArrived(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
    }
}