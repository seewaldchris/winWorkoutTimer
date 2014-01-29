using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;


namespace winWorkoutTimer
{
    public class BaseTimer : IPrintable, ITickable
    {
        protected TimeSpan timerValue;

        public BaseTimer()
        {
            this.timerValue = new TimeSpan();
        }
        public virtual void Tick()
        {
            this.timerValue = timerValue.Add(TimeSpan.FromSeconds(1));
        }
        public virtual string Print()
        {
            return this.timerValue.ToString();
        }
        public virtual Brush Format()
        {
            return Brushes.Yellow;
        }
        public virtual void Reset()
        {
            this.timerValue = new TimeSpan();
        }

        
    }
}
