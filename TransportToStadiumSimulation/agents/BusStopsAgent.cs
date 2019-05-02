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

        public BusStopsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
            BusStops = new List<BusStop>();
        }

        private void CreateBusStops()
        {
            // init line a bus stops            
            var mySimulation = (MySimulation) MySim;

            foreach (var busStopConfiguration in mySimulation.LinesConfiguration.BusStopConfigurationsById)
            {                
                BusStops.Add(new BusStop(mySimulation, busStopConfiguration.Id, busStopConfiguration.Name, busStopConfiguration.MaxPassengersCount));                                
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
			new BoardingFinishedScheduler(SimId.BoardingFinishedScheduler, MySim, this);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
			AddOwnMessage(Mc.PassengerArrived);
		}
		//meta! tag="end"
	}
}