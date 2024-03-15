using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Практическая_работа_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input(string txt)
            {
            inputError:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
                int a;
                if (!int.TryParse(Console.ReadLine(), out a)) { goto inputError; }
                else
                {

                    Console.ResetColor();
                    return a;
                }
            }
            void info(string txt)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
            }

            void Task1()
            {
                int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1245 };
                info($"{a.Max() + a.Min()}");
            }

            void Task2()
            {
                int[] a = new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -1245 };
                info($"{a.Select(i => Math.Abs(i)).Min()}");
            }

            void Task3()
            {
                int[] a = new int[] {-2, 2, -3, -2, -5, 6, 6, -5, -3, 0, 1245 };
                
                var b = a.Append(0);
                var a1 = a.Prepend(0);
                int g = a1.Where(x=> (int)x > 0 && b.ToArray()[Array.IndexOf(a1.ToArray(),x)] < 0 
                || (int)x < 0 && b.ToArray()[Array.IndexOf(a1.ToArray(), x)] > 0).Count();
                info($"{g}");
            }

            //{0, -1, 2, -3, 4, -5, 6, -7, 8, -9, 0, 1245 }
            //{ -1, 2, -3, 4, -5, 6, -7, 8, -9, 0, 1245, 0}
            info("Hello! its' 8th PracticWork\n");
            againAll:
            int targetTask = input("What you need to test?: ");

            switch (targetTask)
            {
                case 1:
                    Task1();
                    goto default;
                case 2:
                    Task2();
                    goto default;
                case 3:
                    Task3();
                    goto default;
                default:
                    info("\nSpace to Again");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }
        }
    }
}
