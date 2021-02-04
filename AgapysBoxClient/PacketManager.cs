using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace AgapysBoxClient
{
    public class PacketManager
    {
        public string DirName { get; set; }

        public WebSocket Ws { get; set; }

        public PacketManager(string dirName)
        {
            DirName = dirName;
        }

        public void Process(byte[] packetArray)
        {
            Packet packet = Packet.ToObject<Packet>(packetArray);

            switch (packet.PacketType) {
                case PacketType.Authorization:
                    break;
                case PacketType.FileLock:
                    break;
                case PacketType.ClientToServerFileSync:
                    var msg = packet.GetObject<FileObservable>();
                    File.WriteAllBytes(DirName + "/" + msg.Name, msg.FileByteArray); // Requires System.IO
                    Console.WriteLine("Server Says: " + msg.FullName);

                    break;
                case PacketType.ServerToClientFileSync:
                    break;
                default:
                    break;
            }
        }
        public void Send(Packet packet)
        {
            Ws.Send(packet.ToByteArray());
        }
    }
}
