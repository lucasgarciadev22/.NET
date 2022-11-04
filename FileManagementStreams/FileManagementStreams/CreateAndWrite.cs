using System;
using System.IO;

namespace FileManagementStreams
{
    class CreateAndWrite
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose file's name: ");

            var fileName = Console.ReadLine();

            SanitizeFile();

            var path = Path.Combine(Environment.CurrentDirectory, $"{fileName}.txt"); //using enviroment doesn't need '\\' on string path | using @"dir" need only one '\'

            CreateFiles();

            void SanitizeFile()
            {

                foreach (var @char in Path.GetInvalidFileNameChars()) //treating invalid file names
                {
                    fileName = fileName.Replace(@char, '-');
                }

            }

            void CreateFiles()
            {
                try
                {

                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }

                    var streamWriter = File.CreateText(path);

                    streamWriter.WriteLine("This is a line using created stream writer...");
                    streamWriter.WriteLine("This is a another line using created stream writer...");

                    streamWriter.Flush();//ends stream process
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid file name!  " + ex); ;
                }

            }

            


        }
    }
}
