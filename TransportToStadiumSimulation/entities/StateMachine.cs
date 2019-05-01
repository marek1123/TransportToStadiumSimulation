using System;
using TransportToStadiumSimulation.statistics;

namespace TransportToStadiumSimulation.entities
{
    public abstract class StateMachine<T> where T: Enum
    {        
        private double currentStateDuration;
        private bool isCurrentStateDurationKnown = false;

        private Timer[] timers;

        protected abstract double CurrentTime { get; }
        public T CurrentState { get; private set; }

        public StateMachine(T initState, double initTime)
        {            
            var states = Enum.GetValues(typeof(T));

            timers = new Timer[states.Length];

            for (int i = 0; i < timers.Length; i++)
            {
                timers[i] = new Timer();
            }
            
            CurrentState = initState;            
            timers[(int)(object)initState].Start(initTime);
        }

        public virtual void Reset(T initState, double initTime)
        {
            CurrentState = initState;
            foreach (var timer in timers)
            {
                timer.Reset();
            }
            timers[(int)(object)initState].Start(initTime);

            isCurrentStateDurationKnown = false;
        }

        public virtual void EnterState(T newState, double duration)
        {
            isCurrentStateDurationKnown = true;
            currentStateDuration = duration;
            SwitchState(newState, CurrentTime);
        }

        public virtual void EnterState(T newState)
        {
            isCurrentStateDurationKnown = false;
            SwitchState(newState, CurrentTime);
        }
        
        public double SumTimeInState(T state)
        {
            return timers[(int)(object)state].Sum(CurrentTime);
        }

        public double PercentageFinished()
        {
            if (!isCurrentStateDurationKnown)
            {
                return 0;
            }
            else
            {
                return timers[(int)(object)CurrentState].ActualTime(CurrentTime) / currentStateDuration;
            }
        }

        private void SwitchState(T newState, double currentTime)
        {
            timers[(int)(object)CurrentState].Stop(currentTime);
            timers[(int)(object)newState].Start(currentTime);
            CurrentState = newState;
        }               
    }
}
