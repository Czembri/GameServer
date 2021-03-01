using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameServer
{
    class Globals
    {
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
        public static bool serverIsRunning = false;
    }
}
