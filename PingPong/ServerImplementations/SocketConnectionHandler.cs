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
        private IDataProcessor _dataProcessor;

        public SocketConnectionHandler(IDataProcessor processor)
        {
            _dataProcessor = processor;
        }

        public async Task HandleNewConnection(Socket clientSocket)
        {
            while (true)
            {
            Task<byte[]> readData = new Task<byte[]>(() => ReadData(clientSocket));
            readData.Start();
            byte[] receivedData = await readData;
            SendData(clientSocket ,_dataProcessor.GetDataToReturn(receivedData));
            }
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
