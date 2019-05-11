using System.Collections.Generic;
using System.Linq;

namespace TransportToStadiumSimulation.utils
{
    public class StringParser
    {
        public static List<int> ParseCommaSeparatedIntegers(string str)
        {
            if (str == "")
            {
                return new List<int>();
            }
            return (str ?? "").Split(',').Select(int.Parse).ToList();
        }

        public static List<double> ParseCommaSeparatedDoubles(string str)
        {
            if (str == "")
            {
                return new List<double>();
            }
            return (str ?? "").Split(',').Select(double.Parse).ToList();
        }
    }
}
