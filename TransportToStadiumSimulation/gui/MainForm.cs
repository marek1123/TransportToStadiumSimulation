﻿using System;
using System.Drawing;
using System.Windows.Forms;
using OSPABA;
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

        public MainForm()
        {
            InitializeComponent();
            init();

            this.simulation = new MySimulation(0, hockeyMatchTime - startTime, endTime - startTime);
            
            // register simulation lifecycle handlers
            simulation.OnSimulationDidFinish(handleSimulationDidFinish);
            simulation.OnSimulationWillStart(handleSimulationWillStart);
            simulation.OnReplicationWillStart(handleReplicationWillStart);
            simulation.OnRefreshUI(handleRefreshUi);            
        }

        #region init
        private void init()
        {
            initButtons();
            initTimes();
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
            try
            {
                string lineVehiclesString = textBoxLineAVehicles.Text;
                simulation.LineVehicles[0] = StringParser.ParseCommaSeparatedIntegers(textBoxLineAVehicles.Text);
                DoOnGuiThread(labelLineAVehicles, () =>
                {
                    textBoxLineAVehicles.ForeColor = Color.Green;
                    labelLineAVehicles.Text = lineVehiclesString;
                });
            }
            catch (FormatException ex)
            {
                DoOnGuiThread(labelLineAVehicles, () =>
                {
                    textBoxLineAVehicles.ForeColor = Color.Red;
                    labelLineAVehicles.Text = "";
                });
            }                      
        }

        private void textBoxLineBVehicles_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lineVehiclesString = textBoxLineBVehicles.Text;
                simulation.LineVehicles[1] = StringParser.ParseCommaSeparatedIntegers(textBoxLineBVehicles.Text);
                DoOnGuiThread(labelLineBVehicles, () =>
                {
                    textBoxLineBVehicles.ForeColor = Color.Green;
                    labelLineBVehicles.Text = lineVehiclesString;
                });
            }
            catch (FormatException ex)
            {
                DoOnGuiThread(labelLineAVehicles, () =>
                {
                    textBoxLineBVehicles.ForeColor = Color.Red;
                    labelLineBVehicles.Text = "";
                });
            }
        }

        private void textBoxLineCVehicles_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lineVehiclesString = textBoxLineCVehicles.Text;
                simulation.LineVehicles[2] = StringParser.ParseCommaSeparatedIntegers(textBoxLineCVehicles.Text);
                DoOnGuiThread(labelLineCVehicles, () =>
                {
                    textBoxLineCVehicles.ForeColor = Color.Green;
                    labelLineCVehicles.Text = lineVehiclesString;
                });
            }
            catch (FormatException ex)
            {
                DoOnGuiThread(labelLineAVehicles, () =>
                {
                    textBoxLineCVehicles.ForeColor = Color.Red;
                    labelLineCVehicles.Text = "";
                });
            }
        }
        #endregion
    }
}
