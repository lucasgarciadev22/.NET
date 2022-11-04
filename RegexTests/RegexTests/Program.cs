using System;
using System.Text.RegularExpressions;

namespace RegexTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("The following Regex code will ignore any uppercase or lowercase alphabetic character from this string -->");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" ' IgnoreThisTextOnlyWriteThis->0123456789 ' ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(". . . ");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Output:");

            Console.WriteLine();

            Console.WriteLine();

            // Spilt a string on alphabetic character  
            Console.ForegroundColor = ConsoleColor.Green;

            string azpattern = "[a-z]+";

            string str = " IgnoreThisTextOnlyWriteThis->0123456789";

            string[] rgResult = Regex.Split(str, azpattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));

            for (int i = 0; i < rgResult.Length; i++)
            {
                Console.Write("'{0}'", rgResult[i]);

                if (i < rgResult.Length - 1)

                    Console.Write("");
            }

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("The next code will use Regex to ignore each word starting with 'L' from this string -->  ");

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" ' Life Loves Larry but Hates Harry ' ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(". . . ");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Output:");

            Console.WriteLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;


            // Create a pattern for a word that starts with letter "L"  
            string regexPattern = @"\b[L]\w+";

            // Create a Regex  
            Regex rgResult2 = new Regex(regexPattern);

            //input string
            string words = "Life Loves Larry but Hates Harry";


            MatchCollection matchedWords = rgResult2.Matches(words);

            //write every regexResult2 inside collection matchedWords
            for (int i = 0; i < matchedWords.Count; i++)
            {
                Console.WriteLine(matchedWords[i].Value);
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("The next code will use Regex to replace mutiple empty spacings from this string -->  ");

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" 'This    string    needs     less     space.' ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(". . . ");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Output:");

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            //input string

            string badString = "This    string    needs     less     space.";

            string CleanedString = Regex.Replace(badString, "\\s+", " ");

            //right resulted string into fomrated console line
            Console.WriteLine($"Cleaned String: {CleanedString}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("The next code will use Regex to find and count repeated words from this string -->  ");

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" 'Lucas jump jump off the wall, run to to the side of the sidewalk' ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(". . . ");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Output:");

            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"\b(?<repeatedWord>\w+)\s+(\k<repeatedWord>)\b",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.
            string text = "Lucas jump jump off the wall, run to to the side of the sidewalk .";

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            Console.WriteLine("{0} matches found:\n  ",
                              matches.Count);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                                  groups["repeatedWord"],
                                  groups[0].Index,
                                  groups[1].Index);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
