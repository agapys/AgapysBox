using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace AgapysBoxServer
{
    public class PacketManager : WebSocketBehavior
    {
        public string Path { get; set; }

        public PacketManager()
        {
            Path = "c:/temp/clone/";
        }
        public PacketManager(string dirName)
        {
            Path = dirName;
        }

        public void Process(byte[] packetArray)
        {
            Packet packet = Packet.ToObject<Packet>(packetArray);

            switch (packet.PacketType)
            {
                case PacketType.Authorization:
                    break;
                case PacketType.FileLock:
                    break;
                case PacketType.ClientToServerFileSync:
                    var msg = packet.GetObject<FileObservable>();
                    File.WriteAllBytes(Path + msg.Name, msg.FileByteArray);
                    Sessions.Broadcast(packetArray);
                    // Send("enviado do servidor: " + msg.FullName);
                    break;
                case PacketType.ServerToClientFileSync:
                    break;
                default:
                    break;
            }
        }

        public void SendAll(Packet packet)
        {
            Sessions.Broadcast(packet.ToByteArray());
        }

        public void SendSession(Packet packet)
        {
            Send(packet.ToByteArray());
        }
    }
}
