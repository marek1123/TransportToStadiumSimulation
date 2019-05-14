using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSPABA;
using simulation;
using TransportToStadiumSimulation.utils;
using Action = System.Action;

namespace TransportToStadiumSimulation.gui
{
    public partial class FindConfigurationForm : Form
    {
        private double startTime;
        private double hockeyMatchTime;
        private double endTime;
        private MySimulation simulation;

        private int[] linePassengersCount = {2274, 1418, 1671};        

        private int[] minLineBudgets = {6822000, 4254000, 5013000};        
        private int budgetIncrement = 320000;

        private int[] currentLineBudgets = {0, 0, 0};        

        private int configsWithCurrentBudgetCount;
        private int configsWithCurrentBudgetMaxCount = 100;

        private Random chooseBusTypeRand;
        private Random chooseInterTimeRand;
        private Random chooseStartTimeRand;

        private int testedConfigurationsCount;
        private int configurationsToTestCount = 1000;
        private int validConfigurationsCount;
        private double minAverageWaitingTime;
        private double minArrivedAfterStartRatio;
        private int minCost;
        private bool validConfigFound;

        private bool processStopped;
        private SimulationConfiguration bestConfiguration;

        private int[] busesCosts = {545000, 320000};
        private double[] startTimes = { 0, 300, 600, 1200, 1800};
        private double[] interTimes = {0, 120, 240, 480, 960};
        private double[] startOfPassengersArrival = {6780, 6420, 6780};

        public FindConfigurationForm()
        {
            InitializeComponent();
            Init();
            simulation = new MySimulation(0, hockeyMatchTime - startTime, endTime - startTime);
            Random seedGenerator = new Random();
            chooseBusTypeRand = new Random(seedGenerator.Next());
            chooseInterTimeRand = new Random(seedGenerator.Next());
            chooseStartTimeRand = new Random(seedGenerator.Next());

            simulation.OnReplicationDidFinish(simulation =>
            {
                DoOnGuiThread(labelCurrentRep, () =>
                    {
                        labelCurrentRep.Text = simulation.CurrentReplication.ToString();
                    });
            });
        }

        private void Init()
        {
            startTime = TimeFormatter.HoursMinutesSecondsToDouble(17, 0, 0);
            hockeyMatchTime = startTime + TimeFormatter.HoursMinutesSecondsToDouble(3, 0, 0);
            endTime = hockeyMatchTime + TimeFormatter.HoursMinutesSecondsToDouble(1, 0, 0);
        }

        /// <summary>
        /// Is average waiting time is less than 10 min and average ratio of passengers who arrived at stadium after start of the match is less than 7 %.
        /// </summary>
        /// <param name="mySimAfterSimulation"></param>
        /// <returns></returns>
        private bool IsSimulationResultValid(MySimulation mySimAfterSimulation)
        {
            return mySimAfterSimulation.ArrivedAfterStartRatioSim.Mean() < 0.07
                   && mySimAfterSimulation.AveragePassengerWaitingTimeSim.Mean() < 600;
        }

        private void buttStart_Click(object sender, EventArgs e)
        {
            processStopped = false;
            bestConfiguration = null;
            testedConfigurationsCount = 0;
            validConfigurationsCount = 0;
            minArrivedAfterStartRatio = 1;
            minAverageWaitingTime = double.MaxValue;
            validConfigFound = false;
            minCost = int.MaxValue;
            minLineBudgets.CopyTo(currentLineBudgets, 0);            
            configsWithCurrentBudgetCount = 0;

            Thread thread = new Thread(() =>
            {
                simulation.SetMaxSimSpeed();
                for (int configurationIdx = 0; configurationIdx < configurationsToTestCount; configurationIdx++)
                {                    
                    // generate configuration
                    SimulationConfiguration config = GenerateConfiguration();

                    // test configuration
                    SetConfiguration(simulation, config);

                    simulation.Simulate((int) numReplicationsCount.Value, endTime - startTime);

                    if (processStopped)
                    {
                        return;
                    }

                    testedConfigurationsCount++;
                    DoOnGuiThread(labelTestedConfigCount, () =>
                        {
                            labelTestedConfigCount.Text = testedConfigurationsCount.ToString();
                        });                                        

                    // check if better than best
                    bool isSimulationResultValid = IsSimulationResultValid(simulation);
                    bool hasBetterStats =
                        hasBetterStatsThan(simulation, minAverageWaitingTime, minArrivedAfterStartRatio);
                    int currentCost = config.Cost();                    

                    bool isBetter = false;
                    if (bestConfiguration == null)
                    {
                        isBetter = true;
                    }
                    else if (!validConfigFound)
                    {                        
                        if (isSimulationResultValid || hasBetterStats)
                        {
                            isBetter = true;
                        }
                    }
                    else if (isSimulationResultValid)
                    {
                        if (currentCost < minCost || 
                            (currentCost == minCost && hasBetterStats))
                        {
                            isBetter = true;
                        }
                    }

                    if (isSimulationResultValid)
                    {
                        validConfigFound = true;
                        validConfigurationsCount++;
                        DoOnGuiThread(labelValidConfigCount, () =>
                        {
                            labelValidConfigCount.Text = validConfigurationsCount.ToString();
                        });
                    }

                    if (isBetter)
                    {
                        bestConfiguration = config;
                        PrintConfiguration(labelBestConfiguration, bestConfiguration);
                        minArrivedAfterStartRatio = simulation.ArrivedAfterStartRatioSim.Mean();
                        minAverageWaitingTime = simulation.AveragePassengerWaitingTimeSim.Mean();
                        minCost = currentCost;
                        DoOnGuiThread(labelMinCost, () =>
                        {
                            labelMinCost.Text = minCost.ToString();
                            labelMinAverageWaitingTime.Text = StatFormatter.FormatStatistic(
                                simulation.AveragePassengerWaitingTimeSim.Mean(),
                                simulation.AveragePassengerWaitingTimeSim.ConfidenceInterval90);
                            labelMinArrivedAfterStartRatio.Text = StatFormatter.FormatStatistic(
                                simulation.ArrivedAfterStartRatioSim.Mean(),
                                simulation.ArrivedAfterStartRatioSim.ConfidenceInterval90);
                        });
                    }                    
                }                
            });
            thread.Start();
        }

