using continualAssistants;
using OSPABA;
using simulation;
using managers;
using OSPStat;

namespace agents
{
	//meta! id="5"
	public class StadiumAgent : Agent
	{
        public UnboardingFinishedScheduler UnboardingFinishedScheduler { get; set; }
        public Stat ArrivedAfterStartRatioRep { get; }
        public Stat AverageVehicleLoadRep { get; }

        public StadiumAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
            ArrivedAfterStartRatioRep = new Stat();
            AverageVehicleLoadRep = new Stat();            
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
            ArrivedAfterStartRatioRep.Clear();
            AverageVehicleLoadRep.Clear();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new StadiumManager(SimId.StadiumManager, MySim, this);
			new UnboardingFinishedScheduler(SimId.UnboardingFinishedScheduler, MySim, this);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
		}
		//meta! tag="end"
	}
}