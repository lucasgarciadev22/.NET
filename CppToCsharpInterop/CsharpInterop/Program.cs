using System;
using System.Runtime.InteropServices;

namespace CsharpInterop
{
    class Program
    {
        public const string ImportCppFunctionsDll = ("CPPFUNCTIONSDLL.dll");

        [DllImport(ImportCppFunctionsDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int firstNum, int secondNum);

        [DllImport(ImportCppFunctionsDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sub(int firstNum, int secondNum);

        static void Main(string[] args)
        {
            int inputFirstNum, inputSecondNum, operation;

            Console.WriteLine("Enter first int number: ");

            if (!int.TryParse(Console.ReadLine(), out inputFirstNum))
            {
                Console.WriteLine("Please, enter a valid number!");
            }

            Console.WriteLine("Enter second int number: ");

            if (!int.TryParse(Console.ReadLine(), out inputSecondNum))
            {
                Console.WriteLine("Please, enter a valid number!");
            }

            Console.WriteLine("Choose the operation: 1 - Sum   |  2 - Subtract");

            if (!int.TryParse(Console.ReadLine(), out operation))
            {
                Console.WriteLine("Please, choose between 1 or 2!");
            }

            int operationResult = 0;

            switch (operation)
            {
                case 1:

                    operationResult = Add(inputFirstNum, inputSecondNum);
                    break;

                case 2:

                    operationResult = Sub(inputFirstNum, inputSecondNum);
                    break;

                default:
                    break;
            }
            string showOperation = operation == 1 ? $"Sum => {inputFirstNum} + {inputSecondNum}" : $"Subtract => {inputFirstNum} + {inputSecondNum}";
            Console.WriteLine($"The result for {showOperation} is {operationResult} ");

        }
    }
}
