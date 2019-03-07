using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MutiThread.Extercise.Tool
{
    public class ConsoleHelper
    {
        public static void WaitKey()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
        }
    }
}
