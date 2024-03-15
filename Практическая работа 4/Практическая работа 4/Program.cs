using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Task1()
            {
            againTask1:
                Console.WriteLine("Вы на первом задании!");
                Console.Write("Введите х = ");
                var x = Convert.ToDouble(Console.ReadLine());
                double y;
                if (x >= -1 && x <= 2)
                {
                    y = 2 * Math.Sqrt(Math.Abs(x + 1));
                }
                else if (x == 10)
                {
                    y = 2 * Math.Tan(Math.Pow(Math.E, x)) - Math.Sin(x);
                }
                else
                {
                    Console.WriteLine("Вы ввели не значение из допустимых ");
                    goto againTask1;
                }
                Console.WriteLine($"Ответ такой: {y} при х = {x}");

            }

            void Task2()
            {//20.	является ли треугольник с длинами сторон a, b, c равносторонним.
                bool open = true;
                Console.WriteLine("Вы на втором задании\n\n");
            againTask2:
                try
                {
                    Console.Write("Введите сторону а: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите сторону b: ");
                    double b = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите сторону c: ");
                    double c = Convert.ToDouble(Console.ReadLine());
                    // negative or is zero
                    if (a <= 0 || b <= 0 || c <= 0)
                    { Console.WriteLine("Triangle is not real because negative lenght or zero"); goto againTask2; }
                    // triangle is real?
                    if (a + b < c || a + c < b || c + b < a)
                    { Console.WriteLine("Triangle is not real"); goto againTask2; }
                    if (a == b && b == c && open) { Console.WriteLine("Triangle is равносторонний"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    goto againTask2;
                }
            
            }
            void Task3()
            {
                Console.WriteLine("Это третье задание)))");
                Console.WriteLine("У меня там своя область, хочу узнать угадаешь ли ты точкой где");
                againTask3:
                Console.Write("Введите х координату: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите у коориданту: ");
                double y = Convert.ToDouble(Console.ReadLine());
                
                if(y >= 0 & y <= 23 & x <= 0 & x >= -23)
                {
                    if (y == -x) { Console.WriteLine("На границу тыкнули)))"); }
                    else if (x == 0) { Console.WriteLine("На границу тыкнули)))"); }
                    else if (y == 23) { Console.WriteLine("На границу тыкнули)))"); }
                    else if (y < -x) { Console.WriteLine("Попали в область)0)0)))"); }
                }
                else { Console.WriteLine("Не попали)))"); goto againTask3; }
                Console.WriteLine($"x = {x}, y = {y}");
            }

            Console.WriteLine("Практическая работа номер 4");
            again:
            Console.WriteLine("Введите номер задания");
            int target = Convert.ToInt32(Console.ReadLine());
            switch (target)
            {
                case 1: Task1(); goto default;
                case 2: Task2(); goto default;
                case 3: Task3(); goto default;
                default:
                    Console.WriteLine("Еще раз? -- Enter, Exit - Escape ");
                    Console.ReadLine();
                    goto again;
            }
            
        }
    }
}

