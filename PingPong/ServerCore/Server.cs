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
    public class Server
    {
        private Socket _serverSocket;

        private IPEndPoint _socketConfiguration;

        private IConnectionHandler _connectionHandler;

        private IList<Socket> _clientConnections;

        public Server(int port, IConnectionHandler connectionHandler)
        {
            _connectionHandler = connectionHandler;
            _clientConnections = new List<Socket>();
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
            while (!(_serverSocket.Poll(1000, SelectMode.SelectRead) && _serverSocket.Available == 0))
            {
                Socket clientSocket = _serverSocket.Accept();
                _clientConnections.Add(clientSocket);
                _connectionHandler.HandleNewConnection(clientSocket);
            }
        }

        public void Stop()
        {
            _serverSocket.Close();
        }
    }
}