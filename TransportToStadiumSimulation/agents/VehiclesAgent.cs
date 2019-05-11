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
        private readonly int[] vehiclesCapacity = { 186, 107 };
        private readonly int[] doorsCounts = { 4, 3 };

        public List<List<Vehicle>> LineVehicles { get; }
        public List<List<Vehicle>> LineMicrobuses { get; }
        public List<IVehicleData> AllVehicles => LineVehicles[0].Concat(LineVehicles[1].Concat(LineVehicles[2].Cast<IVehicleData>())).ToList();
        public List<IVehicleData> AllMicrobuses => LineMicrobuses[0].Concat(LineMicrobuses[1].Concat(LineMicrobuses[2].Cast<IVehicleData>())).ToList();

        public NextStopArrivalScheduler NextStopArrivalScheduler { get; set; }
        public VehicleStartScheduler VehicleStartScheduler { get; set; }
        public VehiclesManager VehicleManager { get; set; }
        
        public VehiclesAgent(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();            

            LineVehicles = new List<List<Vehicle>>()
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

        public void CreateVehicles(MySimulation simulation)
        {
            int id = 1;

            id = CreateLineVehicles(simulation, id, 0, VehicleType.PublicCarrierVehicle);
            id = CreateLineVehicles(simulation, id, 1, VehicleType.PublicCarrierVehicle);
            id = CreateLineVehicles(simulation, id, 2, VehicleType.PublicCarrierVehicle);

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

        private int CreateLineVehicles(MySimulation simulation, int id, int line, VehicleType type)
        {
            foreach (var lineVehicle in simulation.LineVehicles[line])
            {
                var vehicle = new Vehicle(simulation, id, type, doorsCounts[lineVehicle], vehiclesCapacity[lineVehicle],
                    new Navigation(busStopsMap.StartsOfTheLines[line]));
                LineVehicles[line].Add(vehicle);
                id++;
            }

            return id;
        }

        public void ClearVehicles()
        {
            LineVehicles.ForEach(vehicles => vehicles.Clear());
            LineMicrobuses.ForEach(microbuses => microbuses.Clear());
        }

        override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
            VehicleManager.ScheduleVehiclesStart();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new VehiclesManager(SimId.VehiclesManager, MySim, this);
			new VehicleStartScheduler(SimId.VehicleStartScheduler, MySim, this);
			new NextStopArrivalScheduler(SimId.NextStopArrivalScheduler, MySim, this);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
		}
		//meta! tag="end"
	}
}