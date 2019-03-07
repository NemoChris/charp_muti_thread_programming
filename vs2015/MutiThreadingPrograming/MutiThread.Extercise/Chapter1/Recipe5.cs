using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace MutiThread.Extercise.Chapter1.Recipe5
{
    public class Recipe5
    {

        public static void Main()
        {
            Console.WriteLine("Starting program...");
            Thread t = new Thread(PrintNumbersWithStatus);
            Thread t2 = new Thread(DoNothing);
            Console.WriteLine(t.ThreadState.ToString());//线程状态位于Thread对象的ThreadState属性中
            t2.Start();
            t.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(t.ThreadState.ToString());
            }
            Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            Console.WriteLine("A thread has been aborted");
            Console.WriteLine(t.ThreadState.ToString()); ;
            Console.WriteLine(t2.ThreadState.ToString());            
        }
        public static void PrintNumbersWithStatus()
        {
            Console.WriteLine("Starting...");
            Console.WriteLine(CurrentThread.ThreadState.ToString());
            for (int i = 0; i < 10; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
        public static void DoNothing()
        {
            Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
