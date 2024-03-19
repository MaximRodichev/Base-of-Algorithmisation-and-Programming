using System;
using Instructs;

namespace Практическая_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(15, 3, 2024);
            date.Info();
            date.Next(100).Info();
            date.Previous(100).Info();
            date -= date;
            date.Info();
            Console.ReadLine();

            


        }
    }
}
