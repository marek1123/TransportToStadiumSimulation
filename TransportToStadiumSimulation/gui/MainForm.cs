using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OSPABA;
using OSPStat;
using simulation;
using TransportToStadiumSimulation.utils;
using Action = System.Action;

namespace TransportToStadiumAgentSimulation.gui
{
    public partial class MainForm : Form
    {
        private MySimulation simulation;        
        private bool paused = false;                
        private double startTime;
        private double hockeyMatchTime;
        private double endTime;
        private int microbusesCount = 13;

        public MainForm()
        {
            InitializeComponent();
            init();

            this.simulation = new MySimulation(0, hockeyMatchTime - startTime, endTime - startTime);
            
            // register simulation lifecycle handlers
            simulation.OnSimulationDidFinish(handleSimulationDidFinish);
            simulation.OnSimulationWillStart(handleSimulationWillStart);
            simulation.OnReplicationWillStart(handleReplicationWillStart);
            simulation.OnReplicationDidFinish(handleReplicationDidFinish);
            simulation.OnRefreshUI(handleRefreshUi);            
        }

        #region init
        private void init()
        {
            initButtons();
            initTimes();
            changeNumMicrobusesColorIfSumNotCorrect();
        }

        private void initButtons()
        {
            buttStart.Enabled = true;
            buttPause.Enabled = false;
            buttStop.Enabled = false;
        }

        private void initTimes()
        {
            // set times showed in GUI
            startTime = TimeFormatter.HoursMinutesSecondsToDouble(18, 0, 0);
            hockeyMatchTime = startTime + TimeFormatter.HoursMinutesSecondsToDouble(2, 0, 0);
            endTime = hockeyMatchTime + TimeFormatter.HoursMinutesSecondsToDouble(1, 0, 0);                        
        }
        #endregion

        #region simulation lifecycle handlers
        private void handleReplicationWillStart(Simulation simulation)
        {
            DoOnGuiThread(labelReplication, () =>
            {
                labelReplication.Text = simulation.CurrentReplication.ToString();
            });
        }

        private void handleReplicationDidFinish(Simulation simulation)
        {
            MySimulation mySimulation = (MySimulation) simulation;
            updateSimulationStatistics(mySimulation);
        }

        private void handleRefreshUi(Simulation simulation)
        {
            var mySimulation = (MySimulation)simulation;
            double time = simulation.CurrentTime;

            DoOnGuiThread(labelTime, () =>
            {
                labelTime.Text = TimeFormatter.HoursMinutesSecondsString(time + startTime);
            });                       

            if (mySimulation.VehiclesDataChanged)
            {
                var vehicles = mySimulation.Vehicles;
                mySimulation.VehiclesDataChanged = false;                
                DoOnGuiThread(dataGridVehicles, () =>
                {
                    dataGridVehicles.DataSource = vehicles;                    
                });

                var microbuses = mySimulation.Microbuses;
                mySimulation.VehiclesDataChanged = false;
                DoOnGuiThread(dataGridMicrobuses, () =>
                {
                    dataGridMicrobuses.DataSource = microbuses;
                });
            }

            if (mySimulation.BusStopsDataChanged)
            {
                var busStops = mySimulation.BusStops;
                mySimulation.BusStopsDataChanged = false;                
                DoOnGuiThread(dataGridBusStops, () =>
                {
                    dataGridBusStops.DataSource = busStops;                    
                });
            }
            
            updateReplicationStatistics(mySimulation);
        }

        private void handleSimulationWillStart(Simulation simulation)
        {
            var mySimulation = (MySimulation) simulation;                        
        }

        private void handleSimulationDidFinish(Simulation simulation)
        {
            paused = false;

            DoOnGuiThread(buttStart, () =>
            {
                buttStart.Enabled = true;
                buttPause.Enabled = false;
                buttStop.Enabled = false;
            });            
        }

        private void updateReplicationStatistics(MySimulation mySimulation)
        {
            updateStatistic(labelAveragePassengerWaitingTimeRep, mySimulation.AveragePassengerWaitingTimeRep);
        }

        private void updateSimulationStatistics(MySimulation mySimulation)
        {         
            updateStatistic(labelAveragePassengerWaitingTimeSim, mySimulation.AveragePassengerWaitingTimeSim);
        }        

        private void updateStatistic(Label label, Stat statistic)
        {
            DoOnGuiThread(label, () =>
            {
                if (statistic.SampleSize < 3)
                {
                    return;
                }

                double mean = statistic.Mean();
                double[] confidenceInterval = statistic.ConfidenceInterval90;
                label.Text = StatFormatter.FormatStatistic(mean, confidenceInterval);
            });
        }

        #endregion

        #region start, stop, pause buttons
        private void buttStart_Click(object sender, EventArgs e)
        {
            DoOnGuiThread(buttStart, () =>
            {
                buttStart.Enabled = false;
                buttStop.Enabled = true;
                buttPause.Enabled = true;
            });            

            simulation.SimulateAsync((int)numReplicationsCount.Value, endTime - startTime);
            ChangeSimulationSpeed();
        }

