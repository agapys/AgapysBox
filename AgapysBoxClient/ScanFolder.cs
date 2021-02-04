using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace AgapysBoxCore
{
    public class ScanFolder
    {
        private string DirName { get; set; }
        private List<FileObservable> Files { get; set; }

        public Client WebClient { get; set; }
        public ScanFolder (string dirName)
        {
            DirName = dirName;
            Files = new List<FileObservable>();
            WebClient = new Client(DirName);
            Scan();
        }

        private bool KnowFile(string fullName)
        {
            return Files.Any(readFile => readFile.FullName == fullName);
        }

        private void RecursiveScan (string DirName)
        {
            try
            {
                foreach (string dirName in Directory.GetDirectories(DirName))
                {
                    ReadFolder(dirName);
                    RecursiveScan(dirName);
                }
                ReadFolder(DirName);
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private void ReadFolder (string dirName)
        {
            foreach (string fileName in Directory.GetFiles(dirName))
            {
                ReadFiles(fileName);
            }
        }

        private void ReadFiles (string fileName)
        {
            DateTime lastUpdate = File.GetLastWriteTime(fileName);
            DateTime creationDate = File.GetCreationTime(fileName);
            string name = Path.GetFileName(fileName);
            string fullName = fileName.Replace("\\", "/");

            FileObservable fileObservable;
            if (KnowFile(fullName))
            {
                fileObservable = Files.Find((file) => file.FullName == fullName);
                byte[] fileByteArray = File.ReadAllBytes(fullName);
                fileObservable.FileByteArray = fileByteArray;
            }
            else
            {
                byte[] fileByteArray = File.ReadAllBytes(fullName);
                fileObservable = new FileObservable(name, fullName, creationDate, lastUpdate, fileByteArray);
                Files.Add(fileObservable);
            }

            Packet packet = new Packet();
            packet.PacketType = PacketType.ClientToServerFileSync;
            packet.Value = fileObservable;
            WebClient.Send(packet);

            // Console.WriteLine("Arquivo lido: " + fileObservable.FullName);
        }


        private void Scan()
        {
            if (Directory.Exists(DirName))
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Escaniando...");
                        RecursiveScan(DirName);
                        Console.WriteLine("Arquivos indexados: " + Files.Count);
                        Thread.Sleep(10_000);
                    }
                }).Start();
            } else
            {
                Console.WriteLine("Erro: Diretório não encontrado!");
            }
        }


    }
}
