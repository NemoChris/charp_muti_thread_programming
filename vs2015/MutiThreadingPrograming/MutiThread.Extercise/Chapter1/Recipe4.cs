using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace MutiThread.Extercise.Chapter1.Recipe4
{
    public class Recipe4
    {
      
        public static void Main()
        {
            Console.WriteLine("Starting program...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t.Abort();//并不推荐使用Abort方法来关闭线程
            WriteLine("A thread has been aborted");
            t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }                
        public static void PrintNumbersWithDelay()
        {
            for (int i = 0; i < 10; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
        public static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                WriteLine(i);
            }
        }
    }
}
