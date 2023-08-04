using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
namespace Multi_Connection_1B
{
    //Sender
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sender";
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect("127.0.0.1",5555);
            s.Close();
            s.Dispose();

            Console.ReadKey();
        }
    }
}
