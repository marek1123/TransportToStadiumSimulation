using System;

namespace TransportToStadiumSimulation.statistics
{
    public class Timer
    {
        double runningFromTime;
        double runningTimeSum;
        bool running = false;

        public void Reset()
        {
            runningFromTime = 0;
            runningTimeSum = 0;
            running = false;
        }

        public void Start(double time)
        {
            if (running)
            {
                throw new InvalidOperationException("Timer is already running");
            }
            runningFromTime = time;
            running = true;
        }

        public void Stop(double time)
        {
            if (!running)
            {
                throw new InvalidOperationException("Only running timer can be stopped.");
            }
            runningTimeSum += (time - runningFromTime);
            running = false;
        }

        public double ActualTime(double time)
        {
            if (!running)
            {
                throw new InvalidOperationException("Timer is not running.");
            }
            return (time - runningFromTime);
        }

        public double Sum(double time)
        {
            if (running)
            {
                return runningTimeSum + ActualTime(time);
            }
            else
            {
                return runningTimeSum;
            }
        }

        public double Sum()
        {
            return runningTimeSum;
        }
    }
}
