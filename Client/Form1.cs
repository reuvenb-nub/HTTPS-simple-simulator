using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
// using System.IO;
namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        List<KeyValuePair<string, int>> serverIP_PortList = new List<KeyValuePair<string, int>>();
        NetworkStream stream;
        int already_TCPconnected_flag = 0, already_print_flag = 0;
        public Form1()
        {
            InitializeComponent();
            RawButton.Enabled = false;
            PreviewButton.Enabled = false;
            webBrowser.Visible = false;
        }
        private void print_message(string message)
        {
            if (RespHeadTextBox.InvokeRequired)
            {
                RespHeadTextBox.Invoke(new Action<string>(print_message), message);
                return;
            }
            string[] resp_items = message.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            RespHeadTextBox.Text = "";
            BodyTextBox.Text = "";
            RespHeadTextBox.AppendText(resp_items[0] + Environment.NewLine);
            BodyTextBox.AppendText(resp_items[1] + Environment.NewLine);

            RawButton.Enabled = true;
            PreviewButton.Enabled = true;
            webBrowser.DocumentText = BodyTextBox.Text;
        }
        private void print_status(string message)
        {
            if ( statusLabel.InvokeRequired)
            {
                statusLabel.Invoke(new Action<string>(print_status), message);
                return;
            }
            string resp_line = message.Substring(0, message.IndexOf("\r\n"));
            string[] resp_line_items = resp_line.Split(' ');
            statusLabel.Text = "";
            for (int i = 1; i < resp_line_items.Length; i++)
            {
                statusLabel.Text += resp_line_items[i] + " ";
            }
        }
        private void ReceiveMessage()
        {
            stream = tcpClient.GetStream();
            string response = "";
            byte[] buffer = new byte[1024];
            while (true)
            {
                // receive response from server
                int b = stream.Read(buffer, 0, buffer.Length);

                // convert response from byte to string
                response = Encoding.ASCII.GetString(buffer, 0, b);
                MessageBox.Show(response);
                // Print the response to the sceen
                if (0 == 0)
                {
                    print_message(response);
                    print_status(response);
                    //already_print_flag = 1;
                }
                else
                {
                    break; // đã print ra thì thoát
                }
                stream.Flush();
            }                
        }

        private void SendMessage(string resource)
        {
            try
            {
                string reqHeader = "";

                // body in case of POST, PUT
                string reqBody = "";
                string request = "";
                switch (MethodComboBox.Text)
                {
                    case "GET":
                        {
                            reqHeader = "GET /" + resource + " HTTP/1.1\r\n" // request line
                            // request headers
                               + "Host: " + ServIPTextBox.Text + "\r\n"
                               + "Connection: keep-alive \r\n"
                               + "Upgrade-Insecure-Requests: 1\r\n"
                               + "User-Agent: C# client\r\n"
                               + "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7\r\n"
                               + "Accept-Encoding: gzip, deflate\r\n"
                               + "Accept-Language: en-US,en;q=0.9\r\n"
                               + "\r\n"
                            ;
                            request = reqHeader;
                            MessageBox.Show(reqHeader);
                        }
                    break;
                    case "DELETE":
                        {
                            reqHeader = "DELETE /" + resource + " HTTP/1.1\r\n" // request line
                             // request headers
                               + "Host: " + ServIPTextBox.Text + "\r\n"
                               + "Connection: keep-alive \r\n"
                               + "Upgrade-Insecure-Requests: 1\r\n"
                               + "User-Agent: C# client\r\n"
                               + "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7\r\n"
                               + "Accept-Encoding: gzip, deflate\r\n"
                               + "Accept-Language: en-US,en;q=0.9\r\n"
                               + "\r\n"
                            ;
                            request = reqHeader;
                            MessageBox.Show(reqHeader);
                        }
                        break;
                    case "POST":
                        {
                            reqBody = "{\r\n  "
                                        + KeyTextBox.Text + ": " + ValueTextBox.Text + "\r\n"
                                        + "}\r\n";
                            // Header
                            reqHeader = "POST /" + resource + " HTTP/1.1\r\n" // request line
                               // request headers
                               + "Host: " + ServIPTextBox.Text + "\r\n"
                               + "Content-type: application/json\r\n"
                               + "Content-length: " + reqBody.Length + "\r\n"
                               + "Connection: keep-alive \r\n"
                               + "Upgrade-Insecure-Requests: 1\r\n"
                               + "User-Agent: C# client\r\n"
                               + "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7\r\n"
                               + "Accept-Encoding: gzip, deflate\r\n"
                               + "Accept-Language: en-US,en;q=0.9\r\n"
                               + "\r\n"
                            ;
                            request = reqHeader + reqBody;
                            MessageBox.Show(request);
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("HTTP Method Not Found!");
                        }
                        break;

                }
                // Send the request 
                
                byte[] buffer = Encoding.ASCII.GetBytes(request);
                stream.Write(buffer, 0, buffer.Length);

                stream.Flush();
            }
            catch (Exception ex)
            {
                // AddMessageToLog(ex.Message);
            }
        }
        private void EstablishTCPConnection()
        {
            try
            {
                already_TCPconnected_flag = 0;

                
                KeyValuePair<string, int> endpoint = new KeyValuePair<string, int>(ServIPTextBox.Text, Int32.Parse(ServPortTextBox.Text));
                if (serverIP_PortList == null) // first time start the connection
                {
                    // Create tcp client
                    tcpClient = new TcpClient();

                    // connect to the server socket
                    serverIP_PortList.Add(new KeyValuePair<string, int>(ServIPTextBox.Text, Int32.Parse(ServPortTextBox.Text)));
                    tcpClient.Connect(ServIPTextBox.Text, Int32.Parse(ServPortTextBox.Text));
                    stream = tcpClient.GetStream();
                    MessageBox.Show("Connected");
                }
                else // Check whether connection is existed
                {
                    foreach (var element in serverIP_PortList)
                    {
                        if (endpoint.Key == element.Key && endpoint.Value == element.Value)
                        {
                            already_TCPconnected_flag = 1;
                            break;
                        }
                    }
                    if (already_TCPconnected_flag == 0)
                    {
                        // Create tcp client
                        tcpClient = new TcpClient();

                        // connect to the server socket
                        serverIP_PortList.Add(new KeyValuePair<string, int>(ServIPTextBox.Text, Int32.Parse(ServPortTextBox.Text)));
                        tcpClient.Connect(ServIPTextBox.Text, Int32.Parse(ServPortTextBox.Text));
                        stream = tcpClient.GetStream();
                        already_print_flag = 0;
                        MessageBox.Show("Connected");
                    }
                    
                }                             
                
                Task.Run(() => ReceiveMessage());

                // Replacement
                /*Thread ctThread = new Thread(ReceiveMessage);
                ctThread.Start();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // CheckCertificate();
        }

        private void MethodComboBox_TextChanged(object sender, EventArgs e)
        {
            if (MethodComboBox.Text == "POST")
            {
                ValueTextBox.Visible = true;
                ValueLabel.Visible = true;
                KeyTextBox.Visible = true;
                KeyLabel.Visible = true;
                SendButton.Location = new Point(168, 331);
            }
            if (MethodComboBox.Text == "GET")
            {
                ValueTextBox.Visible = false;
                ValueLabel.Visible = false;
                KeyTextBox.Visible = false;
                KeyLabel.Visible = false;
                SendButton.Location = new Point(168, 225);
            }
            if (MethodComboBox.Text == "DELETE")
            {
                ValueTextBox.Visible = false;
                ValueLabel.Visible = false;
                KeyTextBox.Visible = false;
                KeyLabel.Visible = false;
                SendButton.Location = new Point(168, 225);
            }
        }

        private void ResourceTextBox_Enter(object sender, EventArgs e)
        {
            
            SuggestLabel.Visible = false;
        }

        private void ResourceTextBox_Leave(object sender, EventArgs e)
        {
            if (ResourceTextBox.Text == "")
            {
                SuggestLabel.Visible = true;
            }
        }

        private void RawButton_Click(object sender, EventArgs e)
        {
            webBrowser.Visible = false;
            BodyTextBox.Visible = true;
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            webBrowser.Visible = true;
            BodyTextBox.Visible = false;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            EstablishTCPConnection();
            SendMessage(ResourceTextBox.Text);
        }
    }
}
