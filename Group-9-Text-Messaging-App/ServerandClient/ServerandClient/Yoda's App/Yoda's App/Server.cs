using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Yoda_s_App
{
    class Server
    {
        private TcpListener listener;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started on port 5000...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New client connected.");

                ClientHandler handler = new ClientHandler(client, clients);
                Thread thread = new Thread(handler.Run);
                thread.Start();
            }
        }
    }
}
