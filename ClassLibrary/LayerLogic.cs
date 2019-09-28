using System;

namespace ClassLibrary
{
    public static class LayerLogic
    {

        public static void DefaultCalc()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 != 0) Console.Write("Fizz ");
                if (i % 3 != 0 && i % 5 == 0) Console.Write("Buzz ");
                if (i % 3 == 0 && i % 5 == 0) Console.Write("FizzBuzz ");
                if (i % 3 != 0 && i % 5 != 0) Console.Write($"{i} ");
            }
        }

        public static void InputFromAndTo(int _from, int to)
        {
            for (int i = _from; i < to; i++)
            {
                if (i % 3 == 0 && i % 5 != 0) Console.Write("Fizz ");
                if (i % 3 != 0 && i % 5 == 0) Console.Write("Buzz ");
                if (i % 3 == 0 && i % 5 == 0) Console.Write("FizzBuzz ");
                if (i % 3 != 0 && i % 5 != 0) Console.Write($"{i} ");
            }
        }

        public static void InputPrimeFactors(int _primefirst, int _primeSecond)
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % _primefirst == 0 && i % _primeSecond != 0) Console.Write("Fizz ");
                if (i % _primefirst != 0 && i % _primeSecond == 0) Console.Write("Buzz ");
                if (i % _primefirst == 0 && i % _primeSecond == 0) Console.Write("FizzBuzz ");
                if (i % _primefirst != 0 && i % _primeSecond != 0) Console.Write($"{i} ");
            }
        }

        public static bool IsPrime(int _primeCheck)
        {
            if(_primeCheck < 1) return false;

            for (var i = 2u; i < _primeCheck; i++)
            {
                if (_primeCheck % i == 0) return false;
            }

            return true;
        }
    }
}
