﻿using ServerCore;
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

        public Task HandleNewConnection(TcpClient clientSocket)
        {
            throw new NotImplementedException();
        }

        private async Task<byte[]> ReadData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            if (client.ReceiveBufferSize <= 0)
            {
                client.ReceiveBufferSize = 1024;
            }

            byte[] buffer = new byte[client.ReceiveBufferSize];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return buffer;
        }        
    }
}
