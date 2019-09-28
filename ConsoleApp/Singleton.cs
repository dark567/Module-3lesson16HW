using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Singleton
    {
        private static Singleton _instance = null;
        private static object _locker = new Object();
        private ArrayList ArrayInt;

        /// <summary>
        /// thread-safe synglton
        /// </summary>
        public static Singleton GetInstance
        {
            get
            {
                //lock (_locker)
                //{
                //    if (_instance == null) _instance = new Singleton();
                //}
                //return _instance;

                lock (_locker)
                {
                    return _instance ?? (_instance = new Singleton());
                }
            }
        }

        public async Task<int> Calc(int from = 1, int to = 100, int primeFirst = 3, int primeSecond = 5)
        {
            //var sum = a + b;
            InitArray(from, to);
            var task = ChangeArrayList(primeFirst, primeSecond);
            await task;
            return task.Id;
        }

        public async Task ChangeArrayList(int primeFirst, int primeSecond)
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst == 0 && (int)ArrayInt[i] % primeSecond != 0) ArrayInt[i] = "Fizz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst != 0 && (int)ArrayInt[i] % primeSecond == 0) ArrayInt[i] = "Buzz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst == 0 && (int)ArrayInt[i] % primeSecond == 0) ArrayInt[i] = "FizzBuzz";
            }
        }

        public void InitArray(int from, int to)
        {
            int Length = to - from;
            ArrayInt = new ArrayList();

            for (int i = 0; i < Length; i++)
            {
                ArrayInt.Add(from++);
            }

        }

        public void ShowArray()
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                Console.Write($"{ArrayInt[i]} ");
            }
        }
    }
}
