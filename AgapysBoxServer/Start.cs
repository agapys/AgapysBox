using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace AgapysBoxServer
{
    public class Start
    {
        public static void Main(string[] args)
        {
            
            var wssv = new WebSocketServer(8888);
            wssv.AddWebSocketService<Server>("/send-file");
            wssv.Start();
            while (true)
            {
                Thread.Sleep(10000);
            }
            
            // Console.WriteLine(args.Length);
            // Console.ReadKey(true);

        }
    }
}
