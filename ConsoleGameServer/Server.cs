using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleGameServer
{
    class Server
    {
        private static TcpListener socket; // it handles most of the connection stuff
        private static int port = 16320;
        public static void InitNetwork()
        {
            Logger.Log(LogType.info1, "Server is starting...");
            ServerHandler.InitPackets();
            socket = new TcpListener(IPAddress.Any, port);
            socket.Start();
            socket.BeginAcceptTcpClient(new AsyncCallback(ClientConnected), null);
            Logger.Log(LogType.info2, $"Server's running on port:{port}");
        }
        private static void ClientConnected(IAsyncResult _result) // ClientConnected will be called whenever a client connects
        {
            TcpClient _client = socket.EndAcceptTcpClient(_result);
            _client.NoDelay = false;
            socket.BeginAcceptTcpClient(new AsyncCallback(ClientConnected), null);
            Logger.Log(LogType.info1, $"Client's attempting connection to the server. Incoming connection from {_client.Client.RemoteEndPoint}");

            for (int i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                if (Globals.clients[i].socket == null)
                {
                    Globals.clients[i].socket = _client;
                    Globals.clients[i].playerID = i;
                    Globals.clients[i].StartClient();
                    return;
                }
            }
            Logger.Log(LogType.warning, "Server's full");
        }
    }
}
