using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading;
using static System.Console;

namespace Практическая_работа_13
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
                        if (i == j) { Console.ForegroundColor = ConsoleColor.Red; }
                        Write($"{mass[i, j]}  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Write('\n');
                }
            }
            //20.	В двумерном массиве размером 17x17 записано количество очков,
            //набранные той или иной командой во всех встречах с другими командами
            //(3 – если данная команда выиграла игру, 0 – если проиграла,
            //1 – если игра закончились вничью).
            //Определить номер команды, занявшей последнее место.
            void Task1()
            {
                int[,] B = new int[17, 17];
                List<int> commandsTotal = new List<int>();
                Random rnd = new Random();
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        againRand:
                        B[i, j] = rnd.Next(0, 4);
                        if(B[i, j] == 2) { goto againRand; }
                        sum += B[i, j];
                        Write($"{B[i, j]}  "); 
                    }
                    commandsTotal.Add(sum);
                    Write($"Total: {sum}\n");
                }
                info($"{commandsTotal.IndexOf(commandsTotal.Min()) +1}: {commandsTotal.Min()}");
            }
            //20.	Таблица футбольного чемпионата задана в виде двумерного массива
            //из n строк и m столбцов, в котором все элементы, принадлежащие главной диагонали,
            //равны нулю, а каждый элемент, не принадлежащий главной диагонали, равен 3. 1 или 0
            //(числу очков, набранных в игре: 3 – выигрыш, 1 – ничья, 0 – проигрыш).
            //Есть ли хотя бы одна команда, выигравшая более половины игр.
            void Task2()
            {
                int m = 10; //количество команд
                int n = 6; //количество игр
                int[,] B = new int[m, n];
                List<int> commandsTotal = new List<int>();
                Random rnd = new Random();
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                    againRand:
                        B[i, j] = rnd.Next(0, 4);
                        if (B[i, j] == 2) { goto againRand; }
                        if (i == j) { B[i, j] = 0; }
                        if (B[i, j] == 3) { sum += 1; }
                        Write($"{B[i, j]}  ");
                    }
                    commandsTotal.Add(sum);
                    Write($"TotalWins: {sum}\n");
                }
                Write($"Всего игр было: {n}\n{commandsTotal.Where( x=> (double)n/x <= 2).Count()} Выиграло половину игр");
            }
            //20.	Дан двумерный массив размером nxn
            //Составить программу,
            //которая меняет местами все элементы,
            //симметричные относительно главной диагонали.
            void Task3()
            {
                int m = 5; 
                int n = m;
                int[,] B = new int[m, n];
                Random rnd = new Random();
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = rnd.Next(15, 25);
                        Write($"{B[i, j]}  ");
                    }
                    Write("\n");
                }
                Write("\n\n\n\n");
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = i; j < B.GetLength(1); j++)
                    {
                        if (i == j) { continue; }

                        int temp = B[i, j];
                        B[i, j] = B[j, i];
                        B[j, i] = temp;
                    }
                }
                MassInfo(B);
            }
            //20.	Дан двумерный массив целых чисел.
            //Сформировать одномерный массив, каждый элемент
            //которого равен количеству отрицательных элементов в
            //соответствующей строке двумерного массива, кратных 3 или 7.
            void Task4()
            { 
                int m = 5; //количество строк
                int n = m; //количество столб
                int[,] B = new int[m, n];
                Random rnd = new Random();
                int[] Counter = new int[m];
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    int count = 0;
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = rnd.Next(-10, 7);
                        if (B[i,j] <0 && (B[i,j] % 3 == 0 || B[i, j] % 7 == 0))
                        {
                            count++;
                        }
                        Write($"{B[i, j]}\t");
                    }
                    Counter[i] = count;
                    Write($"Total: {count}\n");
                }
                Write("\n\n\n\n");
                foreach(var item in Counter) { Write($"Lets: {item}\n"); }
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
                case 4:
                    Task4();
                    goto default;
                default:
                    info("\nSpace to Again");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }
        }
    }
}
