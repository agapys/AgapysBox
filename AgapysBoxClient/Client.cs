using AgapysBoxClient;
using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace AgapysBoxCore
{
    public class Client : PacketManager
    {
        public string DirName { get; set; }
        public Client (string dirName) : base(dirName)
        {
            Ws = new WebSocket("ws://192.168.0.14:8888/send-file");
            DirName = dirName;

            Ws.OnMessage += ((sender, e) => {
                Process(e.RawData);
                
            });
            Ws.Connect();
        }
    }
}
