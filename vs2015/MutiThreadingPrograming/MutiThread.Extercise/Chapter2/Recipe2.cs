using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter2.Recipe2
{
	public class Recipe2
	{
		public static void Main()
		{
			const string MutexName = "CSharpThreadingCookbook";
			using (var m = new Mutex(false,MutexName))
			{
				//阻止当前线程直到接受信号为止，信号为是否需要等待
				if (!m.WaitOne(TimeSpan.FromSeconds(15),false))
				{
					Console.WriteLine("Second instance is running!");
				}
				else
				{
					Console.WriteLine("Running!");
					ReadLine();
					m.ReleaseMutex();
				}
			}

		}
	}
}
