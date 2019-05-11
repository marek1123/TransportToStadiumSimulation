using System.Collections.Generic;
using System.Linq;
using continualAssistants;
using OSPABA;
using simulation;
using managers;
using TransportToStadiumSimulation.dataObjects;
using TransportToStadiumSimulation.entities;
using TransportToStadiumSimulation.simulation.configuration;

namespace agents
{
	//meta! id="3"
	public class VehiclesAgent : Agent
    {
        private BusStopsMap busStopsMap;
        private readonly int[] busesCapacity = { 186, 107 };
        private readonly int[] busesDoorsCounts = { 4, 3 };

        public List<List<Vehicle>> LineBuses { get; }
        public List<List<Vehicle>> LineMicrobuses { get; }

        public List<IVehicleData> AllVehicles => LineBuses[0].Concat(LineBuses[1].Concat(LineBuses[2].Cast<IVehicleData>())).ToList();
        public List<IVehicleData> AllMicrobuses => LineMicrobuses[0].Concat(LineMicrobuses[1].Concat(LineMicrobuses[2].Cast<IVehicleData>())).ToList();

        public NextStopArrivalScheduler NextStopArrivalScheduler { get; set; }
        public VehicleStartScheduler VehicleStartScheduler { get; set; }
        public VehiclesManager VehicleManager { get; set; }
        
        public VehiclesAgent(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();            

            LineBuses = new List<List<Vehicle>>()
            {
                new List<Vehicle>(),
                new List<Vehicle>(),
                new List<Vehicle>()
            };

            LineMicrobuses = new List<List<Vehicle>>()
            {
                new List<Vehicle>(),
                new List<Vehicle>(),
                new List<Vehicle>()
            };

            var mySimulation = (MySimulation)mySim;
            busStopsMap = new BusStopsMap();
            busStopsMap.CreateBusStopsMap(mySimulation.LinesConfiguration);
        }

        private void CreateVehicles(MySimulation simulation)
        {
            int id = 1;

            id = CreateLineBuses(simulation, id, 0, VehicleType.PublicCarrierVehicle);
            id = CreateLineBuses(simulation, id, 1, VehicleType.PublicCarrierVehicle);
            id = CreateLineBuses(simulation, id, 2, VehicleType.PublicCarrierVehicle);

            id = CreateMicrobuses(simulation, id, VehicleType.PrivateCarrierVehicle);            
        }

        private int CreateMicrobuses(MySimulation simulation, int id, VehicleType type)
        {
            for (int line = 0; line < simulation.LineMicrobuses.Length; line++)
            {
                int microbusesCount = simulation.LineMicrobuses[line];

                for (int i = 0; i < microbusesCount; i++)
                {
                    var vehicle = new Vehicle(simulation, id, type, 1, 8, new Navigation(busStopsMap.StartsOfTheLines[line]));
                    LineMicrobuses[line].Add(vehicle);
                    id++;
                }
            }            
            return id;
        }

        private int CreateLineBuses(MySimulation simulation, int id, int line, VehicleType type)
        {
            foreach (var lineVehicle in simulation.LineVehicles[line])
            {
                var vehicle = new Vehicle(simulation, id, type, busesDoorsCounts[lineVehicle], busesCapacity[lineVehicle],
                    new Navigation(busStopsMap.StartsOfTheLines[line]));
                LineBuses[line].Add(vehicle);
                id++;
            }

            return id;
        }

        public void ClearVehicles()
        {
            LineBuses.ForEach(buses => buses.Clear());
            LineMicrobuses.ForEach(microbuses => microbuses.Clear());
        }

        override public void PrepareReplication()
		{
			base.PrepareReplication();
            // Setup component for the next replication
            var simulation = (MySimulation)MySim;
            ClearVehicles();
            CreateVehicles(simulation);
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new VehiclesManager(SimId.VehiclesManager, MySim, this);
			new VehicleStartScheduler(SimId.VehicleStartScheduler, MySim, this);
			new NextStopArrivalScheduler(SimId.NextStopArrivalScheduler, MySim, this);
			AddOwnMessage(Mc.Init);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
		}
		//meta! tag="end"
	}
}