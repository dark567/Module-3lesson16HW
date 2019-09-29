using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFibonachi
{
    class Singleton
    {
        private static Singleton _instance = null;
        private static object _locker = new Object();

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

        public async Task<long> GetSumOfRandomValuesAsync(long inputValue)
        {
            long result = 0;
            Task<long> task = Task<long>.Factory.StartNew(() =>
            {
                result = Fibonacci(n: inputValue);
                return result;
            });
            await task;
            return task.Result; //calling result from a task
        }

        private long Fibonacci(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
