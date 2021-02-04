using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AgapysBoxCore.Entity
{
    [Serializable]
    public class Packet
    {
        public Packet ()
        {

        }
        public PacketType PacketType { get; set; }
        public object Value { get; set; }

        public T GetObject <T>()
        {
            return (T)Value;
        }

        public byte[] ToByteArray()
        {
            if (this == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static T ToObject<T>(byte[] arrBytes)
        {

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(arrBytes))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
