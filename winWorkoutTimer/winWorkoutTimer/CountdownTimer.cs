// -----------------------------------------------------------------------
// <copyright file="CountdownTimer.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace winWorkoutTimer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CountdownTimer : BaseTimer, ITickable, IPrintable
    {
        private TimeSpan seedTime;
        public CountdownTimer(TimeSpan seedTime)
        {
            timerValue = seedTime;
            this.seedTime = seedTime;
        }
        public override void Tick()
        {
            if (TimeSpan.Compare(timerValue, new TimeSpan()) > 0)
            {
                timerValue = timerValue.Subtract(TimeSpan.FromSeconds(1));
            }
            
        } 
        public override void Reset()
        {
            this.timerValue = this.seedTime;
        }
        public override System.Windows.Media.Brush Format()
        {
            if (timerValue.Seconds <= 10)
                return System.Windows.Media.Brushes.Red;
            else return base.Format();
        }


    
    }
}