        private bool hasBetterStatsThan(MySimulation mySimAfterSimulation, double bestAverageWaitingTime, double bestArrivedAfterStartRatio)
        {
            double arrivedAfterStartRatio = mySimAfterSimulation.ArrivedAfterStartRatioSim.Mean();
            double averageWaitingTime = mySimAfterSimulation.AveragePassengerWaitingTimeSim.Mean();

            return arrivedAfterStartRatio < bestArrivedAfterStartRatio && averageWaitingTime < bestAverageWaitingTime;
        }

        private void buttStop_Click(object sender, EventArgs e)
        {
            processStopped = true;
            simulation.StopSimulation();
        }

        private void SetConfiguration(MySimulation simulation, SimulationConfiguration config)
        {
            SetConfiguration(simulation.LineVehicles, config.LinesVehicles);
            SetConfiguration(simulation.LineBusesStartTimes, config.LineBusesStartTimes);
        }

        private void SetConfiguration<T>(List<T>[] simConfig, List<T>[] config)
        {
            for (int lineIdx = 0; lineIdx < config.Length; lineIdx++)
            {
                for (int vehicleIdx = 0; vehicleIdx < config[lineIdx].Count; vehicleIdx++)
                {
                    simConfig[lineIdx].Add(config[lineIdx][vehicleIdx]);
                }
            }
        }

        private SimulationConfiguration GenerateConfiguration()
        {
            if (configsWithCurrentBudgetCount >= configsWithCurrentBudgetMaxCount)
            {
                configsWithCurrentBudgetCount = 0;
                for (int i = 0; i < currentLineBudgets.Length; i++)
                {
                    currentLineBudgets[i] += budgetIncrement;
                }                
            }

            configsWithCurrentBudgetCount++;

            SimulationConfiguration config = new SimulationConfiguration();            
            
            GenerateLineConfig(config, 0);
            GenerateLineConfig(config, 1);
            GenerateLineConfig(config, 2);

            return config;
        }

        private void GenerateLineConfig(SimulationConfiguration config, int line)
        {
            int lineBudget = 0;
            while (lineBudget < currentLineBudgets[line])
            {
                int busType = GenerateBusType();
                lineBudget += busesCosts[busType];

                if (lineBudget > currentLineBudgets[line])
                {
                    break;
                }

                config.LinesVehicles[line].Add(busType);

                if (config.LineBusesStartTimes[line].Count == 0)
                {
                    config.LineBusesStartTimes[line].Add(startOfPassengersArrival[line] + GenerateStartTime());
                }
                else
                {
                    config.LineBusesStartTimes[line].Add(GenerateInterTime());
                }
            }
        }

        private int GenerateBusType()
        {
            double rand = chooseBusTypeRand.NextDouble();

            if (rand < 0.5)
            {
                return 0;
            }

            return 1;
            
        }

        private double GenerateInterTime()
        {
            int rand = chooseInterTimeRand.Next(0, interTimes.Length);
            return interTimes[rand];
        }

        private double GenerateStartTime()
        {
            int rand = chooseStartTimeRand.Next(0, startTimes.Length);
            return startTimes[rand];
        }

        private void PrintConfiguration(Label label, SimulationConfiguration config)
        {
            DoOnGuiThread(label, () =>
            {
                label.Text = config.ToString();
            });
        }

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
    }
}
 