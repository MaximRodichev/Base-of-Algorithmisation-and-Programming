using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instructs;

namespace Практическая_20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Paper a = new Paper(10, "Tiraspol", 85, "Red");
            a.Info();
            Console.ReadLine();

        }
    }
}
