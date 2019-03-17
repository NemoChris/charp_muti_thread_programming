using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter1.Recipe6        
{
    public class Recipe6
    {
        static void RunThreads()
        {
            var sample = new ThreadSample();
			var threadOne = new Thread(sample.CountNumbers);
			threadOne.Name = "ThreadOne";
			var threadTwo = new Thread(sample.CountNumbers);
			threadTwo.Name = "ThreadTwo";

			threadOne.Priority = ThreadPriority.Highest;
			threadTwo.Priority = ThreadPriority.Lowest;
			threadOne.Start();
			threadTwo.Start();

			Sleep(TimeSpan.FromSeconds(2));
			sample.Stop();

        }
        public static void Main()
        {
			Console.WriteLine($"Current thread priority:{CurrentThread.Priority}");
			Console.WriteLine("Running on all cores available");
			RunThreads();
			Sleep(TimeSpan.FromSeconds(2));
			Console.WriteLine("Running on a single core");
			GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
			RunThreads();
        }
        
    }

    public class ThreadSample
    {
        private bool _isStopped = false;
          
        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumbers()
        {
            long counter = 0;

            while (!_isStopped)
            {
                counter++;
            }

			Console.WriteLine($"{CurrentThread.Name} with " +
				$"{CurrentThread.Priority,11} priorty" +
				$"has a count = {counter,13}");
        }
    }
}
 