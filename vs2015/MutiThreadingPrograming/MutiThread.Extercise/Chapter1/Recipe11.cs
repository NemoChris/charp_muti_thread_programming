using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter1.Recipe11
{
	public class Recipe11
	{
		public static void Main()
		{
			var t = new Thread(FaultyThread);
			t.Start();
			t.Join();
			try
			{
				t = new Thread(BadFaultyThread);
				t.Start();
			}
			catch (Exception)
			{

				Console.WriteLine("We won't get here!");
			}

		}

		static void BadFaultyThread()
		{
			Console.WriteLine("Starting a faulty thread...");
			Sleep(TimeSpan.FromSeconds(2));
			throw new Exception("Boom!");
		}

		static void FaultyThread()
		{
			try
			{
				Console.WriteLine("Starting a faulty thread...");
				Sleep(TimeSpan.FromSeconds(1));
				throw new Exception("Boom!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception handled:{ex.Message}");
			}
		}
	}
}
