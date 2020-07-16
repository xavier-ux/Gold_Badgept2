using _01_Insurance_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    class Program
    {
        static void Main(string[] args)
        {//use var so the variables dont have to be expressed
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
    }
}
