using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPOO
{
    internal class ListManager
    {
        public int AskNumber(bool acceptsZero, int i = -1)
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
                    else Console.WriteLine("-----CREATE A LIST-----");
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
                    else Console.WriteLine("-----CREATE A LIST-----");
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
                    else Console.WriteLine("-----CREATE A LIST-----");
                }
            } while (true);
        }

        public List<double> FillList(int numbers)
        {
            List<double> numberList = new List<double>();
            Console.Clear();
            Console.WriteLine("-----FILL LIST-----");
            int newNumber;
            for (int i = 0; i < numbers; i++)
            {
                do
                {
                    Console.Write($"\n Enter #{i + 1}: ");
                    newNumber = AskNumber(true, i);
                } while (newNumber == -1);

                numberList.Add(newNumber);
            }
            return numberList;
        }
        public void ShowList(List<double> numberList)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("         CURRENT LIST          ");
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your current List is: ");
            foreach (double number in numberList)
            {
                Console.WriteLine($"{number}");
            }
            Console.ForegroundColor= ConsoleColor.White;
        }

        public string Menu()
        {
            do
            {
                try
                {
                    Console.Clear();
                    string option;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-----Statistical calculator-----");
                    Console.WriteLine("\n         1. Enter list");
                    Console.WriteLine("         2. Calculate Mean");
                    Console.WriteLine("         3. Calculate Median");
                    Console.WriteLine("         4. Calculate Mode");
                    Console.WriteLine("         5. Show List");
                    Console.WriteLine("         6. Exit");
                    Console.Write("\n CHOOSE AN OPTION: ");
                    Console.ForegroundColor  = ConsoleColor.White;
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
    }
}
