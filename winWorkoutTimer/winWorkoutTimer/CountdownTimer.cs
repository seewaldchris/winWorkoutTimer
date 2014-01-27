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
        public CountdownTimer(TimeSpan seedTime)
        {
            timerValue = seedTime;
        }
        public override void Tick()
        {
            timerValue = timerValue.Subtract(TimeSpan.FromSeconds(1));
        } 

    
    }
}
