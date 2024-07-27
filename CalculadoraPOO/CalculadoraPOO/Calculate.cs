using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPOO
{
    internal class Calculate
    {
        public double Mean(List<double> numbers)
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

        public double Median(List<double> numbers)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        CALCULATE MEDIAN         ");
            Console.WriteLine("-------------------------------");
            numbers.Sort();
            int med = numbers.Count / 2;
            return numbers[med];
        }

        public (List<double>, int) Mode(List<double> numbers)
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
                    if (counterNew == counterMost)
                    {
                        modeList.Add(number);
                    }
                }
                else if (number == last)
                {
                    counterNew++;
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
