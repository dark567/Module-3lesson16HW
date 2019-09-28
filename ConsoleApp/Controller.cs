using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ClassLibrary;

namespace ConsoleApp
{
    public static class Controller
    {
        /// <summary>
        /// Menu Item
        /// </summary>
        public enum MenuItem
        {
            [Description("\n Please choose one of this options:")]
            None = 0,
            [Description("\t [1] Default calc 1..100 (3&5)")]
            DefaultCalc = 1,
            [Description("\t [2] User input From and To")]
            InputFromAndTo = 2,
            [Description("\t [3] User introduces prime factors")]
            InputPrimeFactors = 3,
            [Description("\t [4] Default Async calc 1..100 (3&5)")]
            Todo1 = 4,
            [Description("\t [5] todo 2")]
            Todo2 = 5,
            [Description("\t [5] todo 3")]
            Todo3 = 6,
            [Description("\t [6] Quit")]
            Quit = 7
        }

        /// <summary>
        /// GetDescription Enum
        /// extension method (this Enum value)
        /// </summary>
        /// <param name="value">Enum type</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = (DescriptionAttribute)value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DescriptionAttribute)
                .FirstOrDefault();

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }

        public static void ShowMenuInConsole()
        {
            foreach (MenuItem item in Enum.GetValues(typeof(MenuItem)))
            {
                if (item == 0) Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuNameColor;
                else Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.MenuItems;
                Console.WriteLine(item.GetDescription());
            }
        }

        /// <summary>
        /// Job with menu
        /// </summary>
        public static void JobWithMenu()
        {

            bool mQuit = false;
            int choiceNomMenu = 0;

            Controller.ShowMenuInConsole();

            while (!mQuit)
            {

                if (!Int32.TryParse(Console.ReadLine(), out choiceNomMenu) || !(choiceNomMenu >= 1 && choiceNomMenu <= 7))
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColors.EnumConsoleColors.ErrorOrOther;
                    Console.WriteLine("\t Invalid input. Try again:");
                    ShowMenuInConsole();
                    continue;
                }

                switch (choiceNomMenu)
                {
                    case (int)MenuItem.DefaultCalc:

                        LayerLogic.DefaultCalc();

                        ShowMenuInConsole();
                        break;
                    case (int)MenuItem.InputFromAndTo:

                        bool prInputFromAndTo = false;
                        int _from, _to;
                        do
                        {
                            Console.Write("Input From:");
                            prInputFromAndTo = int.TryParse(Console.ReadLine(), out _from) && _from >= 1;

                        } while (!prInputFromAndTo);

                        do
                        {
                            Console.Write("Input To:");
                            prInputFromAndTo = int.TryParse(Console.ReadLine(), out _to) && _to > _from;

                        } while (!prInputFromAndTo);
                        LayerLogic.InputFromAndTo(_from, _to);

                        ShowMenuInConsole();
                        break;
                    case (int)MenuItem.InputPrimeFactors:

                        bool prInputPrimeFactors = false;
                        int _primeFirst, _primeSecond;
                        do
                        {
                            Console.Write("Input PrimeFirst[Fizz]:");
                            prInputPrimeFactors = int.TryParse(Console.ReadLine(), out _primeFirst) && LayerLogic.IsPrime(_primeFirst);

                        } while (!prInputPrimeFactors);

                        do
                        {
                            Console.Write("Input PrimeSecond[Buzz]:");
                            prInputPrimeFactors = int.TryParse(Console.ReadLine(), out _primeSecond) && LayerLogic.IsPrime(_primeSecond); ;

                        } while (!prInputPrimeFactors);

                        LayerLogic.InputPrimeFactors(_primeFirst, _primeSecond);

                        ShowMenuInConsole();
                        break;
                    case (int)MenuItem.Todo1:

                        Stopwatch watch = new Stopwatch();
                        

                        var singlton = Singleton.GetInstance;

                        // var c = singlton.Sum(2, 2);

                        singlton.InitArray();
                        watch.Start();
                        var c = singlton.DefaultCalc(/*2, 2*/);
                        watch.Stop();

                        singlton.ShowArray();

                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine($"Result:{c.Result}, watch.Elapsed.TotalSeconds:{watch.Elapsed.TotalSeconds}");
                        ShowMenuInConsole();
                        break;
                    case (int)MenuItem.Todo2:

                        ShowMenuInConsole();
                        break;
                    case (int)MenuItem.Todo3:

                        ShowMenuInConsole();
                        break;

                    case (int)MenuItem.Quit:

                        Console.WriteLine("\t Quitting...");
                        mQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public static class ConsoleColors
    {
        public enum EnumConsoleColors
        {
            MenuNameColor = ConsoleColor.DarkYellow,
            MenuItems = ConsoleColor.Cyan,
            Info = ConsoleColor.Green,
            ErrorOrOther = ConsoleColor.Red
        }
    }
}
