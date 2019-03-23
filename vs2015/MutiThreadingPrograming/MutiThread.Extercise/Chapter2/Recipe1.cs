﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Threading;

namespace MutiThread.Extercise.Chapter2.Recipe1
{
	public class Recipe1
	{
		public static void Main()
		{
			Console.WriteLine("Incorrect counter");

			var c = new Counter();

			var t1 = new Thread(() => TestCounter(c));
			var t2 = new Thread(() => TestCounter(c));
			var t3 = new Thread(() => TestCounter(c));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();

			Console.WriteLine($"Total count:{c.Count}");
			Console.WriteLine("-----------------------------");

			Console.WriteLine("Correct counter");

			var c1 = new CounterWithNoLock();

			t1 = new Thread(() => TestCounter(c1));
			t2 = new Thread(() => TestCounter(c1));
			t3 = new Thread(() => TestCounter(c1));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();
			Console.WriteLine($"Total count:{c1.Count}");
		}				

		static void TestCounter(CounterBase c)
		{
			for (int i = 0; i < 100000; i++)
			{
				c.Increment();
				c.Decrement();
			}
		}
	}
	class Counter : CounterBase
	{
		public int Count { get; private set; }

		public override void Decrement()
		{
			Count--;
		}

		public override void Increment()
		{
			Count++;
		}
	}
	class CounterWithNoLock : CounterBase
	{
		private readonly object _syncRoot = new object();
		private int _count;
		public int Count => _count;

		public override void Decrement()
		{
			Interlocked.Decrement(ref _count);
		}

		public override void Increment()
		{
			Interlocked.Increment(ref _count);
		}
	}


	abstract class CounterBase
	{
		public abstract void Increment();
		public abstract void Decrement();
	}

}
