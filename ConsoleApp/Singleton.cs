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
        /// thread-safe Synglton
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="primeFirst"></param>
        /// <param name="primeSecond"></param>
        /// <returns></returns>
        public async Task<int> Calc(int from, int to, int primeFirst, int primeSecond)
        {
            //var sum = a + b;
            InitArray(from, to);
            var task = ChangeArrayList(primeFirst, primeSecond);
            await task;
            return task.Id;
        }

        /// <summary>
        /// Change Array List
        /// </summary>
        /// <param name="primeFirst"></param>
        /// <param name="primeSecond"></param>
        /// <returns></returns>
        public async Task ChangeArrayList(int primeFirst, int primeSecond)
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst == 0 && (int)ArrayInt[i] % primeSecond != 0) ArrayInt[i] = "Fizz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst != 0 && (int)ArrayInt[i] % primeSecond == 0) ArrayInt[i] = "Buzz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % primeFirst == 0 && (int)ArrayInt[i] % primeSecond == 0) ArrayInt[i] = "FizzBuzz";
            }
        }

        /// <summary>
        /// Init ArrayList
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void InitArray(int from, int to)
        {
            int Length = to - from;
            ArrayInt = new ArrayList();

            for (int i = 0; i < Length; i++)
            {
                ArrayInt.Add(from++);
            }

        }

        /// <summary>
        /// Show menu
        /// </summary>
        public void ShowArray()
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                Console.Write($"{ArrayInt[i]} ");
            }
        }
    }
}
