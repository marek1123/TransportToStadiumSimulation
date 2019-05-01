using System;
using System.Collections.Generic;
using System.Linq;
using OSPABA;
using agents;
using TransportToStadiumSimulation.dataObjects;
using TransportToStadiumSimulation.simulation;
using TransportToStadiumSimulation.simulation.configuration;

namespace simulation
{
	public class MySimulation : Simulation
    {

        #region output properties
        public List<IVehicleData> Vehicles => VehiclesAgent.AllVehicles;
        public List<IBusStopData> BusStops => BusStopsAgent.BusStops.Values.Cast<IBusStopData>().ToList();
        #endregion

        #region input properties
        public List<int>[] LineVehicles { get; }
        #endregion

        #region seed generator
        private readonly Random seedGenerator = new Random();
        public int RandomSeed => seedGenerator.Next();
        #endregion

        #region configuration properties
        public LinesConfiguration LinesConfiguration { get; }
        #endregion

        public MySimulation()
		{
            // init input properties
            LineVehicles = new[] { new List<int>(), new List<int>(), new List<int>() };

            // init configuration properties
            LinesConfiguration = new LinesConfiguration();

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