        private void buttPause_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                simulation.PauseSimulation();
                paused = true;
                buttPause.Text = "Continue";
            }
            else
            {
                simulation.ResumeSimulation();
                paused = false;
                buttPause.Text = "Pause";
            }
        }

        private void buttStop_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                simulation.ResumeSimulation();
            }
            simulation.StopSimulation();
        }
        #endregion

        #region set speed methods
        private void ChangeSimulationSpeed()
        {
            bool fastMode = checkBoxFastMode.Checked;

            if (fastMode)
            {
                simulation.SetMaxSimSpeed();
                return;
            }

            double duration = trackBarDuration.Value;
            double interval = trackBarInterval.Value;
            simulation.SetSimSpeed(interval, duration / 1000);
        }

        private void trackBarDuration_ValueChanged(object sender, EventArgs e)
        {
            ChangeSimulationSpeed();
        }

        private void trackBarInterval_ValueChanged(object sender, EventArgs e)
        {
            ChangeSimulationSpeed();
        }

        private void checkBoxFastMode_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSimulationSpeed();
        }
        #endregion

        private void DoOnGuiThread(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        #region set simulation parameters        
        // TODO check if integers falls in range 0-1
        private void textBoxLineAVehicles_TextChanged(object sender, EventArgs e)
        {
            textBoxLineVehiclesChanged(textBoxLineAVehicles, 0);
        }

        private void textBoxLineBVehicles_TextChanged(object sender, EventArgs e)
        {
            textBoxLineVehiclesChanged(textBoxLineBVehicles, 1);
        }

        private void textBoxLineCVehicles_TextChanged(object sender, EventArgs e)
        {
            textBoxLineVehiclesChanged(textBoxLineCVehicles, 2);            
        }

        private void textBoxLineVehiclesChanged(TextBox textBox, int line)
        {
            try
            {                
                simulation.LineVehicles[line] = StringParser.ParseCommaSeparatedIntegers(textBox.Text);
                DoOnGuiThread(textBox, () =>
                {
                    textBox.ForeColor = Color.Green;                    
                });
            }
            catch (FormatException ex)
            {
                DoOnGuiThread(textBox, () =>
                {
                    textBox.ForeColor = Color.Red;                    
                });
            }
        }      

        private void numLineAMicrobuses_ValueChanged(object sender, EventArgs e)
        {
            simulation.LineMicrobuses[0] = (int) numLineAMicrobuses.Value;
            changeNumMicrobusesColorIfSumNotCorrect();
        }

        private void numLineBMicrobuses_ValueChanged(object sender, EventArgs e)
        {
            simulation.LineMicrobuses[1] = (int) numLineBMicrobuses.Value;
            changeNumMicrobusesColorIfSumNotCorrect();
        }

        private void numLineCMicrobuses_ValueChanged(object sender, EventArgs e)
        {
            simulation.LineMicrobuses[2] = (int) numLineCMicrobuses.Value;
            changeNumMicrobusesColorIfSumNotCorrect();
        }

        private void startTimesLineABuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesLineABuses, startTimes =>
            {
                simulation.LineBusesStartTimes[0] = startTimes;
            });
        }

        private void startTimesBBuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesBBuses, startTimes =>
            {
                simulation.LineBusesStartTimes[1] = startTimes;
            });
        }

        private void startTimesCBuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesCBuses, startTimes =>
            {
                simulation.LineBusesStartTimes[2] = startTimes;
            });
        }

        private void startTimesAMicrobuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesAMicrobuses, startTimes =>
            {
                simulation.LineMicrobusesStartTimes[0] = startTimes;
            });
        }

        private void startTimesBMicrobuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesBMicrobuses, startTimes =>
            {
                simulation.LineMicrobusesStartTimes[1] = startTimes;
            });
        }

        private void startTimesCMicrobuses_TextChanged(object sender, EventArgs e)
        {
            startTimesChanged(startTimesCMicrobuses, startTimes =>
            {
                simulation.LineMicrobusesStartTimes[2] = startTimes;
            });
        }

        private void startTimesChanged(TextBox textBox, Action<List<double>> setStartTimes)
        {
            try
            {
                List<double> startTimes = StringParser.ParseCommaSeparatedDoubles(textBox.Text);
                setStartTimes(startTimes);
                DoOnGuiThread(textBox, () =>
                {
                    textBox.ForeColor = Color.Green;
                });
            }
            catch (FormatException ex)
            {
                DoOnGuiThread(textBox, () =>
                {
                    textBox.ForeColor = Color.Red;
                });
            }
        }
        private void changeNumMicrobusesColorIfSumNotCorrect()
        {
            int sum = (int) (numLineAMicrobuses.Value + numLineBMicrobuses.Value + numLineCMicrobuses.Value);

            if (sum != microbusesCount)
            {
                numLineAMicrobuses.ForeColor = Color.Red;
                numLineBMicrobuses.ForeColor = Color.Red;
                numLineCMicrobuses.ForeColor = Color.Red;
            }
            else
            {
                numLineAMicrobuses.ForeColor = Color.Green;
                numLineBMicrobuses.ForeColor = Color.Green;
                numLineCMicrobuses.ForeColor = Color.Green;
            }
        }

        private void checkBoxWaitingOnBusStop_CheckedChanged(object sender, EventArgs e)
        {
            simulation.WaitingOnBusStop = checkBoxWaitingOnBusStop.Checked;
        }
        #endregion        
    }
}
