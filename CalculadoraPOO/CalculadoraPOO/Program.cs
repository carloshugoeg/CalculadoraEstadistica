using CalculadoraPOO;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Transactions;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalculadoraPOO.Calculate calculate = new CalculadoraPOO.Calculate();
            CalculadoraPOO.ListManager listManager = new CalculadoraPOO.ListManager();
            List<double> numberList = new List<double>();
            string option;
            if (numberList.Count == 0)
            {
                Console.WriteLine("-----WELCOME USER-----");
                Console.WriteLine("\nPlease create a list");
                int number = listManager.AskNumber(false);
                numberList = listManager.FillList(number);
            }
            do
            {
                option = listManager.Menu();
                switch (option)
                {
                    case "1":
                        int number = listManager.AskNumber(false);
                        numberList = listManager.FillList(number);
                        break;
                    case "2":
                        double mean = calculate.Mean(numberList);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nThe Mean of this List is {mean}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "3":
                        double median = calculate.Median(numberList);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nThe Median of this List is {median}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "4":
                        (List<double> mode, double counter) = calculate.Mode(numberList);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\nThe Mode of this List is: ");
                        foreach (double topNumber in mode)
                        {
                            Console.Write($"{topNumber}, ");
                        }
                        Console.Write($"with a frecuency of {counter}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "5":

                        listManager.ShowList(numberList);
                        Console.ReadLine();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}