using System;
using System.Text.RegularExpressions;
using System.Data;

namespace CLI_Calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Command Line Calculator");
            Console.WriteLine("Input caculiate evaluate");
            while (true)
            {
                ShowPrompt();
                string line = Console.In.ReadLine();

                // Error Invalid Strings 
                if (Regex.IsMatch(line, "[^0-9+\\-*/^\\s()]"))
                {
                    DisplayAnswer("ERROR: Invalid string contains");
                    continue;
                }
                // Error starts/ends with symbols 
                if (Regex.IsMatch(line, "^[+\\-*/^]") || Regex.IsMatch(line, "[+\\-*/^]$"))
                {
                    DisplayAnswer("ERROR: Could not start/end by symbol.");
                    continue;
                }
            
                string answer = Convert.ToString(Convert.ToDouble(new DataTable().Compute(line, null)));
                DisplayAnswer(answer);
            }
        }

        private static void ShowPrompt()
        {
            Console.WriteLine(": ");
        }

        private static void DisplayAnswer(String value)
        {
            Console.WriteLine("> " +value);
        }
    }
}