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
        public async Task HandleNewConnection(Socket clientSocket)
        {            
            throw new NotImplementedException();
        }

        private Task<byte[]> ReadData(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];            
            clientSocket.Receive(buffer);
            return new Task<byte[]>(() => buffer);
        }
    }
}
