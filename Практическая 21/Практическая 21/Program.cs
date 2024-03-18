using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(1, 0, 2024);
            date.ReJoin(date.Next(100));
            date.Info();
            Console.ReadLine();
            


        }
    }
}
