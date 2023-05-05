using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_https_emulator
{
    public partial class Server : Form
    {
        TcpListener listener;
        List<TcpClient> clients;
        string signature = "Quan";

        public Server()
        {
            InitializeComponent();
            EstablishTCPConnections();
        }
        private void AcceptClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    AddMessageToLog("Client connected.");
                    clients.Add(client);
                    Task.Run(() => HandleClient(client));
                }
                catch (Exception ex)
                {
                    AddMessageToLog("Error accepting client: " + ex.Message);
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int b = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, b);
                    if(message == "cert?")
                    {
                        SendCertificate(client);
                    }
                    AddMessageToLog(message);
                }
                catch (Exception ex)
                {
                    AddMessageToLog("Error handling client: " + ex.Message);
                    clients.Remove(client);
                    break;
                }
            }
        }

        private void SendMessage(string message, TcpClient client)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message + "\r\n");
            NetworkStream stream = client.GetStream();
            stream.Write(bytes, 0, bytes.Length);
        }

        private void AddMessageToLog(string message)
        {
            if (tbx_log.InvokeRequired)
            {
                tbx_log.Invoke(new Action<string>(AddMessageToLog), message);
                return;
            }
            tbx_log.AppendText(message + Environment.NewLine);
        }

        private void EstablishTCPConnections()
        {
            clients = new List<TcpClient>();
            try
            {
                listener = new TcpListener(IPAddress.Any, int.Parse("443"));
                listener.Start();
                AddMessageToLog("Server started.");
                Task.Run(() => AcceptClients());
            }
            catch (Exception ex)
            {
                AddMessageToLog("Error starting server: " + ex.Message);
            }
        }

        private void SendCertificate(TcpClient client)
        {
            SendMessage(signature, client);
        }

        private void KeyExchange()
        {

        }

        private void TransmitEncryptedData()
        {

        }
    }
}
