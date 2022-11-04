using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementStreams_3
{
    class DirFileRead
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "globe");

            ReadDirectories(path);
            Console.WriteLine();
            Console.WriteLine();
            ReadFiles(path);

            void ReadFiles(string filePath)
            {
                var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);// '*' MEANS NO FILTER, YOU CAN PUT FILTERS 

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);

                    Console.WriteLine("Uhul! I have some file infos:");
                    Console.WriteLine();
                    Console.WriteLine($"[Name]: {fileInfo.Name}");
                    Console.WriteLine($"[Size]: {fileInfo.Length} bytes");
                    Console.WriteLine($"[Last Acess]: {fileInfo.LastAccessTime}");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------");

                }
            }

            void ReadDirectories(string dirPath)
            {
                var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories); // '*' MEANS NO FILTER, YOU CAN PUT FILTERS 

                foreach (var dir in directories)
                {
                    var dirInfo = new DirectoryInfo(dir);

                    Console.WriteLine("Uhul! I have some directory infos:");
                    Console.WriteLine();
                    Console.WriteLine($"[Name]: {dirInfo.Name}");
                    Console.WriteLine($"[Root]: {dirInfo.Root}");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------");

                    if (dirInfo.Parent != null)
                    {
                        Console.WriteLine($"[Parent]: {dirInfo.Parent.Name}");
                    }
                }
            }
        }
    }
}
