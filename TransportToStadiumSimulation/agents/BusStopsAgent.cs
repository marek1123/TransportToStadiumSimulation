using System.Collections.Generic;
using OSPABA;
using simulation;
using managers;
using TransportToStadiumSimulation.entities;

namespace agents
{
	//meta! id="4"
	public class BusStopsAgent : Agent
	{
        public Dictionary<string, BusStop> BusStops { get; private set; }

        public BusStopsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
            BusStops = new Dictionary<string, BusStop>();
        }

        private void CreateBusStops()
        {            
            // init line a bus stops            
            var mySimulation = (MySimulation) MySim;

            CreateLineBusStops(mySimulation.LinesConfiguration.LineANames, mySimulation.LinesConfiguration.LineAPassengerCounts);
            CreateLineBusStops(mySimulation.LinesConfiguration.LineBNames, mySimulation.LinesConfiguration.LineBPassengerCounts);
            CreateLineBusStops(mySimulation.LinesConfiguration.LineCNames, mySimulation.LinesConfiguration.LineCPassengerCounts);           
        }

        private void CreateLineBusStops(string[] names, int[] counts)
        {
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                int maxPassengerCount = counts[i];

                if (BusStops.ContainsKey(name))
                {
                    continue;
                }
                BusStops.Add(name, new BusStop(name, maxPassengerCount));                
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
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
			AddOwnMessage(Mc.PassengerArrived);
		}
		//meta! tag="end"
	}
}
