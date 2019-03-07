using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//我们使用了C#6.0提供的using static特性，可以使用System.Console类型的静态方法而不用我们指定类型名。
//如果本类中有重名的静态方法会优先使用本类的
using static System.Console;


namespace MutiThread.Extercise.Chapter1.Recipe1
{
    public class Recipe1
    {
        public static void Main()
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();            
        }
     
        public static void PrintNumbers()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 20; i++)
            {
                WriteLine(i);
            }
        }

    }
}
