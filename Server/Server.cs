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
using System.IO;
using Newtonsoft.Json;

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
                SendMessage(POSTMethod(resource, message), client);
            }
            else if (request_method == "DELETE")
            {
                SendMessage(DELETEMethod(resource), client);
            }
        }

        private string GETMethod(string res)
        {
            string filePath = "../resources" + res;
            try
            {
                StreamReader rd = new StreamReader(filePath);
                string payload = rd.ReadToEnd();
                DateTime timestamp = DateTime.Now;
                string info = "Server: C# server\r\n"
                            + "Content-Type: text/html/json; charset=UTF-8\r\n"
                            + "Date: " + timestamp.ToString() + "\r\n"
                            + "Connection: keep-alive\r\n"
                            + "Content-Language: en\r\n";

                string header = "HTTP/1.1 200 OK\r\n" + info + "\r\n";
                return header + payload;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                return "HTTP/1.1 404 Not Found\r\n"
                        + "Content-Type: text/html; charset=UTF-8\r\n"
                        + "Date: " + DateTime.Now.ToString() + "\r\n";
            }
        }

        private string POSTMethod(string res, string message) {
            string filePath = "../resources" + res;
            try
            {
                string body = message.Split("\r\n\r\n")[1].Trim();

                string a = body.Remove(body.Length - 1, 1).Remove(0, 1).Trim();

                string key = "\"" + a.Split(": ")[0] + "\"";
                string value = "\"" + a.Split(": ")[1] + "\"";

                string data = File.ReadAllText(filePath);

                string data_temp = data.Remove(data.Length - 1, 1).Remove(0, 1).Trim();

                string[] data_pair = data_temp.Split(",\r\n");

                foreach (string pair in data_pair) {
                    string temp_key = pair.Split(": ")[0].Trim();
                    string temp_value = pair.Split(": ")[1].Trim();
                    if (temp_key == key) {
                        data = data.Replace(temp_value, value);
                    }
                }
                File.WriteAllText(filePath, data);

                DateTime timestamp = DateTime.Now;
                string info = "Server: C# server\r\n"
                            + "Content-Type: text/html/json; charset=UTF-8\r\n"
                            + "Date: " + timestamp.ToString() + "\r\n"
                            + "Connection: keep-alive\r\n"
                            + "Content-Language: en\r\n";

                string header = "HTTP/1.1 200 OK\r\n" + info + "\r\n";
                return header;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                return "HTTP/1.1 404 Not Found\r\n"
                        + "Content-Type: text/html; charset=UTF-8\r\n"
                        + "Date: " + DateTime.Now.ToString() + "\r\n";
            }
        }

        private string DELETEMethod(string res) {
            string filePath = "../resources" + res;
            try
            {
                File.Delete(filePath);
                string payload = "<html><body><h1>File deleted.</h1></body></html>";
                DateTime timestamp = DateTime.Now;
                string info = "Server: C# server\r\n"
                            + "Content-Type: text/html/json; charset=UTF-8\r\n"
                            + "Date: " + timestamp.ToString() + "\r\n"
                            + "Connection: keep-alive\r\n"
                            + "Content-Language: en\r\n";

                string header = "HTTP/1.1 200 OK\r\n" + info + "\r\n";
                return header + payload;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                return "HTTP/1.1 404 Not Found\r\n"
                        + "Content-Type: text/html; charset=UTF-8\r\n"
                        + "Date: " + DateTime.Now.ToString() + "\r\n";
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
