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
using System.Windows.Forms;

namespace project_https_emulator
{
    public partial class Client : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;

        public Client()
        {
            InitializeComponent();
            EstablishTCPConnection();
        }

        private void ReceiveMessage()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int b = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, b);
                AddMessageToLog(message);
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                AddMessageToLog(ex.Message);
            }
        }

        private void AddMessageToLog(string message)
        {
            if (tbx_mess.InvokeRequired)
            {
                tbx_mess.Invoke(new Action<string>(AddMessageToLog), message);
                return;
            }
            tbx_mess.AppendText(message);
        }

        private void EstablishTCPConnection()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 443);
            tbx_mess.AppendText("Connected\r\n");
            stream = tcpClient.GetStream();
            Task.Run(() => ReceiveMessage());
            CheckCertificate();
        }

        private void CheckCertificate()
        {
            SendMessage("cert?");
        }

        private void KeyExchange()
        {

        }

        private void TransmitEncryptedData()
        {

        }
    }
}
