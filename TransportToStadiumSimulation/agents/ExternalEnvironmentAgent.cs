using System.Collections.Generic;
using continualAssistants;
using OSPABA;
using simulation;
using managers;
using OSPRNG;

namespace agents
{
	//meta! id="6"
	public class ExternalEnvironmentAgent : Agent
    {
        public PassengerArrivalProcess PassengerArrivalProcess { get; set; }        
        public ExternalEnvironmentManager ExternalEnvironmentManager { get; set; }

        private const double passengerArrivalProcessTimeRange = 3900;
        public List<int> counts;
        public List<int> maxCounts;
        public List<double> startTimes;
        public List<double> endTimes;
        public List<ExponentialRNG> generators;

		public ExternalEnvironmentAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();            
            counts = new List<int>();
            maxCounts = new List<int>();
            startTimes = new List<double>();
            endTimes = new List<double>();
            generators = new List<ExponentialRNG>();

            var mySimulation = (MySimulation)MySim;
            double hockeyMatchTime = mySimulation.HockeyMatchTime;                       
            foreach (var busStopConfiguration in mySimulation.LinesConfiguration.BusStopConfigurationsById)
            {
                counts.Add(0);
                maxCounts.Add(busStopConfiguration.MaxPassengersCount);
                startTimes.Add(hockeyMatchTime - (busStopConfiguration.TimeToStadium + 4500));
                endTimes.Add(hockeyMatchTime - (busStopConfiguration.TimeToStadium + 600));
                generators.Add(new ExponentialRNG(passengerArrivalProcessTimeRange / busStopConfiguration.MaxPassengersCount));
            }
        }        

        private void reset()
        {
            for (int i = 0; i < counts.Count; i++)
            {
                counts[i] = 0;                                
            }            
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
            reset();

            var myMessage = new MyMessage(MySim);
            myMessage.Addressee = PassengerArrivalProcess;            
            ExternalEnvironmentManager.StartContinualAssistant(myMessage);
        }
        
		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ExternalEnvironmentManager(SimId.ExternalEnvironmentManager, MySim, this);
			new PassengerArrivalProcess(SimId.PassengerArrivalProcess, MySim, this);
			AddOwnMessage(Mc.PassengerArrived);
		}
		//meta! tag="end"
	}
}