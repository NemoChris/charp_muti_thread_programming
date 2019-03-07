using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace MutiThread.Extercise.Chapter1.Recipe3
{
    public class Recipe3
    {
        public static void Main()
        {
            Console.WriteLine("Starting...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();//等待直到线程t完成，主线程才会继续执行（借助该技术可以实现两个线程间同步执行步骤）
            WriteLine("Thread completed");
        }
        public static void PrintNumbersWithDelay()
        {         
            for (int i = 0; i < 10; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
    }
}
