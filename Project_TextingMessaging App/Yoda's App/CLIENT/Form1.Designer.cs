
namespace CLIENT
{
    partial class GroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxTo = new System.Windows.Forms.ComboBox();
            this.grpDialogue = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gpbxConnect.SuspendLayout();
            this.grpDialogue.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(74, 184);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(292, 22);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(74, 227);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(111, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 68);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(237, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(10, 138);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(237, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(2, 184);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 17);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message";
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Location = new System.Drawing.Point(7, 28);
            this.lblChat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(37, 17);
            this.lblChat.TabIndex = 6;
            this.lblChat.Text = "Chat";
            this.lblChat.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 35);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(240, 17);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "please enter username and connect:";
            this.lblUsername.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // gpbxConnect
            // 
            this.gpbxConnect.Controls.Add(this.txtUsername);
            this.gpbxConnect.Controls.Add(this.lblUsername);
            this.gpbxConnect.Controls.Add(this.btnConnect);
            this.gpbxConnect.Location = new System.Drawing.Point(699, 47);
            this.gpbxConnect.Name = "gpbxConnect";
            this.gpbxConnect.Size = new System.Drawing.Size(257, 298);
            this.gpbxConnect.TabIndex = 8;
            this.gpbxConnect.TabStop = false;
            this.gpbxConnect.Text = "Login";
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 16;
            this.lstChat.Location = new System.Drawing.Point(74, 29);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(292, 132);
            this.lstChat.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "To:";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // cmbxTo
            // 
            this.cmbxTo.FormattingEnabled = true;
            this.cmbxTo.Location = new System.Drawing.Point(429, 21);
            this.cmbxTo.Name = "cmbxTo";
            this.cmbxTo.Size = new System.Drawing.Size(191, 24);
            this.cmbxTo.TabIndex = 11;
            // 
            // grpDialogue
            // 
            this.grpDialogue.Controls.Add(this.lstChat);
            this.grpDialogue.Controls.Add(this.label1);
            this.grpDialogue.Controls.Add(this.cmbxTo);
            this.grpDialogue.Controls.Add(this.lblChat);
            this.grpDialogue.Controls.Add(this.txtMessage);
            this.grpDialogue.Controls.Add(this.lblMessage);
            this.grpDialogue.Controls.Add(this.btnSend);
            this.grpDialogue.Location = new System.Drawing.Point(12, 47);
            this.grpDialogue.Name = "grpDialogue";
            this.grpDialogue.Size = new System.Drawing.Size(640, 311);
            this.grpDialogue.TabIndex = 12;
            this.grpDialogue.TabStop = false;
            this.grpDialogue.Text = "Dialogue";
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(988, 533);
            this.Controls.Add(this.grpDialogue);
            this.Controls.Add(this.gpbxConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GroupForm";
            this.Text = "Company Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpbxConnect.ResumeLayout(false);
            this.gpbxConnect.PerformLayout();
            this.grpDialogue.ResumeLayout(false);
            this.grpDialogue.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxTo;
        private System.Windows.Forms.GroupBox grpDialogue;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

