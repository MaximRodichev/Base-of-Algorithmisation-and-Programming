using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instructs;

namespace Практическая_18_19
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ShiftSupervisor a = new ShiftSupervisor(
                "Petrov Petrovich",
                "Отличный работник и замечательный семьянин",
                350,
                34
                );
            a.Info();

            Console.ReadLine();

        }
    }
}
