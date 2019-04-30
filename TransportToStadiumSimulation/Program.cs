using System;
using System.Windows.Forms;
using simulation;
using TransportToStadiumAgentSimulation.gui;

namespace TransportToStadiumSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MySimulation simulation = new MySimulation();
            Application.Run(new MainForm(simulation));
        }
    }
}
