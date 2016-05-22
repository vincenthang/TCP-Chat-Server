namespace GroupChatClient
{
    partial class ChatForm
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
            this.plInput = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.plOutput = new System.Windows.Forms.FlowLayoutPanel();
            this.plInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // plInput
            // 
            this.plInput.Controls.Add(this.txtMessage);
            this.plInput.Controls.Add(this.btnSend);
            this.plInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plInput.Location = new System.Drawing.Point(0, 426);
            this.plInput.Name = "plInput";
            this.plInput.Size = new System.Drawing.Size(337, 56);
            this.plInput.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(262, 56);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(262, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 56);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = ">";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // plOutput
            // 
            this.plOutput.AutoScroll = true;
            this.plOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plOutput.Location = new System.Drawing.Point(0, 0);
            this.plOutput.Name = "plOutput";
            this.plOutput.Size = new System.Drawing.Size(337, 426);
            this.plOutput.TabIndex = 2;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(337, 482);
            this.Controls.Add(this.plOutput);
            this.Controls.Add(this.plInput);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChatForm";
            this.ShowIcon = false;
            this.Text = "Group Chat";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.plInput.ResumeLayout(false);
            this.plInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.FlowLayoutPanel plOutput;
        private System.Windows.Forms.TextBox txtMessage;
    }
}