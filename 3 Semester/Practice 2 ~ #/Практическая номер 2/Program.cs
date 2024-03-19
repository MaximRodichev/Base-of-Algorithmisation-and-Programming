using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_номер_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Zapis(string txt)
            {
              Console.ForegroundColor = ConsoleColor.Green;
              Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
                int a = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
              return a;
            }

            bool end(string txt)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(txt + "\n");
                Console.ResetColor();
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    return true;
                else return false;
            }

            void Task1()
            {
                Console.WriteLine("♥ ♥ ♥ Hello! Welcome to 1st Task ♥ ♥ ♥\n" +
                    "Ты должен ввести три числа, а я посчитать их сумму");
                int a = Zapis("First number is??? -- ");
                int b = Zapis("Second number is??? -- ");
                int c = Zapis("Third number is??? -- ");
                Console.WriteLine($"{a}+{b}+{c} = {a+b+c}\n");
            }

            void Task2()
            {
                Console.WriteLine("♥ ♥ ♥ Hello! Welcome to 2nd Task ♥ ♥ ♥\n" +
                    "Ты должен ввести двухзначное число, а я посчитать сумму его цифр");
                task2_repeat:
                int a = Zapis("Жду двухзначное)) -- ");
                if (a<10 || a>100) // Проверяем ввел ли юзер двухзначное
                {
                    Console.WriteLine("Ну введи же ты Двухзначное, океюшки?");
                    goto task2_repeat;
                }
                int b = a % 10; // Получаем разряд единиц
                int c = a / 10; // Получаем разряд десятков
                Console.WriteLine($"Я разбил твое число({a}) на {b} and {c} и\n" +
                    $"И получил их сумму == {b+c}\n");
            }

            void Task3()
            {
                Console.WriteLine("♥ ♥ ♥ Hello! Welcome to 3rd Task ♥ ♥ ♥\n" +
                    "Ты должен ввести Координаты двух точек, а я посчитать расстояние между ними");
                int x1 = Zapis("Первая координата Первой точки? -- ");
                int y1 = Zapis("Вторая координата Первой точки? -- ");
                int x2 = Zapis("Первая координата Второй точки? -- ");
                int y2 = Zapis("Вторая координата Второй точки? -- ");
                Console.WriteLine($"Расстояние между этими точками будет:" +
                    $"{Math.Abs(Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(y2 - y1, 2)))}\n"); 
                        // Берем абсолютное значение выражения:                                                                   
                        // Корень из (х2-х1)^2 + (y2-y1)^2
            }

            Console.WriteLine("Приветствую тебя в моей программе, выберите номер задания, чтобы его проверить!");
            repeat:
            int task_select = Zapis("Номер задания??? -- ");
            switch (task_select)
            {
                case 1:
                    Task1();
                    if (end("Если хотите покинуть - нажмите Space"))
                        break;
                    goto repeat;
                case 2:
                    Task2();
                    if (end("Если хотите покинуть - нажмите Space"))
                        break;
                    goto repeat;
                case 3:
                    Task3();
                    if (end("Если хотите покинуть - нажмите Space"))
                        break;
                    goto repeat;
                default:
                    if (end("Увы но я выполнил только 3 из 3 заданий)\n" +
                        "Если хотите покинуть - нажмите Space"))
                        break;
                    goto repeat;
            }    

            Console.WriteLine("Spasibo!");
            Console.ReadLine();

        }
    }
}
