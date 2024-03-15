using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputForTask1(string txt)
            {
            inputError:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
                int a;
                if (!int.TryParse(Console.ReadLine(), out a)) { goto inputError; }
                if(a<1 | a> 8) { info("Введите пожалуйста от 1 до 8\n");  goto inputError; }
                else
                {

                    Console.ResetColor();
                    return a;
                }
            }
            string inputForTask2(string txt)
            {
            inputError:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
                int a;
                string s = Console.ReadLine();
                if (!int.TryParse(s, out a)) { goto inputError; }
                else
                {

                    Console.ResetColor();
                    return s;
                }
            }
            void info(string txt)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
            }


            //20.	Пусть (k, l), (m, n) - поля шахматной доски:
            //k, m - номера по горизонтали;
            //l, n - номера по вертикали (l<k, m, n< 8).
            //Определите можно ли с поля (k, l)
            //попасть на поле (m, n) одним ходом слона.

            void Task1()
            {
                Console.WriteLine("Hello! 1st task, give me a position of 2 figures");
                // k l ladia  m n - target
                int k = inputForTask1("Первая фигура по горизонтали: ");
                int l = inputForTask1("Первая фигура по вертикали: ");
                //int m = inputForTask1("Вторая фигура по горизонтали: ");
                //int n = inputForTask1("Вторая фигура по вертикали: ");
                for (int m = 1; m < 9; m++)
                {
                    for(int n = 1; n<9; n++)
                    {
                        if (n == l && k == m) { Console.Write("\nFigures are same position\n"); break; }
                        if (n == m - (k - l) | n == -m + (k + l))
                        {
                            info($"Ladia Takes IN x = {m} AND y = {n}\n");
                        }

                        
                    }
                }
                // formulas y=x+b : b = x-y // n = m + (k-l)
               
            }


            //20.	Даны целое число k ( ) и последовательность цифр
            //101102103…149150, в которой выписаны подряд все
            //трехзначные числа от 101 до 150.
            //Oпределить k-ю цифру, если известно,
            //что k – одно из чисел 2, 5, 8, …
            void Task2()
            {
                string GenerateString(int from, int to)
                {
                    StringBuilder output = new StringBuilder();
                    for(int i = from; i <= to; i++)
                    {
                        output.Append($"{i}"); 
                    }
                    return output.ToString();
                }

                string target = GenerateString(101, 150);
                string check = inputForTask2("What me need check? -- ").ToString();
                if (target.Contains(check))
                {
                    var x = target.Replace(check, "C").Split('C');
                    int position = x[0].Length + 1;
                    Console.WriteLine(position);
                }
                else
                {
                    info("Net ee voobshe\n");
                }
            }


            info("Hello! its' 6th PracticWork\n");
            againAll:
            int targetTask = inputForTask1("What you need to test?: ");

            switch(targetTask) 
            {
                case 1:
                    Task1();
                    goto default;
                case 2:
                    Task2();
                    goto default;
                default:
                    info("Space to Again");
                    if(Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }








        }
    }
}
