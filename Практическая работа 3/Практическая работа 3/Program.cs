using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task1
            void Task1()
                {
                double v0 = 400;
                double v1 = 0;
                double h = 0.36;
                double h1 = (h * 50 / 100);
                double a = (Math.Pow(v0, 2) - Math.Pow(v1, 2)) / (2 * h);
                double t = v0 / a;
                double result = Math.Sqrt(Math.Pow(v0,2)-2*a*h1);
                double in99PerCent = Math.Sqrt(Math.Pow(v0, 2) - 2 * a * (h*99/100));
                Console.WriteLine($"пуля летела: {t}c\nСкорость на 18см: {result}см\\с\nПри прохождении 99% пути скорость: {in99PerCent}м\\с");
            }
            void Task2()
            {
                Console.WriteLine("Введите стоимость товара до деноминации: ");
                int r = Convert.ToInt32(Console.ReadLine());
                const int denominationConst = 1000;
                Console.WriteLine($"{r/denominationConst}rubles and {Math.Round(Convert.ToDouble((r % denominationConst)) /10)} copeek");
            }
            void Task3()
            {
                Console.WriteLine("Ща посчитаю тяжеленную формулу, кайфую: ");
                int x = 1;
                var temp_ = x + Math.Log(Math.Sqrt(x));
                var temp2_ = Math.Sqrt(x + Math.Sin(2 * x) + Math.Pow(Math.E, -2 * x));
                var final = temp2_ * temp_;
                Console.WriteLine($"Короче да, оно равно этому: {final}");
            }
            void Task4()
            {
                Console.WriteLine("а в 17ой за 6ть действий");
                Console.Write("Введи а:");
                var a = Convert.ToDouble(Console.ReadLine());
                var a2 = a * a; // 1st
                var a4 = a2 * a2; //2nd
                var a8 = a4 * a4; // 3rd
                var a9 = a8 * a; //4th
                var a13 = a9 * a4;//5th
                var a17 = a13 * a4;//6th
                Console.WriteLine($"Твое число сделал за 6 умножений а в 17ой: {a17}");
            }

            Console.WriteLine("Приветствую на третьей практической");
            reopen:
            Console.Write("Выберите задание для проверки: ");
            int target = int.Parse(Console.ReadLine());
            switch (target)
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
                case 4:
                    Task4();
                    goto default;
                default:
                    Console.WriteLine("Еще раз? -- Enter, Exit - Escape ");
                    Console.ReadLine();
                    goto reopen;
            }
            }
        }
    }
