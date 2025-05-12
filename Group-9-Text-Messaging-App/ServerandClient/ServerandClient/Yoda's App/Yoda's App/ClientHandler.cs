using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Yoda_s_App
{
    public class ClientHandler
    {
        private readonly TcpClient client;
        private readonly Dictionary<string, TcpClient> clients;
        private string username;

        public ClientHandler(TcpClient client, Dictionary<string, TcpClient> clients)
        {
            this.client = client;
            this.clients = clients;
        }

        public void Run()
        {
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                stream = client.GetStream();
                reader = new StreamReader(stream, new UTF8Encoding(false));
                writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };

                // Read and clean username
                username = reader.ReadLine()?.Trim();
                username = new string(username?.Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());

                if (string.IsNullOrWhiteSpace(username))
                {
                    username = "User_" + Guid.NewGuid().ToString().Substring(0, 4);
                }

                lock (clients)
                {
                    clients[username] = client;
                    SendUserListToAll();
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {username} connected (Total: {clients.Count})");
                }

                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {username}: {message}");

                    if (message.StartsWith("@"))
                    {
                        HandlePrivateMessage(message);
                    }
                    else
                    {
                        BroadcastMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Error ({username}): {ex.Message}");
            }
            finally
            {
                lock (clients)
                {
                    if (username != null && clients.ContainsKey(username))
                    {
                        clients.Remove(username);
                        SendUserListToAll();
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {username} disconnected (Remaining: {clients.Count})");
                    }
                }

                reader?.Dispose();
                writer?.Dispose();
                stream?.Dispose();
                client?.Close();
            }
        }

        private void HandlePrivateMessage(string message)
        {
            string[] parts = message.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string targetUsername = parts[0].Substring(1).Trim();
                string privateMessage = parts[1];

                if (string.Equals(targetUsername, username, StringComparison.OrdinalIgnoreCase))
                {
                    SendPrivateMessage(username, "[Private] Cannot message yourself");
                    return;
                }

                SendPrivateMessage(targetUsername, $"[Private] {username}: {privateMessage}");
                SendPrivateMessage(username, $"[Private] (to {targetUsername}): {privateMessage}");
            }
        }

        private void SendPrivateMessage(string targetUsername, string message)
        {
            lock (clients)
            {
                if (clients.TryGetValue(targetUsername, out TcpClient targetClient))
                {
                    try
                    {
                        var targetWriter = new StreamWriter(targetClient.GetStream(), new UTF8Encoding(false)) { AutoFlush = true };
                        targetWriter.WriteLine($"[{DateTime.Now:HH:mm:ss}] [Private] {username}: {message}");
                    }
                    catch
                    {
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Failed to send to {targetUsername}");
                    }
                }
                else
                {
                    SendPrivateMessage(username, $"[Private] User '{targetUsername}' not found");
                }
            }
        }

        private void BroadcastMessage(string message)
        {
            lock (clients)
            {
                foreach (var kvp in clients)
                {
                    try
                    {
                        var broadcastWriter = new StreamWriter(kvp.Value.GetStream(), new UTF8Encoding(false)) { AutoFlush = true };
                        broadcastWriter.WriteLine($"[{DateTime.Now:HH:mm:ss}] [Group] {username}: {message}");
                    }
                    catch { /* Ignore disconnected clients */ }
                }
            }
        }

        private void SendUserListToAll()
        {
            lock (clients)
            {
                string userList = "@users " + string.Join(",", clients.Keys);
                foreach (var kvp in clients)
                {
                    try
                    {
                        var listWriter = new StreamWriter(kvp.Value.GetStream(), new UTF8Encoding(false)) { AutoFlush = true };
                        listWriter.WriteLine(userList);
                    }
                    catch { /* Ignore disconnected clients */ }
                }
            }
        }
    }
}