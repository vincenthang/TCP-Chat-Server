using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GroupChatServer
{
    class Program
    {
        protected static List<TcpClient> _clients = new List<TcpClient>();
        protected static object _clientListLock = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Server started.");

            TcpListener listener = new TcpListener(IPAddress.Any, 9000);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                _clients.Add(client);

                Console.WriteLine("Client connected");

                NetworkStream ns = client.GetStream();
                StreamReader reader = new StreamReader(ns);

                Thread thBroadcast = new Thread(Broadcast);
                thBroadcast.Start(new object[] { client, reader });
            }
        }

        public static void Broadcast(object obj)
        {
            object[] data = (object[])obj;

            TcpClient tcpClient = (TcpClient)data[0];
            StreamReader reader = (StreamReader)data[1];

            while (true)
            {
                try
                {
                    if (tcpClient.Connected)
                    {
                        string msg = reader.ReadLine();

                        foreach (TcpClient client in _clients)
                        {
                            if (client != null && client.Connected)
                            {
                                NetworkStream ns = client.GetStream();
                                StreamWriter writer = new StreamWriter(ns);
                                writer.WriteLine(msg);
                                writer.Flush();
                            }
                            else
                            {
                                lock (_clientListLock)
                                {
                                    _clients.Remove(client);
                                    Console.WriteLine("Client disconnected");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
