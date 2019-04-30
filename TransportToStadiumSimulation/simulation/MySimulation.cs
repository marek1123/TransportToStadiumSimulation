using agents;
using OSPABA;

namespace simulation
{
    public class MySimulation : Simulation
    {
        public MySimulation()
        {
            Init();
        }

        public ModelAgent ModelAgent { get; set; }

        public VehiclesAgent VehiclesAgent { get; set; }

        public BusStopsAgent BusStopsAgent { get; set; }

        public StadiumAgent StadiumAgent { get; set; }

        public ExternalEnvironmentAgent ExternalEnvironmentAgent { get; set; }

        protected override void PrepareSimulation()
        {
            base.PrepareSimulation();
            // Create global statistcis
        }

        protected override void PrepareReplication()
        {
            base.PrepareReplication();
            // Reset entities, queues, local statistics, etc...
        }

        protected override void ReplicationFinished()
        {
            // Collect local statistics into global, update UI, etc...
            base.ReplicationFinished();
        }

        protected override void SimulationFinished()
        {
            // Dysplay simulation results
            base.SimulationFinished();
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        private void Init()
        {
            ModelAgent = new ModelAgent(SimId.ModelAgent, this, null);
            VehiclesAgent = new VehiclesAgent(SimId.VehiclesAgent, this, ModelAgent);
            BusStopsAgent = new BusStopsAgent(SimId.BusStopsAgent, this, ModelAgent);
            StadiumAgent = new StadiumAgent(SimId.StadiumAgent, this, ModelAgent);
            ExternalEnvironmentAgent = new ExternalEnvironmentAgent(SimId.ExternalEnvironmentAgent, this, ModelAgent);
        }

        //meta! tag="end"
    }
}