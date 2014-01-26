using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace winWorkoutTimer
{
    class BaseTimer : IPrintable, ITickable
    {
        protected TimeSpan timerValue;

        public BaseTimer()
        {
            timerValue = new TimeSpan();
        }
        public void Tick()
        {
            timerValue = timerValue.Add(TimeSpan.FromSeconds(1));
        }

        public virtual string Print()
        {
            throw new NotImplementedException();
        }
        
    }
}
