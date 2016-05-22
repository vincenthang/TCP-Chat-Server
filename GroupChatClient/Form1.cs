using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterHorizontally(pl1);
            CenterHorizontally(btnChat);
        }

        public void CenterHorizontally(Control control)
        {
            Rectangle parentRect = control.Parent.ClientRectangle;
            control.Left = (parentRect.Width - control.Width) / 2;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm();
            chatForm.Username = txtUsername.Text;
            chatForm.Show();
            this.Hide();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
        }
    }
}
