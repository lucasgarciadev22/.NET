using System;
using System.IO;
using System.Text;

namespace FileManagementStreams_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCharacters();
            ReadCharactersAgain();
        }

        static async void ReadCharacters()
        {
            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("Characters in 1st line to read");
            stringToRead.AppendLine("and 2nd line");
            stringToRead.AppendLine("and the end");

            using (StringReader reader = new StringReader(stringToRead.ToString()))
            {
                //var buffer = new char[10];

                //var pos = reader.Read(buffer, buffer[0], 0);

                //var size = reader.Read(buffer, 0, 0);

                //do
                //{
                //size = await reader.ReadAsync(buffer, 0, 0);

                string readText = await reader.ReadToEndAsync();

                Console.WriteLine(string.Join("", readText));

                //} while (size <= buffer.Length);
            }
        }

        static void ReadCharactersAgain()
        {
            string text = "This is a text.\n\nThis is also a text.";

            Console.WriteLine($"Original:\n  {text}");

            Console.WriteLine();

            string line, paragraph = null;

            var str = new StringReader(text);

            //remove \n\n
            while (true)
            {
                line = str.ReadLine();

                if (line != null)
                {
                    paragraph += line + " ";
                }
                else
                {
                    paragraph += "\n";
                    break;
                }
            }

            Console.WriteLine($"Modified:\n {paragraph}");
           
            //inser \n\n
            int readedChar;
            char convertedChar;

            var stw = new StringWriter();
            str = new StringReader(paragraph);

            while (true)
            {
                readedChar = str.Read();
                if (readedChar == -1)
                {
                    break;
                }
                convertedChar = Convert.ToChar(readedChar);//convert to asci chars

                if (convertedChar == '.')
                {
                    stw.Write("\n\n");

                    str.Read();
                    str.Read();
                }
                else
                {
                    stw.Write(convertedChar);
                }

            }
                Console.WriteLine($"Stored text in StringWriter:\n {stw.ToString()}");
        }
    }

}