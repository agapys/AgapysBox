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
    public class FileObservable
    {
        public FileObservable ()
        {

        }
        public FileObservable (string name, string fullName, DateTime creationDate, DateTime lastUpdate, byte[] fileByteArray)
        {
            Name = name;
            FullName = fullName;
            CreationDate = creationDate;
            LastUpdate = lastUpdate;
            FileByteArray = fileByteArray;
        }
        public DateTime LastUpdate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }

        public string FullName { get; set; }
        public bool Sync { get; set; }
        public UserData LockedUser { get; set; }
        public UserData LastUpdateUser { get; set; }
        public byte[] FileByteArray { get; set; }
    }
}
