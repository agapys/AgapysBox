using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace AgapysBoxServer
{
    public class Server : PacketManager
    {
        public Server ()
        {
            Path = "c:/temp/clone/";
        }

        public Server (string path)
        {
            Path = path;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Process(e.RawData);
            
            
        }
    }
}
