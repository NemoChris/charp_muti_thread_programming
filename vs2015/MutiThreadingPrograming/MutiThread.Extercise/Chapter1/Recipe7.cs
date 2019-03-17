using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter1.Recipe7
{
	public class Recipe7
	{
		public static void Main()
		{
			var sampleForeground = new ThreadSample(10);
			var sampleBackground = new ThreadSample(20);

			var threadOne = new Thread(sampleForeground.CountNumbers);
			threadOne.Name = "ForegroudThread";
			var threadTwo = new Thread(sampleBackground.CountNumbers);
			threadTwo.Name = "BackgroundThread";
			threadTwo.IsBackground = true;

			threadOne.Start();
			threadTwo.Start();

		}

	}

	class ThreadSample
	{
		private readonly int _iterations;
		public ThreadSample(int iterations)
		{
			_iterations = iterations;
		}
		public void CountNumbers()
		{
			for (int i = 0; i < _iterations; i++)
			{
				Sleep(TimeSpan.FromSeconds(0.5));
				Console.WriteLine($"{CurrentThread.Name} prints {i}");
			}
		}
	}
}
