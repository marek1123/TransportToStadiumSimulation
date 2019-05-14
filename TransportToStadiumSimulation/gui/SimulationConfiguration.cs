using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TransportToStadiumSimulation.gui
{
    public class SimulationConfiguration
    {
        public List<int>[] LinesVehicles { get; }
        public List<double>[] LineBusesStartTimes { get; }

        public int[] LineMicrobuses { get; }
        public List<double>[] LineMicrobusesStartTimes { get; }

        private static int[] busesCosts = {545000, 320000};

        public SimulationConfiguration()
        {
            LinesVehicles = new[] {new List<int>(), new List<int>(), new List<int>()};
            LineBusesStartTimes = new[] {new List<double>(), new List<double>(), new List<double>()};
        }

        public int Cost()
        {
            return LinesVehicles.SelectMany(
                lineVehicles => lineVehicles.Select(vehicleTypeId => busesCosts[vehicleTypeId])
                ).Sum();
        }

        public override string ToString()
        {            
            string lineVehicles = LineConfigsToString(", ", LinesVehicles, num => num.ToString());
            string lineTimes = LineConfigsToString(", ", LineBusesStartTimes, num => num.ToString("0.#"));

            return lineVehicles + ", " + lineTimes;
        }

        private string LineConfigsToString<T>(string separator, IEnumerable<IEnumerable<T>> lineConfigurations, Func<T, string> toString)
        {
            return ToString(separator,
                lineConfigurations,
                lineConfig => ToString(" ", lineConfig, toString));
        }

        private string ToString<T>(string separator, IEnumerable<T> list, Func<T, string> toString)
        {
            return string.Join(separator, list.Select(toString));
        }                
    }
}
