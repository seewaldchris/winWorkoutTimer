using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;


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
        public void Reset()
        {
            timerValue = new TimeSpan();
        }

        public virtual string Print()
        {
            return timerValue.ToString();
        }
        public virtual Brush Format()
        {
            return Brushes.Yellow;
        }
        
    }
}
