using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    class Server
    {
        private Socket _serverSocket;

        private IPEndPoint _socketConfiguration;

        public Server(int port)
        {            
            _serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _socketConfiguration = new IPEndPoint(IPAddress.Any, port);
            _serverSocket.Bind(_socketConfiguration);
        }

        public void Start()
        {
            int maxPendingConnectionsQueue = 10;
            try
            {
                maxPendingConnectionsQueue = int.Parse(ConfigurationManager.AppSettings["Max_Queue_Length"]);
            }
            catch (Exception e)
            {
                //Log
            }
            _serverSocket.Listen(50);
        }
    }
}
