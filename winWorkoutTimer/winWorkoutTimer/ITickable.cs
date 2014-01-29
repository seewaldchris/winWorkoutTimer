using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winWorkoutTimer
{
    interface ITickable
    {
        void Tick();
        void Reset();
    }
}
