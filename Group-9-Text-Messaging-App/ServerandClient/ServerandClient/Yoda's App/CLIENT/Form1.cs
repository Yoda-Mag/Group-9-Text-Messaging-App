using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CLIENT
{
    public partial class GroupForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread receiveThread;
        private readonly HashSet<string> messageHistory = new HashSet<string>();

        public GroupForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Group 9's text messaging App :)");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Please enter a username");
                    return;
                }

                client = new TcpClient("127.0.0.1", 5000);

                // Flush any existing data in the stream
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                while (stream.DataAvailable)
                {
                    stream.Read(buffer, 0, buffer.Length);
                }

                reader = new StreamReader(stream, new UTF8Encoding(false));
                writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };

                writer.WriteLine(txtUsername.Text.Trim());
                receiveThread = new Thread(ReceiveMessages) { IsBackground = true };
                receiveThread.Start();

                btnConnect.Enabled = false;
                txtUsername.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (writer == null || string.IsNullOrWhiteSpace(txtMessage.Text))
                    return;

                string message = cmbUsers.SelectedItem?.ToString() == "Group"
                    ? txtMessage.Text
                    : $"@{cmbUsers.SelectedItem} {txtMessage.Text}";

                writer.WriteLine(message);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send error: {ex.Message}");
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    if (message.StartsWith("@users"))
                    {
                        UpdateUserList(message.Substring(6).Trim());
                    }
                    else
                    {
                        AppendMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                AppendMessage($"Connection lost: {ex.Message}");
                Disconnect();
            }
        }

        private void UpdateUserList(string userList)
        {
            if (cmbUsers.InvokeRequired)
            {
                cmbUsers.Invoke(new Action<string>(UpdateUserList), userList);
                return;
            }

            cmbUsers.Items.Clear();
            cmbUsers.Items.Add("Group");

            foreach (var user in userList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string cleanUser = user.Trim();
                if (!string.IsNullOrEmpty(cleanUser) && !cmbUsers.Items.Contains(cleanUser))
                {
                    cmbUsers.Items.Add(cleanUser);
                }
            }

            if (cmbUsers.Items.Count > 0)
            {
                cmbUsers.SelectedIndex = 0;
            }
        }

        private void AppendMessage(string message)
        {
            if (lstChat.InvokeRequired)
            {
                lstChat.Invoke(new Action<string>(AppendMessage), message);
                return;
            }

            if (!string.IsNullOrWhiteSpace(message) && !messageHistory.Contains(message))
            {
                lstChat.Items.Add(message);
                lstChat.TopIndex = lstChat.Items.Count - 1;
                messageHistory.Add(message);
            }
        }

        private void Disconnect()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Disconnect));
                return;
            }

            try
            {
                receiveThread?.Abort();
                writer?.Close();
                reader?.Close();
                client?.Close();
            }
            catch { }

            btnConnect.Enabled = true;
            txtUsername.Enabled = true;
        }

        private void GroupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}