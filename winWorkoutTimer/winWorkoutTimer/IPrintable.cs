using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace winWorkoutTimer
{
    interface IPrintable
    {
        string Print();
        Brush Format();
    }
}
