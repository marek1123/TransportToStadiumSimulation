using System.Collections.Generic;
using OSPABA;
using simulation;
using agents;
using TransportToStadiumSimulation.entities;

namespace managers
{
	//meta! id="3"
	public class VehiclesManager : Manager
	{
		public VehiclesManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
            MyAgent.VehicleManager = this;
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
            // Setup component for the next replication            

            if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

        private void ScheduleVehiclesStart()
        {
            var mySimulation = (MySimulation) MySim;

            // start buses
            for (int line = 0; line < MyAgent.LineBuses.Count; line++)
            {
                ScheduleLineVehiclesStart(line, MyAgent.LineBuses, mySimulation.LineBusesStartTimes);                
            }

            // start microbuses
            for (int line = 0; line < MyAgent.LineMicrobuses.Count; line++)
            {
                ScheduleLineVehiclesStart(line, MyAgent.LineMicrobuses, mySimulation.LineMicrobusesStartTimes);
            }
        }

        private void ScheduleLineVehiclesStart(int line, List<List<Vehicle>> lineVehicles, List<double>[] lineStartTimes)
        {
            if (lineVehicles[line].Count == 0)
                return;

            MySimulation mySimulation = (MySimulation) MySim;

            MyMessage myMessage = new MyMessage(MySim)
            {
                Addressee = MyAgent.VehicleStartScheduler
            };

            double startTime = mySimulation.HockeyMatchTime - lineStartTimes[line][0];

            for (int vehicleIdx = 0; vehicleIdx < lineVehicles[line].Count; vehicleIdx++)
            {
                if (vehicleIdx != 0)
                {
                    startTime += lineStartTimes[line][vehicleIdx];
                }

                var messageCopy = (MyMessage) myMessage.CreateCopy();
                messageCopy.Vehicle = lineVehicles[line][vehicleIdx];
                messageCopy.Time = startTime;
                StartContinualAssistant(messageCopy);
            }
        }                

		//meta! sender="ModelAgent", id="14", type="Response"
		public void ProcessHandleVehicleOnBusStop(MessageForm message)
		{            
            message.Addressee = MyAgent.NextStopArrivalScheduler;
            StartContinualAssistant(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="NextStopArrivalScheduler", id="25", type="Finish"
		public void ProcessFinishNextStopArrivalScheduler(MessageForm message)
		{
            var myMessage = (MyMessage)message;
            Vehicle vehicle = myMessage.Vehicle;
            vehicle.MoveToNext();

            if (!vehicle.IsFull || vehicle.IsAtStadium)
            {
                myMessage.Vehicle.EnterState(VehicleState.OnTheBusStop);
                message.AddresseeId = SimId.ModelAgent;
                message.Code = Mc.HandleVehicleOnBusStop;
                Request(message);
            }
            else
            {
                message.Addressee = MyAgent.NextStopArrivalScheduler;
                StartContinualAssistant(message);
            }
            
        }		

		//meta! sender="VehicleStartScheduler", id="61", type="Finish"
		public void ProcessFinishVehicleStartScheduler(MessageForm message)
		{
            StartVehicle(message);
		}

        private void StartVehicle(MessageForm message)
        {
            message.Code = Mc.HandleVehicleOnBusStop;
            message.AddresseeId = SimId.ModelAgent;
            Request(message);
        }

		//meta! sender="ModelAgent", id="65", type="Notice"
		public void ProcessInit(MessageForm message)
		{
            ScheduleVehiclesStart();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.HandleVehicleOnBusStop:
				ProcessHandleVehicleOnBusStop(message);
			break;

			case Mc.Init:
				ProcessInit(message);
			break;

			case Mc.Finish:
				switch (message.Sender.Id)
				{
				case SimId.VehicleStartScheduler:
					ProcessFinishVehicleStartScheduler(message);
				break;

				case SimId.NextStopArrivalScheduler:
					ProcessFinishNextStopArrivalScheduler(message);
				break;
				}
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new VehiclesAgent MyAgent
		{
			get
			{
				return (VehiclesAgent)base.MyAgent;
			}
		}
	}
}