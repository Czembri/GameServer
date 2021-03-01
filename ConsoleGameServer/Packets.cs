using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameServer
{
    public enum ServerPackets
    {
        // sent from server to client
        welcome = 1
    }

    public enum ClientPackets
    {
        // sent from client to server
        welcomeReceived = 1
    }

    class Packets
    {
    }
}
