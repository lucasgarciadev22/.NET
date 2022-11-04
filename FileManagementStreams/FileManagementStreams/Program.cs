using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementStreams
{
    class Program
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

            //------------------------ another example ----------------------------------------------

            var pathGlobe = Path.Combine(Environment.CurrentDirectory, "globe");

            CreateGlobalDirectories();

            var pathCountry = Path.Combine(Environment.CurrentDirectory, "Brasil.txt");

            CreateCountryFile();

            var moveToPath = Path.Combine(Environment.CurrentDirectory, "globe", "South America", "Brasil", "Brasil.txt");

            MoveCountryFile();

            void MoveCountryFile()
            {
                try
                {
                    if (!File.Exists(pathCountry))
                    {
                        Console.WriteLine("File does'nt exist in this path  ");
                    }

                    if (File.Exists(moveToPath))
                    {
                        Console.WriteLine("File already exists in this path  ");
                    }

                    File.Move(pathCountry, moveToPath);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while moving the file  " + ex);
                }



            }

            void CreateCountryFile()
            {
                try
                {

                    if (!File.Exists(pathCountry))
                    {
                        File.Create(pathCountry);

                    }
                        var streamWriter = File.CreateText(pathCountry);

                        streamWriter.WriteLine("Population: 215M");
                        streamWriter.WriteLine("IDH: 0.85");
                        streamWriter.WriteLine("Last Data Update: 20/05/2021");

                        streamWriter.Flush();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while writing in file Brasil.txt  " + ex);
                }

            }

            void CreateGlobalDirectories()
            {

                try
                {
                    if (!Directory.Exists(pathGlobe))
                    {
                        var dirGLobe = Directory.CreateDirectory(pathGlobe);


                        var dirNothAmerica = dirGLobe.CreateSubdirectory("North America");
                        var dirCentralAmerica = dirGLobe.CreateSubdirectory("Central America");
                        var dirSouthAmerica = dirGLobe.CreateSubdirectory("South America");

                        dirNothAmerica.CreateSubdirectory("USA");
                        dirNothAmerica.CreateSubdirectory("Mexico");
                        dirNothAmerica.CreateSubdirectory("Canada");

                        dirCentralAmerica.CreateSubdirectory("Costa Rica");
                        dirCentralAmerica.CreateSubdirectory("Panama");

                        dirSouthAmerica.CreateSubdirectory("Brasil");
                        dirSouthAmerica.CreateSubdirectory("Argentina");
                        dirSouthAmerica.CreateSubdirectory("Paraguai");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while creating directory  " + ex); ;
                }
            }


        }
    }
}
