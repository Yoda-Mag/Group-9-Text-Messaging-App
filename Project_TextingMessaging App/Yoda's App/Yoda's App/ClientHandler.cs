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
                // First line from client is the username
                username = reader.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(username))
                {
                    writer.WriteLine("Invalid username. Connection closed.");
                    client.Close();
                    return;
                }

                // Register the client
                lock (clients)
                {
                    clients[username] = client;
                    updateUserList();
                }

                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{username}: {message}");

                    if (message.StartsWith("@")) // Check for private message
                    {
                        int separatorIndex = message.IndexOf(':');
                        if (separatorIndex > 1)
                        {
                            string targetUser = message.Substring(1, separatorIndex - 1).Trim();
                            string privateMessage = message.Substring(separatorIndex + 1).Trim();

                            sendPrivateMessage(targetUser, $"(direct) {username}: {privateMessage}");
                        }
                        else
                        {
                            writer.WriteLine("Invalid private message format. Use @username: message");
                        }
                    }
                    else
                    {
                        // Broadcast if no @username
                        broadcastMessage($"{username}: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client error: " + ex.Message);
            }
            finally
            {
                client.Close();
                lock (clients)
                {
                    clients.Remove(username);
                    updateUserList();
                }
            }
        }

        private void broadcastMessage(string message)
        {
            lock (clients)
            {
                foreach (var pair in clients)
                {
                    if (pair.Key != username) // Skip sender
                    {
                        try
                        {
                            StreamWriter writer = new StreamWriter(pair.Value.GetStream(), Encoding.UTF8) { AutoFlush = true };
                            writer.WriteLine($"[{DateTime.Now:HH:mm}] {message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Broadcast error: {ex.Message}");
                        }
                    }
                }
                clients[username] = client; //takes user list and send it back to client
                updateUserList();

            }
        }

        //Updating users connected to client side
        private void updateUserList()
        {
            List<string> validUsernames = new List<string>();
            lock (clients)
            {
                foreach (string user in clients.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(user))
                    {
                        validUsernames.Add(user.Trim());
                    }
                }

                string users = "@users" + string.Join(",", validUsernames);

                foreach (var pair in clients)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(pair.Value.GetStream(), Encoding.UTF8) { AutoFlush = true };
                        writer.WriteLine(users);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error sending user list: " + ex.Message);
                    }
                }
            }
        }



        private void sendPrivateMessage(string recipient, string message)
        {
            lock (clients)
            {
                if (clients.TryGetValue(recipient, out TcpClient targetClient))
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(targetClient.GetStream(), Encoding.UTF8) { AutoFlush = true };
                        writer.WriteLine($"[{DateTime.Now:HH:mm}] {message}");
                        Console.WriteLine($"Private message from {username} to {recipient}: {message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Private message error: {ex.Message}");
                    }
                }
                else
                {
                    // Optionally inform the sender that user was not found
                    try
                    {
                        StreamWriter senderWriter = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };
                        senderWriter.WriteLine($"User '{recipient}' not found.");
                    }
                    catch
                    {
                        /* silent fail */ 
                    }
                }
            }
        }
    }
}
