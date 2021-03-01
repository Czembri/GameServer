using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameServer
{
    class General
    {
        public static void StartServer()
        {
            InitServerData();
            Server.InitNetwork();
            Logger.Log(LogType.info2, "Server started");
        }
        private static void InitServerData() //populates clients dictionary
        {
            for (int i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                Globals.clients.Add(i, new Client());
            }
        }
    }
}
