using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerImplementations
{
    public class SocketConnectionHandler : IConnectionHandler<Socket>
    {
        private IDataProcessor dataProcessor;

        public async Task HandleNewConnection(Socket clientSocket)
        {            
            throw new NotImplementedException();
        }

        private byte[] ReadData(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];            
            clientSocket.Receive(buffer);
            return buffer;
        }

        private void SendData(Socket clientSocket, byte[] dataBuffer)        {
            clientSocket.Send(dataBuffer);
        }
    }
}
