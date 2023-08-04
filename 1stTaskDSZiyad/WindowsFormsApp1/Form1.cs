using Multi_Connection_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using _1stTaskDS;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Listener listener;
        
        public Form1()
        {
            InitializeComponent();
            listener = new Listener(5555);
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);
            Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listener.start();
        }
        void listener_SocketAccepted(System.Net.Sockets.Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);

            Invoke((MethodInvoker)delegate 
            {
                ListViewItem i = new ListViewItem();
                i.Text = client.EndPoint.ToString();
                i.SubItems.Add(client.ID);
                i.SubItems.Add("XX");
                i.SubItems.Add("XX");
                i.Tag = client;
                lstClients.Items.Add(i);


            });
        }

        private void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate 
            {
                for (int i = 0; i <lstClients.Items.Count ; i++)
                {
                    Client client = lstClients.Items[i].Tag as Client;

                    if (client.ID == sender.ID)
                    {
                        lstClients.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }

        void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lstClients.Items.Count; i++)
                {
                    Client client = lstClients.Items[i].Tag as Client;
                    
                        lstClients.Items[i].SubItems[2].Text = Encoding.Default.GetString(data);
                        lstClients.Items[i].SubItems[3].Text = DateTime.Now.ToString();

                    
                }
            });
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
