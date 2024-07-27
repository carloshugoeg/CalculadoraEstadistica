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
            List<double> numberList = new List<double>();
            string option;
            if (numberList.Count == 0)
            {
                Console.WriteLine("-----WELCOME USER-----");
                Console.WriteLine("\nPlease create a list");
                int number = AskNumber(false);
                numberList = FillList(number);
            }
            do
            {
                option = Menu();
                switch (option)
                {
                    case "1":
                        int number = AskNumber(false);
                        numberList = FillList(number);
                        break;
                    case "2":
                        double mean = CalculateMean(numberList);
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine($"\nThe Mean of this List is {mean}"); 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "3":
                        double median = CalculateMedian(numberList);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nThe Median of this List is {median}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                    case "4":
                        (List<double> mode, double counter) = CalculateMode(numberList);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\nThe Mode of this List is: ");
                        foreach(double topNumber in mode)
                        {
                            Console.Write($"{topNumber}, ");
                        }
                        Console.Write($"with a frecuency of {counter}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;

                }
            } while (true);

            

            static List<double> FillList(int numbers)
            {
                List<double> numberList = new List<double>();
                Console.Clear();
                Console.WriteLine("-----FILL LIST-----");
                int newNumber;
                for (int i = 0; i < numbers; i++)
                {
                    do {
                        Console.Write($"\n Enter #{i + 1}: ");
                        newNumber = AskNumber(true, i);
                    }while(newNumber == -1);

                    numberList.Add(newNumber);
                }
                return numberList;
            }

            static string Menu()
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        string option;
                        Console.WriteLine("-----Statistical calculator-----");
                        Console.WriteLine("\n         1. Enter list");
                        Console.WriteLine("         2. Calculate Mean");
                        Console.WriteLine("         3. Calculate Median");
                        Console.WriteLine("         4. Calculate Mode");
                        Console.WriteLine("         5. Exit");
                        Console.Write("\n CHOOSE AN OPTION: ");
                        option = Console.ReadLine();
                        if (option == null)
                        {
                            Console.WriteLine("INPUT CANNOT BE NULL. Try Again");
                            Console.ReadLine();
                        }
                        switch (option)
                        {
                            case "1": return option;
                            case "2": return option;
                            case "3": return option;
                            case "4": return option;
                            case "5": return option;

                        }
                        Console.WriteLine("INPUT NOT VALID. Try Again");
                        Console.ReadLine();
                        return "0";
                    }
                    catch (Exception)
                    {
                        throw;
                    } 
                } while (true);
            }

            static int AskNumber(bool acceptsZero, int i = -1)
            {
                do
                {
                    try
                    {
                        int numbers;
                        if (acceptsZero)
                        {
                            numbers = int.Parse(Console.ReadLine());
                            return numbers;
                        }
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nHow many numbers do you want to enter? "); Console.ForegroundColor = ConsoleColor.White;
                            numbers = int.Parse(Console.ReadLine());
                            if (numbers == 0 && !acceptsZero)
                            {
                                Console.WriteLine("Number cannot be 0. Please try again");
                                Console.ReadLine();
                            }
                        } while (numbers == 0 && !acceptsZero);
                        return numbers;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("INVALID INPUT");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        Console.Clear();
                        if (acceptsZero)
                        {
                            Console.WriteLine("-----FILL LIST-----");
                            Console.Write($"\n Enter #{i + 1}: ");

                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("THE NUMBER IS TOO BIG");
                        Console.WriteLine("Your number is OUT OF RANGE the range is between 0 and 999 999");
                        Console.ReadLine();
                        Console.Clear();
                        if (acceptsZero)
                        {
                            Console.WriteLine("-----FILL LIST-----");
                            Console.Write($"\n Enter #{i + 1}: ");

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        Console.Clear();
                        if (acceptsZero)
                        {
                            Console.WriteLine("-----FILL LIST-----");
                            Console.Write($"\n Enter #{i + 1}: ");

                        }
                    }
                } while (true);
            }

            static double CalculateMean(List<double> numbers)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("        CALCULATE MEAN         ");
                Console.WriteLine("-------------------------------");
                double sum = 0;
                int total = numbers.Count;
                foreach (double number in numbers) sum += number;
                return sum / total;
            }
            
            static double CalculateMedian(List<double> numbers)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("        CALCULATE MEDIAN         ");
                Console.WriteLine("-------------------------------");
                numbers.Sort();
                int med = numbers.Count / 2;
                return numbers[med];
            }
            
            static (List<double>, int) CalculateMode(List<double> numbers)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("        CALCULATE MODE         ");
                Console.WriteLine("-------------------------------");
                numbers.Sort();
                List<double> modeList = new List<double>();
                double last = numbers[0];
                int counterMost = 1;
                int counterNew = 0;
                foreach (double number in numbers)
                {
                    if (number != last)
                    {
                        counterNew = 1;
                    }
                    else if (number == last)
                    {
                        counterNew ++;
                        if (counterNew == counterMost)
                        {
                            modeList.Add(number);
                        }
                        else if (counterNew > counterMost)
                        {
                            counterMost = counterNew;
                            modeList.Clear();
                            modeList.Add(number);
                        }
                    }
                    last = number;
                }
                return (modeList, counterMost);
            }
            
        }
	}
}