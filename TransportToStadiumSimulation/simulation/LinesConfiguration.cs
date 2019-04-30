using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportToStadiumSimulation.simulation
{
    public class LinesConfiguration
    {
        public string[] LineANames { get; }
        public double[] LineATimes { get; }
        public int[] LineAPassengerCounts { get; }

        public string[] LineBNames { get; }
        public double[] LineBTimes { get; }
        public int[] LineBPassengerCounts { get; }

        public string[] LineCNames { get; }
        public double[] LineCTimes { get; }
        public int[] LineCPassengerCounts { get; }

        public LinesConfiguration()
        {
            LineANames = new[] { "AA", "AB", "AC", "AD", "K1", "AE", "AF", "AG", "K3", "AH", "AI", "AJ", "AK", "AL" };
            LineATimes = new[] { 3.2, 2.3, 2.1, 1.2, 5.4, 2.9, 3.4, 1.8, 4.0, 1.6, 4.6, 3.4, 1.2, 0.9 };
            LineAPassengerCounts = new[] { 123, 92, 241, 123, 260, 215, 245, 137, 220, 132, 164, 124, 213, 185 };

            LineBNames = new[] { "BA", "BB", "BC", "BD", "K2", "BE", "BF", "K3", "BG", "BH", "BI", "BJ" };
            LineBTimes = new[] { 1.2, 2.3, 3.2, 4.3, 1.2, 2.7, 3, 6, 4.3, 0.5, 2.7, 1.3 };
            LineBPassengerCounts = new[] { 79, 69, 43, 127, 210, 30, 69, 220, 162, 90, 148, 171 };

            LineCNames = new[] { "CA", "CB", "K1", "K2", "CC", "CD", "CE", "CF", "CG" };
            LineCTimes = new[] { 0.6, 2.3, 4.1, 6, 2.3, 7.1, 4.8, 3.7, 7.2 };
            LineCPassengerCounts = new[] { 240, 310, 260, 210, 131, 190, 132, 128, 70 };
        }
    }
}
