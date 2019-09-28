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
        private ArrayList ArrayInt = new ArrayList();

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

        public async Task<int> DefaultCalc(int from = 1, int to = 100)
        {
            //var sum = a + b;

            var task = ChangeArrayList();
            await task;
            return task.Id;
        }

        public async Task ChangeArrayList()
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % 3 == 0 && (int)ArrayInt[i] % 5 != 0) ArrayInt[i] = "Fizz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % 3 != 0 && (int)ArrayInt[i] % 5 == 0) ArrayInt[i] = "Buzz";
                if (ArrayInt[i] is Int32 && (int)ArrayInt[i] % 3 == 0 && (int)ArrayInt[i] % 5 == 0) ArrayInt[i] = "FizzBuzz";
            }
        }

        //private async Task AsyncSymulation(int delay)
        //{
        //    Console.WriteLine("delay started");
        //    await Task.Run(() => { Thread.Sleep(delay * 1000); });
        //    Console.WriteLine("delay complited");
        //}

        public void InitArray(int from = 1, int to = 100)
        {
            int Length = to - from;

            for (int i = 0; i < Length; i++)
            {
                ArrayInt.Add(i);
            }

        }

        public void ShowArray()
        {
            for (int i = 0; i < ArrayInt.Count; i++)
            {
                Console.Write($"{ArrayInt[i]} " );
            }
        }
    }
}
