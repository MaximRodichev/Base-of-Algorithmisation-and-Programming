using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;

namespace Практическая_работа_12
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
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            void MassInfo(int[,] mass)
            {
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j < mass.GetLength(1); j++)
                    {
                        Write($"{mass[i, j]}\t");
                    }
                    Write('\n');
                }
            }
            //20.	Найти количество элементов матрицы В(7х8) кратных пяти в третьем столбце.
            void Task1()
            {
                int[,] B = new int[7, 8];
                Random rnd = new Random();
                int count = 0; 
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = rnd.Next(1, 46);

                        if (j == 2 && B[i,j] % 5 == 0) { Write($"TRUE:{B[i, j]}\t"); count++; }
                        else { Write($"{B[i, j]}\t"); }
                    }
                    Write($"\n");
                }
                Write($"\nCount: {count}");
            }
            //20.	Найти количество строк, содержащих хотя бы один нулевой элемент.
            void Task2()
            {
                int[,] B = new int[7, 8];
                Random rnd = new Random();
                int count = 0;
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    bool open = true;
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = rnd.Next(-6, 6);
                        if (open && B[i, j] == 0) { 
                            count++; 
                            open = false; 
                            info($"{B[i, j]}\t"); 
                        }
                        else { Write($"{B[i, j]}\t"); }
                    }
                    Write('\n');
                }
               
                    info($"\n\n Count: {count}");
            }
            //20.	В двумерном массиве хранится информации о
            //зарплате 18 сотрудников фирмы за каждый месяц года
            //(в первом столбце – за январь, во втором – за февраль и т.п.).
            //Определить среднюю зарплату за каждый месяц.
            void Task3()
            {
                int Workers = 18;
                int months = 12;
                int[,] B = new int[months, Workers];
                Random rnd = new Random();
                int j = 0;
                string[] monthsList = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                Dictionary<string, int> montsCost = new Dictionary<string, int>();
                foreach (string month in monthsList) { montsCost.Add(month, 0); }   
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    int sumMonth = 0;
                    for (j = 0; j < B.GetLength(0); j++)
                    {
                        B[j, i] = rnd.Next(0, 8);
                        sumMonth += B[j, i];
                        Write($"{B[j, i]}$\t");
                        montsCost[monthsList[j]] = montsCost[monthsList[j]] + B[j, i];
                    }
                    info($"Total: {sumMonth}$\n");
                }
                foreach(var item in montsCost) { info($"{item.Key} : {item.Value}$\n"); }
                Write('\n');
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
