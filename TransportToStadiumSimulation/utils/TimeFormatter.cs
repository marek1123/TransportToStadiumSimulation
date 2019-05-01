namespace TransportToStadiumSimulation.utils
{
    public class TimeFormatter
    {
        public static string HoursMinutesSecondsString(double timeInSeconds)
        {
            int time = (int) timeInSeconds;
            double seconds = time % 60;

            time /= 60;
            int minutes = time % 60;

            time /= 60;
            int hours = time;

            return hours + ":" + minutes + ":" + seconds;
        }

        public static double HoursMinutesSecondsToDouble(int hours, int minutes, int seconds)
        {
            return hours * 3600 + minutes * 60 + seconds;
        }
    }
}
