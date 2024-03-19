using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_7
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

            //20.	все трехзначные числа, в которых хотя бы две цифры повторяются;
            void Task1()
            {
                info("With For:\n\n");
                for (int i = 100; i<1000; i++)
                {
                    if(i/10%11==0 | i%100%11==0 | i/100 == i%10)
                    {
                        info($"{i}\t");
                    }
                }
                info("\n\nWith While:\n\n");
                int cntr = 100;
                while (cntr<1000)
                {
                    int i = cntr;
                    if (i / 10 % 11 == 0 | i % 100 % 11 == 0 | i / 100 == i % 10)
                    {
                        info($"{i}\t");
                    }
                    cntr++;
                }
                info("\n\nWith doWhile:\n\n");
                cntr = 100;
                do
                {
                    int i = cntr;
                    if (i / 10 % 11 == 0 | i % 100 % 11 == 0 | i / 100 == i % 10)
                    {
                        info($"{i}\t");
                    }
                    cntr++;
                }
                while (cntr < 1000);

            }

            void Task2()
            {
                string[] str = { "22223", "67890" };
                for (int i = str[1].Length-1; i >= 0; i--)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        string str_temp = str[j];

                        info($"{str_temp.Substring(i)}\n");
                    }
                }
            }

            void Task3()
            {
                int Exist = input("Крайняя точка для нас это???\nHm: ");
                for (int i = 0; i < int.MaxValue; i++)
                {
                    int x = int.Parse(Convert.ToString(Math.Pow(2, i)));
                    double y = (Math.Pow(x, 2) - x) / 2;
                    info($"{i}: ");
                    Console.WriteLine(y);
                    if (y > Exist) { break; }
                }
            }

            info("Hello! its' 7th PracticWork\n");
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
                    info("Space to Again");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }
        }
    }
}
