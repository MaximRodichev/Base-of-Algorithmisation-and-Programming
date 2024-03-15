using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_9
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
                // Math.Sin(x/4)/2
                double A = Math.PI / 2;
                double B = Math.PI;
                double M = 15;
                double h = (B - A) / M;
                while (M>=0)
                {
                    double temp =  A + h* M;
                    double answ = Math.Sin(temp / 4) / 2;
                    info($"{answ}\n");
                    M--;
                }

            }

            void Task2()
            {
                // Math.Pow(-1,n+1) * (Math.Pow(x, 2n+1))/(4n*n - 1), x=0.3; e = 10^-3
                double x = 0.3;
                const double e = 0.01;
                double sum = 0;
                double y = 0;
                for (int i = 0; i<int.MaxValue; i++)
                {
                    int n = i;
                    y = Math.Pow(-1, n + 1) * Math.Pow(x, 2*n + 1) / (4*n* n -1);
                    if (y > e)
                    {
                        sum += y;
                        info($"Now add in sum: {y} With n = {n}\n");
                    }
                    else break;
                }
                info($"Last number: {y}\nSumm of numbers: {sum}");

            }

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
                default:
                    info("\nSpace to Again");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }
        }
    }
}
