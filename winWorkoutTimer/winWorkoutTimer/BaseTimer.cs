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
        protected TimeSpan startCountdown;

        protected const int COUNTDOWN_VALUE = 10;

        public BaseTimer()
        {
            this.timerValue = new TimeSpan();
            this.startCountdown = TimeSpan.FromSeconds(COUNTDOWN_VALUE);
        }
        public virtual void Tick()
        {
            if (startCountdown.Seconds > 0)
            {
                this.startCountdown = this.startCountdown.Subtract(TimeSpan.FromSeconds(1));
            }
            else
            {
                this.timerValue = timerValue.Add(TimeSpan.FromSeconds(1));
            }
        }
        public virtual string Print()
        {
            if (startCountdown.Seconds > 0)
            {
                return startCountdown.Seconds.ToString();
            }
            else
            {
                if (timerValue.Hours == 0)
                    return timerValue.ToString(@"mm\:ss");
                else
                    return this.timerValue.ToString();

            }


        }
        public virtual Brush Format()
        {
            return Brushes.Yellow;
        }
        public virtual void Reset()
        {
            this.timerValue = new TimeSpan();
            this.startCountdown = TimeSpan.FromSeconds(COUNTDOWN_VALUE);
        }


    }
}
