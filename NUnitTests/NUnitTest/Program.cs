using System;
using System.Collections.Generic;

namespace NUnitTest
{
    public class Program
    {
        public string Login(string UserId, string Password)
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
            {
                return "Userid or password could not be Empty.";
            }
            else
            {
                if (UserId == "Admin" && Password == "Admin")
                {
                    return "Welcome Admin.";
                }
                return "Incorrect UserId or Password.";
            }
        }
        public List<EmployeeDetails> AllUsers()
        {
            List<EmployeeDetails> li = new List<EmployeeDetails>();
            li.Add(new EmployeeDetails
            {
                id = 100,
                Name = "José",
                Gender = "Male",
                salary = 40000
            });
            li.Add(new EmployeeDetails
            {
                id = 101,
                Name = "Juana",
                Gender = "Female",
                salary = 50000
            });
            li.Add(new EmployeeDetails
            {
                id = 103,
                Name = "Carol",
                Gender = "Male",
                salary = 40000
            });

            return li;
        }

        static void Main(string[] args) {
            
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();

            Console.WriteLine("Starting Tests...");
            
        }
    }
}
