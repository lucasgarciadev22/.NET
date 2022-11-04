using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementStreams_2
{
    class MoveCopy
    {
        static void Main(string[] args)
        {
            //------------------------ another example ----------------------------------------------

            var pathGlobe = Path.Combine(Environment.CurrentDirectory, "globe");

            CreateGlobalDirectories();

            var pathCountry = Path.Combine(Environment.CurrentDirectory, "Brasil.txt");

            CreateCountryFile();

            var moveToPath = Path.Combine(Environment.CurrentDirectory, "globe", "South America", "Brasil", "Brasil.txt");

            var copyToPath = Path.Combine(Environment.CurrentDirectory, "globe", "South America", "Brasil", "Brasil.txt");

            MoveCountryFile();
            CopyCountryFile();
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
                        return;
                    }

                    File.Move(pathCountry, moveToPath);
                    return;
                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while moving the file  " + ex);
                    return;
                }
            }

            void CopyCountryFile()
            {
                try
                {
                    if (!File.Exists(pathCountry))
                    {
                        Console.WriteLine("File does'nt exist in this path  ");
                    }

                    if (File.Exists(copyToPath))
                    {
                        Console.WriteLine("File already exists in this path...Renaming  ");
                        copyToPath = Path.Combine(Environment.CurrentDirectory, "globe", "South America", "Brasil", "Brasil_Copy.txt");
                        File.Copy(pathCountry,copyToPath);
                        return;
                    }

                    File.Copy(pathCountry, copyToPath);
                    return;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while moving the file  " + ex);
                    return;
                }



            }

            void CreateCountryFile()
            {
                try
                {
                    //if (!File.Exists(pathCountry))
                    //{
                    //    File.Create(pathCountry);
                    //}
                    var streamWriter = File.CreateText(pathCountry);

                    streamWriter.WriteLine("Population: 215M");
                    streamWriter.WriteLine("IDH: 0.85");
                    streamWriter.WriteLine("Last Data Update: 20/05/2021");

                    streamWriter.Flush();
                    streamWriter.Dispose();
                    streamWriter.Close();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while writing in file Brasil.txt  " + ex);
                    return;
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
                      

                        return;

                        
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error while creating directory  " + ex); ;
                    return;
                }
            }
        }
    }
}
