using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OKrug b = new OKrug(5);
            Zillinder c = new Zillinder(b, 20);
            Zillinder a = new Zillinder(10, 10);

            b.Info();
            c.Info();
            a.Info();
            Console.ReadLine();

        }
    }
}
