using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;


namespace CLIENT
{
    public partial class GroupForm : Form
    {
        TcpClient client; 
        StreamReader reader;
        StreamWriter writer;
        Thread receiveThread;  //Connects clients to Server.

        public GroupForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Group 9's text messaging App :)");
            txtUsername.Clear();
            cmbxTo.Items.Clear();
            cmbxTo.Items.Add("Group");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // int ipNum = 1;
                
                client = new TcpClient("6.tcp.eu.ngrok.io", 19337); //server IPs and port number 
                reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };

                writer.WriteLine(txtUsername.Text); // Send username
                receiveThread = new Thread(receiveMessages);  //Recieves thread from server application
                receiveThread.Start();  //Start method from the server
                
                MessageBox.Show("Connected to server."); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                if (client != null && client.Connected)
                {
                    string message = txtMessage.Text.Trim();
                    string recipient = cmbxTo.SelectedItem != null
                         ? cmbxTo.SelectedItem.ToString().Trim()
                         : string.Empty;

                    if (!string.IsNullOrEmpty(message))
                    {
                        string displayMessage;

                        if (!string.IsNullOrEmpty(recipient) && recipient != "Group")
                        {
                            // Send private message
                            writer.WriteLine($"@{recipient}: {message}");
                            displayMessage = $"[Me -> {recipient}]: {message}";
                        }
                        else
                        {
                            // Send broadcast message
                            writer.WriteLine(message);
                            displayMessage = $"[Me]: {message}";
                        }

                        appendText($"[{DateTime.Now:HH:mm}] {displayMessage}");
                        txtMessage.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send error: " + ex.Message);
            }
        }

        private void receiveMessages()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    if (message.StartsWith("@users"))
                    {
                        string usersCsv = message.Substring(7).Trim();
                        string[] users = usersCsv.Split(',');

                        updateUserList(users);
                    }
                    else
                    {
                        appendText(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving messages: " + ex.Message);
            }
        }
        private void updateUserList(string[] users)
        {
            if (cmbxTo.InvokeRequired)
            {
                cmbxTo.Invoke(new Action(() => populateComboBox(users)));
            }
            else
            {
                populateComboBox(users);
            }
        }

        private void populateComboBox(string[] users)
        {
            cmbxTo.Items.Clear();
            cmbxTo.Items.Add("Group");

            foreach (string user in users)
            {
                if (user != txtUsername.Text) // Don't show self
                {
                    cmbxTo.Items.Add(user);
                }
            }

            cmbxTo.SelectedIndex = 0;

            // Disable private messaging if alone
            bool hasOthers = cmbxTo.Items.Count > 1;
            cmbxTo.Enabled = hasOthers;
            btnSend.Enabled = hasOthers || txtMessage.Text.Trim() != "";
        }


        //private HashSet<string> messageHistory = new HashSet<string>();

        private void appendText(string text)
        {
            if (lstChat.InvokeRequired)
            {
                lstChat.Invoke(new Action(() => addMessageToList(text)));
            }
            else
            {
                addMessageToList(text);
            }
        }

        private void addMessageToList(string text)
        {
            // Prevent double messages by checking the last added message
            if (!string.IsNullOrEmpty(text) && (lstChat.Items.Count == 0 || lstChat.Items[lstChat.Items.Count - 1].ToString().Trim() != text.Trim()))
            {
                lstChat.Items.Add(text);
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
