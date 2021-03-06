using System;
using System.Collections.Generic;
using System.Linq;
using OSPABA;
using agents;
using OSPRNG;
using OSPStat;
using TransportToStadiumSimulation.dataObjects;
using TransportToStadiumSimulation.simulation.configuration;

namespace simulation
{
	public class MySimulation : Simulation
    {

        #region output properties
        public List<IVehicleData> Vehicles => VehiclesAgent.AllVehicles;
        public List<IVehicleData> Microbuses => VehiclesAgent.AllMicrobuses;
        public List<IBusStopData> BusStops => BusStopsAgent.BusStops.Cast<IBusStopData>().ToList();

        public bool VehiclesDataChanged { get; set; } = true;
        public bool BusStopsDataChanged { get; set; } = true;

        #endregion

        #region input properties

        public bool WaitingOnBusStop { get; set; } = false;

        public List<int>[] LineVehicles { get; }
        public List<double>[] LineBusesStartTimes { get; }

        public int[] LineMicrobuses { get; }
        public List<double>[] LineMicrobusesStartTimes { get; }

        public double StartTime { get; }
        public double HockeyMatchTime { get; }
        public double EndTime { get; }
        #endregion        

        #region configuration properties
        public LinesConfiguration LinesConfiguration { get; }
        #endregion

        #region statistics

        public Stat AveragePassengerWaitingTimeRep => BusStopsAgent.WaitingTimeRepStat;
        public Stat AveragePassengerWaitingTimeSim { get; }

        public Stat ArrivedAfterStartRatioRep => StadiumAgent.ArrivedAfterStartRatioRep;
        public Stat ArrivedAfterStartRatioSim { get; }

        public Stat AverageVehicleLoadRep => StadiumAgent.AverageVehicleLoadRep;
        public Stat AverageVehicleLoadSim { get; }
        #endregion

        public MySimulation(double startTime, double hockeyMatchTime, double endTime)
		{
            StartTime = startTime;
            HockeyMatchTime = hockeyMatchTime;
            EndTime = endTime;

            // init input properties
            LineVehicles = new[] { new List<int>(), new List<int>(), new List<int>() };
            LineBusesStartTimes = new[] {new List<double>(), new List<double>(), new List<double>()};

            LineMicrobuses = new[] {0, 0, 0};
            LineMicrobusesStartTimes = new[] { new List<double>(), new List<double>(), new List<double>() };

            // init statistics
            AveragePassengerWaitingTimeSim = new Stat();
            ArrivedAfterStartRatioSim = new Stat();
            AverageVehicleLoadSim = new Stat();

            // init configuration properties
            LinesConfiguration = new LinesConfiguration();
           
            // init generators
            Random seedGenerator = new Random();
            ExponentialRNG.SetSeedGen(seedGenerator);
            TriangularRNG.SetSeedGen(seedGenerator);
            UniformContinuousRNG.SetSeedGen(seedGenerator);
            Init();            
        }        

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis
            AveragePassengerWaitingTimeSim.Clear();
            ArrivedAfterStartRatioSim.Clear();
            AverageVehicleLoadSim.Clear();
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
            AveragePassengerWaitingTimeSim.AddSample(BusStopsAgent.WaitingTimeRepStat.Mean());
            ArrivedAfterStartRatioSim.AddSample(StadiumAgent.ArrivedAfterStartRatioRep.Mean());
            AverageVehicleLoadSim.AddSample(StadiumAgent.AverageVehicleLoadRep.Mean());
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