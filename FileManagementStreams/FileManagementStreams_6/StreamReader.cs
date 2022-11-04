using System;
using System.Collections.Generic;
using System.IO;

namespace FileManagementStreams_6
{
    class Program
    {
        public static void Main()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Input", "new-users.csv");

            try
            {
                using (StreamReader stmr = new StreamReader(path))
                {
                    var header = stmr.ReadLine()?.Split(',');

                    while (true)
                    {
                        var register = stmr.ReadLine()?.Split(',');

                        if (register == null)
                        {
                            break;
                        }

                        for (int i = 0; i < register.Length; i++)
                        {
                            Console.WriteLine($"{header?[i]}: {register[i]}");
                        }

                        Console.WriteLine("---------------------");
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            CreateCsv();
        }

        static void CreateCsv()
        {
            //using new path
            var path = Path.Combine(Environment.CurrentDirectory, "Output");

            var persons = new List<Person>()
            {
                new Person()
                {
                    Name = "João Santos",
                    Email = "jsantos@gmail.com",
                    Phone = 99565654,
                    BirthDate = new DateTime(1990,10,5)
                },
                new Person()
                {
                    Name = "Ramildo Santos",
                    Email = "rsantos@gmail.com",
                    Phone = 99555499,
                    BirthDate = new DateTime(1975,8,12)
                },
                new Person()
                {
                    Name = "João Silveira",
                    Email = "jsilveira@gmail.com",
                    Phone = 99115654,
                    BirthDate = new DateTime(1950,8,5)
                },
            };

            var dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                path = Path.Combine(path, "created-users.csv");
            }

            //write header
            var stmw = new StreamWriter(path);

            stmw.WriteLine("Name, Email, Phone, Birth Date");

            foreach (var person in persons)
            {
                var line = $"{person.Name}, {person.Email}, {person.Phone}, {person.BirthDate}";

                stmw.WriteLine(line);
            }

            stmw.Flush();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}