using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace xChat
{
    class MessagePanel : Panel
    {
        Label lblUsername;
        Label lblMessage;

        int msgMaxWidth = 0;

        public MessagePanel(int messageMaxWidth)
        {
            msgMaxWidth = messageMaxWidth;
            BackColor = Color.White;
            AutoSize = true;
        }

        public void Username(string username, Color userColor)
        {
            lblUsername = new Label();
            lblUsername.Text = username;
            lblUsername.Top = 3;
            lblUsername.Left = 5;
            lblUsername.Font = new Font("Tahoma", 9, FontStyle.Bold);
            lblUsername.MaximumSize = new Size(msgMaxWidth, 0);
            lblUsername.AutoSize = true;
            lblUsername.Padding = new Padding(5);
            lblUsername.Margin = new Padding(3);
            lblUsername.ForeColor = userColor;

            Controls.Add(lblUsername);
        }

        public void Message(string message)
        {
            lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Tahoma", 9, FontStyle.Regular);
            lblMessage.ForeColor = Color.FromArgb(100, 100, 100);

            if (Controls.Count == 0)
            {
                lblMessage.Top = 5;
            }
            else
            {
                lblMessage.Top = 20;
            }

            lblMessage.Left = 5;
            lblMessage.MaximumSize = new Size(msgMaxWidth, 0);
            lblMessage.AutoSize = true;
            lblMessage.Padding = new Padding(5);
            lblMessage.Margin = new Padding(3);

            Controls.Add(lblMessage);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width-1, this.Height-1);

            g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(239,239,239))), rect);
        }
        
    }
}
