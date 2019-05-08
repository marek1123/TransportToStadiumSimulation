using System.Collections.Generic;
using continualAssistants;
using OSPABA;
using simulation;
using managers;
using TransportToStadiumSimulation.entities;

namespace agents
{
	//meta! id="4"
	public class BusStopsAgent : Agent
    {
        public List<BusStop> BusStops;
        public BoardingFinishedScheduler BoardingFinishedScheduler { get; set; }
        public List<Dictionary<int, MyMessage>> FreeBusStopsVehicles { get; private set; } // id of vehicle -> myMessage (contains vehicle)
        
        public BusStopsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
            BusStops = new List<BusStop>();
            FreeBusStopsVehicles = new List<Dictionary<int, MyMessage>>();
        }

        private void CreateBusStops()
        {
            // init line a bus stops            
            var mySimulation = (MySimulation) MySim;

            foreach (var busStopConfiguration in mySimulation.LinesConfiguration.BusStopConfigurationsById)
            {                
                BusStops.Add(new BusStop(mySimulation, busStopConfiguration.Id, busStopConfiguration.Name, busStopConfiguration.MaxPassengersCount));                                                
                FreeBusStopsVehicles.Add(new Dictionary<int, MyMessage>());
            }
        }        

        private void ClearBusStops()
        {
            BusStops.Clear();
        }

        override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
            ClearBusStops();
            CreateBusStops();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new BusStopsManager(SimId.BusStopsManager, MySim, this);
			new BusWaitingFinishedScheduler(SimId.BusWaitingFinishedScheduler, MySim, this);
			new BoardingFinishedScheduler(SimId.BoardingFinishedScheduler, MySim, this);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
			AddOwnMessage(Mc.PassengerArrived);
		}
		//meta! tag="end"
	}
}