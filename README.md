📨 Final Texting App (Group 9)
A lightweight, Windows Forms-based messaging app that supports real-time group and private text communication over the internet.

🔧 Projects Included
✅ Client App
Developed using C# and Windows Forms.

Supports:

User login via a dedicated login form.

Real-time chat interface with message timestamps.

ComboBox to select users for private messaging.

Auto-updating user list (@users protocol).

🧠 Server: "Yoda's App"
A console-based C# server app that:

Handles multiple concurrent client connections.

Registers clients with unique usernames.

Supports broadcast and private messaging.

Sends updated user lists to all connected clients.

💻 Requirements
.NET Framework 4.7.2 or later

Windows 10 or 11

Internet access

Optionally, use Ngrok for port forwarding to allow remote connections

🛠 How to Run
1. Start the Server
Run Yoda_s_App.exe or build and launch the Yoda_s_App project from Visual Studio.

2. Start the Client
Run the client app (CLIENT.exe) or launch from Visual Studio.

Enter a username in the login form.

Connect to the server using its public IP and port (e.g. via Ngrok).

Chat with all users or select one for a private message.

📦 Features
✅ Simple UI built with Windows Forms

✅ Private messaging with @username format

✅ Broadcast messaging

✅ Dynamic user list updates

✅ Thread-safe message display

✅ UTF-8 encoding support

🔐 Security Notes
Basic input validation implemented.

No end-to-end encryption (for educational purposes only).

🧑‍💻 Authors
Group 9 (BSc IT Final Year, NWU 2025)

