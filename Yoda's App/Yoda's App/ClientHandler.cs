using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;


namespace Yoda_s_App
{
    
    public class ClientHandler
    {
        private TcpClient client; 
        private Dictionary<string, TcpClient> clients;
        private string username;

        public ClientHandler(TcpClient client, Dictionary<string, TcpClient> clients)
        {
            this.client = client;
            this.clients = clients;
        }

        public void Run()
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            try
            {
                // First message = username
                username = reader.ReadLine();
                lock (clients)
                {
                    clients[username] = client;
                }

                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{username}: {message}");
                    BroadcastMessage($"{username}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client error: " + ex.Message);
            }
            finally
            {
                client.Close(); //removes client if an error occurred
                lock (clients)
                {
                    clients.Remove(username); 
                }
            }
        }

        private void BroadcastMessage(string message) //for broadcast messages
        {
            lock (clients)
            {
                foreach (var otherClient in clients.Values)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(otherClient.GetStream(), Encoding.UTF8) { AutoFlush = true };
                        writer.WriteLine( $"[{ DateTime.Now:HH:mm} ]" + message );
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

}
