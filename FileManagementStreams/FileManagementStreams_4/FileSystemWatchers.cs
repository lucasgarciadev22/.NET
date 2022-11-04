using System;
using System.IO;

namespace FileManagementStreams_4
{
    class FileSystemWatchers
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "globe");

            Console.WriteLine("Watching your files in globe directory...");

            FileSystemWatcher fsw = new FileSystemWatcher(path);

            fsw.Created += OnCreated;
            fsw.Renamed += OnRenamed;
            fsw.Deleted += OnDeleted;

            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;

            void OnCreated(object sender, FileSystemEventArgs e) //formating in event wpf format
            {
                Console.WriteLine($"File {e.Name} was created...");
            }

            void OnRenamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine($"File {e.OldName} was renamed, the new file name is {e.Name} ");
            }

            void OnDeleted(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine($"File {e.Name} was deleted...");
            }



        }
    }
}
