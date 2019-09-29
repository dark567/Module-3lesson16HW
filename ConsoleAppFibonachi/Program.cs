using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputValue;
            do
            {
                Console.Write("Input x:");
            } while (!long.TryParse(Console.ReadLine(), out inputValue));

            Stopwatch watchDefault = new Stopwatch();
            var singlton = Singleton.GetInstance;
            watchDefault.Start();
            var resultDefault = singlton.GetSumOfRandomValuesAsync(inputValue: inputValue);
            Console.WriteLine("Fibonacci(" + inputValue + ") = " + resultDefault.Result + "\n");
            watchDefault.Stop();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Result:{resultDefault.Result}, watch.Elapsed.TotalSeconds:{watchDefault.Elapsed.TotalSeconds}");

            Console.ReadLine();
        }
   }
}
