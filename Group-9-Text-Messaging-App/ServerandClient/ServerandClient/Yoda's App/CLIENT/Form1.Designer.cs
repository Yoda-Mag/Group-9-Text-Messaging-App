
namespace CLIENT
{
    partial class GroupForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblChat = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.gpbxConnect = new System.Windows.Forms.GroupBox();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.gpbxConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(105, 60);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(292, 22);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(105, 206);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 68);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(237, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(10, 138);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(237, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(16, 60);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 17);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message";
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Location = new System.Drawing.Point(16, 137);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(37, 17);
            this.lblChat.TabIndex = 6;
            this.lblChat.Text = "Chat";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(240, 17);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Please enter username and connect:";
            // 
            // gpbxConnect
            // 
            this.gpbxConnect.Controls.Add(this.txtUsername);
            this.gpbxConnect.Controls.Add(this.lblUsername);
            this.gpbxConnect.Controls.Add(this.btnConnect);
            this.gpbxConnect.Location = new System.Drawing.Point(514, 21);
            this.gpbxConnect.Name = "gpbxConnect";
            this.gpbxConnect.Size = new System.Drawing.Size(257, 256);
            this.gpbxConnect.TabIndex = 8;
            this.gpbxConnect.TabStop = false;
            this.gpbxConnect.Text = "Login";
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 16;
            this.lstChat.Location = new System.Drawing.Point(105, 108);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(292, 84);
            this.lstChat.TabIndex = 9;
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(105, 20);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(292, 24);
            this.cmbUsers.TabIndex = 10;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Location = new System.Drawing.Point(16, 23);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(65, 17);
            this.lblRecipient.TabIndex = 11;
            this.lblRecipient.Text = "Send To:";
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.lblRecipient);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.gpbxConnect);
            this.Controls.Add(this.lblChat);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GroupForm";
            this.Text = "Group Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpbxConnect.ResumeLayout(false);
            this.gpbxConnect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblChat;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gpbxConnect;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label lblRecipient;
    }
}

