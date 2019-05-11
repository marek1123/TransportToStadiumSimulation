namespace TransportToStadiumSimulation.utils
{
    public class StatFormatter
    {
        public static string FormatStatistic(double mean, double confidenceIntervalHalfWidth)
        {
            string left = (mean - confidenceIntervalHalfWidth).ToString("F4");
            string right = (mean + confidenceIntervalHalfWidth).ToString("F4");

            return mean.ToString("F4") + " <" +  left + " , " + right + ">";
        }

        public static string FormatStatistic(double mean, double[] confidenceInterval)
        {
            string left = confidenceInterval[0].ToString("F4");
            string right = confidenceInterval[1].ToString("F4");

            return mean.ToString("F4") + " <" + left + " , " + right + ">";
        }
    }
}
