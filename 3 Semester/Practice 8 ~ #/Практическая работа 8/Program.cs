using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_8
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
                string a = Convert.ToString(input("Give me a integer number: "));
                var b = a.Max();
                var c = a.Remove(a.IndexOf(b),1).Max();
                info($"{b}\n{c}\n");
            }
            void Task2()
            {
                int x = 0;
                int n = input("Скок человек-то?: ");
                int[] mass = { };
                while (x < n)
                {
                    int[] mass_temp = new int[mass.Length + 1];
                    Array.Copy(mass, mass_temp, mass.Length);
                    mass_temp[x] = input($"Скок весит [{x}] по счету человек?: ");
                    mass = mass_temp;
                    x++;
                }
                info($"Максимальный вес: {mass.Max()},\n" +
                    $"Пузатиков: {mass.Where(y => y >= 100).Count()}шт,\n" +
                    $"В среднем {mass.Average()}кг на тело");


            }
            void Task3()
            {
                int x = 0;
                int n = input("Скок команд?: ");
                int[] mass = { };
                while (x < n)
                {
                    int[] mass_temp = new int[mass.Length + 1];
                    Array.Copy(mass, mass_temp, mass.Length);
                    mass_temp[x] = input($"Скок очков у [{x}] по счету команды?: ");
                    mass = mass_temp;
                    x++;
                }
                int min = mass.Min();
                int a = mass.Where(y => y == min).Count() >= 2 ? Array.FindIndex(mass, y => y == min) + 1 : 0;
                string output = a == 0 ? $"Min goals: {min}" : $"Min goals: {min} \\ FirstIndex: {a}";
                info(output);
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
