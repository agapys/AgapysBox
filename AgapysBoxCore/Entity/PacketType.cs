using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgapysBoxCore.Entity
{
    [Serializable]
    public enum PacketType
    {
        Authorization,
        ServerToClientFileSync,
        ClientToServerFileSync,
        FileLock
    }
}
