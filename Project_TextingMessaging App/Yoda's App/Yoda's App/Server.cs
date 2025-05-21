using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Yoda_s_App
{
    class Server
    {
        private TcpListener listener; //uses TCP 
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();

        public void Start() // Method activates the server...
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("The Server started on port 5000...");
          

            while (true) //Makes the server continuously listen for client's messages
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
