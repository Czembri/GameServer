using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Globals.serverIsRunning = true;
            Logger.Initialize(ConsoleColor.Cyan);

            Thread _gameThread = new Thread(new ThreadStart(GameLogicThread));
            _gameThread.Start();
            General.StartServer();
        }

        private static void GameLogicThread()
        {
            Logger.Log(LogType.info1, $"Game thread started. Running at {Constants.TICKS_PER_SEC} ticks per second");
            // game logic'd go here

            DateTime _lastLoop = DateTime.Now;
            DateTime _nextLoop = _lastLoop.AddMilliseconds(Constants.MS_PER_TICK);

            while (Globals.serverIsRunning)
            {
                while (_nextLoop < DateTime.Now)
                {
                    Logger.WriteLogs();

                    _lastLoop = _nextLoop;
                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);
                    
                    if (_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
