using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Socket sck;
        public Form2()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            sck.Connect("127.0.0.1", 5555);
            MessageBox.Show("Connected");

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int s = sck.Send(Encoding.Default.GetBytes(txtMsg.Text));
            if (s > 0)
            {
                MessageBox.Show("Data Sent");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sck.Close();
            sck.Dispose();
            Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
