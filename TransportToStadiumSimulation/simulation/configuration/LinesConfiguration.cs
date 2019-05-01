using System.Collections.Generic;

namespace TransportToStadiumSimulation.simulation.configuration
{
    public class LinesConfiguration
    {
        public string[] LineANames { get; }
        public double[] LineATimes { get; }
        public int[] LineAPassengerCounts { get; }
        public double[] LineATimesToStadium { get; }

        public string[] LineBNames { get; }
        public double[] LineBTimes { get; }
        public int[] LineBPassengerCounts { get; }
        public double[] LineBTimesToStadium { get; }

        public string[] LineCNames { get; }
        public double[] LineCTimes { get; }
        public int[] LineCPassengerCounts { get; }
        public double[] LineCTimesToStadium { get; }

        private const int startId = 0; // has to be zero

        private const string stadiumBusStopName = "st";
        private BusStopConfiguration stadium;

        public Dictionary<string, BusStopConfiguration> BusStopsConfigurationsByName { get; }
        public List<BusStopConfiguration> BusStopConfigurationsById { get; private set; }

        public LinesConfiguration()
        {
            LineANames = new[] { "AA", "AB", "AC", "AD", "K1", "AE", "AF", "AG", "K3", "AH", "AI", "AJ", "AK", "AL" };
            LineATimes = new[] { 192.0, 138.0, 126.0, 72.0, 324.0, 174.0, 204.0, 108.0, 240.0, 96.0, 276.0, 204.0, 72.0, 54.0 };
            LineAPassengerCounts = new[] { 123, 92, 241, 123, 260, 215, 245, 137, 220, 132, 164, 124, 213, 185 };
            LineATimesToStadium = computeTimesToStadium(LineATimes);

            LineBNames = new[] { "BA", "BB", "BC", "BD", "K2", "BE", "BF", "K3", "BG", "BH", "BI", "BJ" };
            LineBTimes = new[] { 72.0, 138.0, 192.0, 258.0, 72.0, 162.0, 180.0, 360.0, 258.0, 30.0, 162.0, 78.0 };
            LineBPassengerCounts = new[] { 79, 69, 43, 127, 210, 30, 69, 220, 162, 90, 148, 171 };
            LineBTimesToStadium = computeTimesToStadium(LineBTimes);

            LineCNames = new[] { "CA", "CB", "K1", "K2", "CC", "CD", "CE", "CF", "CG" };
            LineCTimes = new[] { 36.0, 138.0, 246.0, 360.0, 138.0, 426.0, 288.0, 222.0, 432.0 };
            LineCPassengerCounts = new[] { 240, 310, 260, 210, 131, 190, 132, 128, 70 };
            LineCTimesToStadium = computeTimesToStadium(LineCTimes);

            BusStopsConfigurationsByName = new Dictionary<string, BusStopConfiguration>();
            BusStopConfigurationsById = new List<BusStopConfiguration>();
            createBusStopsConfigurations();
        }

        private double[] computeTimesToStadium(double[] timesToNextBusStop)
        {
            var timesToStadium = new double[timesToNextBusStop.Length];
            timesToStadium[timesToStadium.Length - 1] = timesToNextBusStop[timesToStadium.Length - 1];

            for (int i = timesToStadium.Length - 2; i >= 0; i--)
            {
                timesToStadium[i] = timesToStadium[i + 1] + timesToNextBusStop[i];
            }
            return timesToStadium;
        }

        public int GetIdByName(string name)
        {
            if (name == stadiumBusStopName)
            {
                return stadium.Id;
            }

            if (BusStopsConfigurationsByName.TryGetValue(name, out var busStopConfiguration))
            {
                return busStopConfiguration.Id;
            }

            throw new KeyNotFoundException();
        }

        private void createBusStopsConfigurations()
        {
            int id = startId;
            id = createLineBusStopsConfiguration(id, LineANames, LineAPassengerCounts, LineATimesToStadium);
            id = createLineBusStopsConfiguration(id, LineBNames, LineBPassengerCounts, LineBTimesToStadium);
            id = createLineBusStopsConfiguration(id, LineCNames, LineCPassengerCounts, LineCTimesToStadium);  
            stadium = new BusStopConfiguration(id, stadiumBusStopName, 0, 0);            
        }

        private int createLineBusStopsConfiguration(int id, string[] names, int[] maxPassengerCounts, double[] timesToStadium)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (BusStopsConfigurationsByName.TryGetValue(names[i], out var busStopConfiguration))
                {
                    if (busStopConfiguration.TimeToStadium > timesToStadium[i])
                    {
                        busStopConfiguration.TimeToStadium = timesToStadium[i];
                    }
                    continue;
                }

                var configuration = new BusStopConfiguration(id, names[i], maxPassengerCounts[i], timesToStadium[i]);

                BusStopConfigurationsById.Add(configuration);
                BusStopsConfigurationsByName.Add(names[i], configuration);
                id++;
            }

            return id;
        }
    }
}
