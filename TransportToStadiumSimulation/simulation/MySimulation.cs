using OSPABA;
using agents;
namespace simulation
{
	public class MySimulation : Simulation
	{
		public MySimulation()
		{
			Init();
		}

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis
		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
			// Reset entities, queues, local statistics, etc...
		}

		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();
		}

		override protected void SimulationFinished()
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
		public ModelAgent ModelAgent
		{ get; set; }
		public VehiclesAgent VehiclesAgent
		{ get; set; }
		public BusStopsAgent BusStopsAgent
		{ get; set; }
		public StadiumAgent StadiumAgent
		{ get; set; }
		public ExternalEnvironmentAgent ExternalEnvironmentAgent
		{ get; set; }
		//meta! tag="end"
	}
}
