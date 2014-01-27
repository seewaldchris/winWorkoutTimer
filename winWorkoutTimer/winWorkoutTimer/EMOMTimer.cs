using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace winWorkoutTimer
{
    public class EMOMTimer : BaseTimer, IPrintable
    {
        public override Brush Format()
        {
            if (timerValue.Seconds >= 50)
                return Brushes.Red;
            else
                return base.Format();
        }
    }
}
