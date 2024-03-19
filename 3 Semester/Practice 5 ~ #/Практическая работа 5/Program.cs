using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_5
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
            //20.	Дан признак геометрической фигуры на плоскости:
            //к - круг, п - прямоугольник, т - треугольник. Вывести
            //на экран периметр и площадь заданной фигуры
            //(данные, необходимые для расчетов, запросить у пользователя).
            void Task1()
            {
                char target = ' ';
                info("Вы на первой практической");
                Task1Again:
                info("\nВыберите фигуру\nk - круг\tp - прямоугольник\tt - треугольник\nhere:");
                try { target = Convert.ToChar(Console.ReadLine());  }
                catch(Exception es) { Console.WriteLine("\n" + es); goto Task1Again; }
                switch(target)
                {
                    case 'k':
                        int R = input("Введите радиус: ");
                        info($"S = {Math.PI * Math.Pow(R, 2)}\n" +
                            $"P = {2 * R * Math.PI}");
                        goto default;
                    case 'p':
                        int h = input("Введите высоту прямоугольника: ");
                        int w = input("Введите ширину прямоугольник: ");
                        info($"\nP = {(h+w)*2}\nS = {h*w}");
                        goto default;
                    case 't':
                        info("Представим что треугольник равносторонний");
                        int Alt = input("Введите высоту треугольника: ");
                        int Base = input("Введите основание треугольника: ");
                        info($"P = {Base*3}\nS = {(double)(Alt * Base) *0.5}");
                        goto default;
                    default:
                        info("\nSpacebar to exit or any key to next");
                        if(Console.ReadKey().Key == ConsoleKey.Spacebar) { break; }
                        else { goto Task1Again; }
                }
            }

            void Task2()
            {

                info("Я проверяю числа на совершенность хе)\n");
                int num = input("Введите число: ");
                int n = 0;
                while (true)
                {
                    n++;
                    int x = int.Parse(Convert.ToString(Math.Pow(2, n)));
                    if (Math.Pow(x,2) - x == num*2)
                    {

                        info("Yes)");
                        break;
                    }
                    if(n== num)
                    {
                        info("Heh no)");
                        break; 
                    }
                    
                }
            }
            void Task3()
            {
                int Exist = input("Сколько совершенных чисел будем искать???\nHm: ");
                for (int i = 0; i < Exist; i++)
                {
                    int x = int.Parse(Convert.ToString(Math.Pow(2, i)));
                    info($"{i}: ");
                    Console.WriteLine((Math.Pow(x, 2) - x)/2);
                }
            }

            info("Практическая работа номер 5. Работаем.\n");
            PracticAgain:
            int targer = input("\nКакую задачу проверяем?: ");
            switch(targer) {
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
                    info("\nSpacebar to exit or any key to next");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { break; }
                    else { goto PracticAgain; }
            }



        }
    }
}
