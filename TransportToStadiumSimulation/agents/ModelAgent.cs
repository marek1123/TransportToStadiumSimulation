using OSPABA;
using simulation;
using managers;

namespace agents
{
	//meta! id="1"
	public class ModelAgent : Agent
	{
        public ModelManager ModelManager { get; set; }

		public ModelAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
            base.PrepareReplication();
            // Setup component for the next replication 
            ModelManager.InitVehiclesAgent();
            ModelManager.InitEnvironmentAgent();
        }        

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ModelManager(SimId.ModelManager, MySim, this);
			AddOwnMessage(Mc.PassengerAtStadium);
			AddOwnMessage(Mc.HandleVehicleOnBusStop);
			AddOwnMessage(Mc.PassengerArrived);
		}
		//meta! tag="end"
	}
}