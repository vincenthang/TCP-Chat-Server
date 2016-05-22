using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using xChat;

namespace GroupChatClient
{
    public partial class ChatForm : Form
    {
        protected TcpClient _client;
        protected StreamWriter _sWriter;
        protected Dictionary<string, Color> _userColors = new Dictionary<string, Color>();
        protected List<Color> _colors = new List<Color>();
        

        public ChatForm()
        {
            InitializeComponent();
            _colors.Add(Color.Red);
            _colors.Add(Color.Green);
            _colors.Add(Color.Blue);
            _colors.Add(Color.Violet);
            _colors.Add(Color.Orange);
            _colors.Add(Color.Pink);
            _colors.Add(Color.Purple);
            _colors.Add(Color.Brown);
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _sWriter.WriteLine("m:" + Username + ":" + txtMessage.Text);
            _sWriter.Flush();
            txtMessage.Text = "";
        }

        public void ConnectToServer()
        {
            try
            {
                TcpClient tcp = new TcpClient("25.150.130.211", 9000);

                NetworkStream ns = tcp.GetStream();

                _sWriter = new StreamWriter(ns);
                StreamWriter sWriter = new StreamWriter(ns);
                StreamReader sReader = new StreamReader(ns);

                sWriter.WriteLine("u:" + Username);
                sWriter.Flush();

                Thread readThread = new Thread(GetMessages);
                readThread.Start(sReader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetMessages(object obj)
        {
            StreamReader sReader = (StreamReader)obj;

            while (true)
            {
                string message = sReader.ReadLine();

                if (message != null)
                {
                    if (plOutput.InvokeRequired)
                    {
                        plOutput.Invoke(new myDelegat(InternalSafeAppend), new object[] { message });
                    }
                }
            }
        }

        public void InternalSafeAppend(object obj)
        {
            string response = obj.ToString();

            if (response.Length > 0)
            {
                string type = response.Substring(0, 1);
                string message = response.Substring(2);
                int messageMaxWidth = this.Width - 50;

                MessagePanel msgPanel = new MessagePanel(messageMaxWidth);
                msgPanel.MouseEnter += msgPanel_MouseEnter;
                msgPanel.MouseLeave += msgPanel_MouseLeave;

                switch (type)
                {
                    case "u":

                        msgPanel.Message(message + " joined the chat");

                        plOutput.Controls.Add(msgPanel);
                        plOutput.SetFlowBreak(msgPanel, true);
                        scrolldown();
                        txtMessage.Text = null;
                        break;

                    case "m":

                        int pos = message.IndexOf(':');
                        string username = message.Substring(0, pos);

                        Color userColor;

                        if (_userColors.ContainsKey(username))
                        {
                            userColor = _userColors[username];
                        }
                        else
                        {
                            Random rnd = new Random();
                            int num = rnd.Next(_colors.Count);
                            userColor = _colors[num];
                            _userColors[username] = userColor;
                        }

                        message = message.Substring(pos + 1, message.Length - username.Length - 1);

                        msgPanel.Username(username, userColor);
                        msgPanel.Message(message);

                        plOutput.Controls.Add(msgPanel);
                        plOutput.SetFlowBreak(msgPanel, true);
                        scrolldown();
                        txtMessage.Text = null;
                        break;

                }
            }
        }

        void msgPanel_MouseLeave(object sender, EventArgs e)
        {
            MessagePanel panel = (MessagePanel)sender;
            int index = plOutput.Controls.GetChildIndex(panel);

            if (plOutput.Controls.Count > (index + 1))
            {
                string text = plOutput.Controls[index + 1].Text;
                plOutput.Controls[index + 1].Text = new String(' ', 1000) + text;
            }
        }

        void msgPanel_MouseEnter(object sender, EventArgs e)
        {
            MessagePanel panel = (MessagePanel)sender;
            int index = plOutput.Controls.GetChildIndex(panel);

            if (plOutput.Controls.Count > (index + 1))
            {
                string text = plOutput.Controls[index + 1].Text;
                plOutput.Controls[index + 1].Text = text.Trim();
            }
        }

        public delegate void myDelegat(object message);

        public string Username
        {
            set;
            get;
        }

        private void scrolldown()
        {
            Button l_button = new Button();
            plOutput.Controls.Add(l_button);
            plOutput.ScrollControlIntoView(l_button);
            l_button.Visible = false;
        }



        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _sWriter.WriteLine("m:" + Username + ":" + txtMessage.Text);
                _sWriter.Flush();
                txtMessage.Text = null;
            }
            
        }
     }
    }

