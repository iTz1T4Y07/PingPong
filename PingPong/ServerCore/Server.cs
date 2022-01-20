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
        private readonly TcpListener _listener;

        private IConnectionHandler<TcpClient> _connectionHandler;

        private IList<TcpClient> _clientConnections;

        public Server(int port, IConnectionHandler<TcpClient> connectionHandler)
        {          
            _connectionHandler = connectionHandler;
            _clientConnections = new List<TcpClient>();
            _listener = TcpListener.Create(port);            
        }

        public async Task Start()
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

            _listener.Start(maxPendingConnectionsQueue);                        
            while (_listener.Server.IsBound)
            {
                TcpClient newClient = await _listener.AcceptTcpClientAsync();                
                _clientConnections.Add(newClient);
                _  = _connectionHandler.HandleNewConnection(newClient);
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}