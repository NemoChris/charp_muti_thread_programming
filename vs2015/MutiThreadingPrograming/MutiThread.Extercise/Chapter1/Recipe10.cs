using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter1.Recipe10
{
	public class Recipe10
	{
		public static void Main()
		{
			object lock1 = new object();
			object lock2 = new object();
			new Thread(() => LockTooMuch(lock1, lock2)).Start();
			lock (lock2)
			{
				Thread.Sleep(1000);
				Console.WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");
				if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
				{
					Console.WriteLine("Acaured a protected resource succesfully");
				}
				else
				{
					Console.WriteLine("Timeout acquiring a resource!");
				}
			}		

			new Thread(() => LockTooMuch(lock1, lock2)).Start();
			Console.WriteLine("---------------------------------------");
			lock (lock2)
			{
				Console.WriteLine("This will be a deadlock!");
				Sleep(1000);
				lock (lock1)
				{
					Console.WriteLine("Acqured a protected resource succesfully");
				}
			}
		}

		static void LockTooMuch(Object lock1, object lock2)
		{
			lock (lock1)
			{
				Sleep(1000);
				lock (lock2) ;
			}
		}
	}
}
