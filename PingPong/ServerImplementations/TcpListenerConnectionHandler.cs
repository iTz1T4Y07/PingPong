using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerImplementations
{
    public class TcpListenerConnectionHandler : IConnectionHandler<TcpClient>
    {
        private IDataProcessor _dataProcessor;

        public TcpListenerConnectionHandler(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public async Task HandleNewConnection(TcpClient client)
        {
            while (true)
            {
                Task<byte[]> readData = ReadData(client);
                byte[] receivedData = await readData;
                if (!(receivedData is null))
                {
                    await SendData(client, _dataProcessor.GetDataToReturn(receivedData));
                }
            }
        }

        private async Task<byte[]> ReadData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            if (!stream.CanRead)
            {
                return null;
            }
            if (client.ReceiveBufferSize <= 0)
            {
                client.ReceiveBufferSize = 1024;
            }

            byte[] buffer = new byte[client.ReceiveBufferSize];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return buffer;
        }

        private async Task<bool> SendData(TcpClient client, byte[] dataBuffer)
        {
            NetworkStream stream = client.GetStream();
            if (!stream.CanWrite)
            {
                return false;
            }

            await stream.WriteAsync(dataBuffer, 0, dataBuffer.Length);
            return true;
        }
    }
}
