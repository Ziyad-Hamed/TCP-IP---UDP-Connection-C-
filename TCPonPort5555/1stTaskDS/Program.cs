using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace Multi_Connection_1
{
    //Sender
    class Program
    {
        
        static Listener l;
        static List<Socket> sockets;

        static void Main(string[] args)
        {
            Console.Title = "Reciver";
            l = new Listener(5555);
            l.SocketAccepted += new Listener.SocketAcceptedHandler(l_SocketAccepted);
            l.start();
            sockets = new List<Socket>();

            Console.Read();
            Console.ReadKey();
        }
        static void l_SocketAccepted (System.Net.Sockets.Socket e)
        {
            Console.WriteLine("New Connection From IP >>>: {0} <<<On Port \n On Date >>> :{1}\n=========", e.RemoteEndPoint, DateTime.Now);
            sockets.Add(e);

        }
    }
}
