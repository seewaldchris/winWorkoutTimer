using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace winWorkoutTimer
{
    class RefreshTimer : DispatcherTimer
    {
        private ITickable timeValue;
        public RefreshTimer(TimeSpan interval, ITickable t) : base()
        {
            this.Interval = interval;
            this.timeValue = t;
            this.Tick +=new EventHandler(TickEventHandler);
            this.Start();
        }
        private void TickEventHandler(object sender, EventArgs e)
        {
            this.timeValue.Tick();
        }

    }
}
