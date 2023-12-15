using System;
using System.Diagnostics;
using System.Threading;
using Exercise;

namespace Concurrent
{
    public class ConPrimeNumbers : PrimeNumbers
    {
        public ConPrimeNumbers()
        {
        }
        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="m"> is the minimum number</param>
        /// <param name="M"> is the maximum number</param>
        /// <param name="nt"> is the number of threads. For simplicity assume two.</param>
        public void runConcurrent(int m, int M)
        {
            // Todo 1: Create two threads, define their segments and start them. Join them all to have all the work done.
            Stopwatch sw = new Stopwatch();
            Thread minMax1 = new Thread(() => PrimeNumbers.printPrimes(m, M));
            Thread stopwatch = new Thread(() => sw.Start());
            stopwatch.Start();
            minMax1.Start();
            minMax1.Join();
            stopwatch.Join();
            Console.WriteLine($"The elapsed time is: {sw.ElapsedMilliseconds} milisec");
        }

    }
}
