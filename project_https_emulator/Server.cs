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
        // string signature = "Quan";

        public Server()
        {
            clients = new List<TcpClient>();
            listener = new TcpListener(IPAddress.Any, int.Parse("443"));
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
                    HandleMessage(message, client);
                }
                catch (Exception ex)
                {
                    AddMessageToLog("Error handling client: " + ex.Message);
                    clients.Remove(client);
                    break;
                }
            }
        }

        private void HandleMessage(string message, TcpClient client)
        {
            AddMessageToLog(message);
            string command = message.Substring(0, message.IndexOf("\r\n"));
            string[] cfields = command.Split(" ");
            string request_method = cfields[0];
            string resource = cfields[1];
            string version = cfields[2];

            if (request_method == "GET")
            {
                SendMessage(GETMethod(resource), client);
            }
            else if (request_method == "POST")
            {

            }
            else if (request_method == "DELETE")
            {

            }
        }

        private string GETMethod(string res)
        {
            string filePath = "../resources" + res;
            try
            {
                StreamReader rd = new StreamReader(filePath);
                string payload = rd.ReadToEnd();
                DateTime time = DateTime.Now;
                string header = "HTTP/1.1 200 OK\r\n" + time.ToString() + "\r\n\r\n";
                return header + payload;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                return "HTTP/1.1 404 Not Found\r\n";
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
            try
            {
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
            // SendMessage(signature, client);
        }

        private void KeyExchange()
        {

        }

        private void TransmitEncryptedData()
        {

        }
    }
}
