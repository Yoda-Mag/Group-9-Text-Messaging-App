using System;
using System.IO;
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
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // int ipNum = 1;
                client = new TcpClient("127.0.0.2", 5000); //server IPs and port number
                reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };

                writer.WriteLine(txtUsername.Text); // Send username
                receiveThread = new Thread(ReceiveMessages); //Recieves thread from server application
                receiveThread.Start(); //Start method from the server

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
                if (writer != null) //sends text messages if not null
                {
                    writer.WriteLine(txtMessage.Text);
                    txtMessage.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    AppendText(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving messages: " + ex.Message);
            }
        }
        private HashSet<string> messageHistory = new HashSet<string>();

        private void AppendText(string text)
        {
            if (lstChat.InvokeRequired)
            {
                lstChat.Invoke(new Action(() => AddMessageToList(text)));
            }
            else
            {
                AddMessageToList(text);
            }
        }

        private void AddMessageToList(string text)
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
    }
}
