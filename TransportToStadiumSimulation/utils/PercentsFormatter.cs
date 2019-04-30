namespace TransportToStadiumSimulation.utils
{
    public class PercentsFormatter
    {
        public static string ToPercents(double value)
        {
            return (value * 100).ToString("0.##") + " %";
        }
    }
}
