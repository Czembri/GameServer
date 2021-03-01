using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameServer
{
    class Constants
    {
        public const int MAX_PLAYERS = 10; 
        public const int TICKS_PER_SEC = 30; // one tick is like one frame
        public const float MS_PER_TICK = 1000 / TICKS_PER_SEC;
    }
}
