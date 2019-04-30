using System.Collections.Generic;
using System.Linq;

namespace TransportToStadiumSimulation.utils
{
    public class StringParser
    {
        public static List<int> ParseCommaSeparatedIntegers(string str)
        {
            return (str ?? "").Split(',').Select(int.Parse).ToList();
        }
    }
}
