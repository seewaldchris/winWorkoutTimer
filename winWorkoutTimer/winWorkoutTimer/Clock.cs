using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winWorkoutTimer
{
    class Clock : BaseTimer, IPrintable
    {
        private DateTime creationTime;
        public Clock() : base()
        {
            creationTime = DateTime.Now;     
        }
        public override string Print()
        {
            return creationTime.Add(timerValue).ToLongTimeString();
        }
    }
}
