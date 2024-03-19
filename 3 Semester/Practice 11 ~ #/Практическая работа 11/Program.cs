using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Console;

namespace Практическая_работа_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input(string txt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
                string a;
                a = Console.ReadLine();
                Console.ResetColor();
                return a;
                
            }
            void info(string txt)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(txt);
                Console.ForegroundColor = ConsoleColor.Red;
            }


            //20.Пусть даны целые числа, среди которых могут
            //быть повторяющиеся.Составьте новый массив из
            //чисел, которые 
            //входят в последовательность по одному разу.
            void Task1()
                
            {
                Random rnd = new Random();
                int[] orig = new int[100];
                for(int i = 0; i < orig.Length; i++)
                {
                    orig[i] = rnd.Next(0, 25);
                    Write(orig[i] + " ");
                }
                Write('\n');
                Array.Sort(orig);
                for(int i = 0; i<orig.Length; i++)
                {
                    Write(orig[i] + " ");
                }
                int[] Cleaner(int[] mass) 
                {
                    for (int i = 0; i < mass.Length - 1; i++)
                    {
                        if (mass[i] == mass[i + 1])
                        {
                            Write(mass[i] + " and " + mass[i + 1] + "\n");
                            int[] massFake = mass.Where(x => x != mass[i]).ToArray();
                            mass = massFake;
                            i = i - 1;
                        }
                    }
                    return mass;
                }
                orig = Cleaner(orig);
                Write("\n");
                foreach(int g in orig) { Write(g + " "); }
            }


            //20.Ко всем отрицательным элементам прибавить
            //элемент с номером аl, из всех нулевых вычесть число b
            //Положительные элементы оставить без изменения;
            void Task2()
            {
                int a = 5;
                int b = 3;
                int[] ms = { -4, -2, -65, 3, 55, 23, 4, 0, 1, 34, 0, 0, 22, 0 };
                foreach(int item in ms) { Write(item + "\t"); }
                Write("\n");
                for(int i = 0; i < ms.Length; i++)
                {
                    if (ms[i] < 0) ms[i] = ms[i] + a;
                    if (ms[i] == 0) ms[i] = ms[i] - b;
                }
                foreach (int item in ms) { Write(item + "\t"); }
            }

            void Task3()
            {
                //20.В массиве записана информация
                //о росте каждого из 25 учащихся
                //группы(в порядке уменьшении роста) Один из учащихся выбыл.
                //Получить новый массив с упорядоченными
                //в том же порядке данными о росте оставшихся учащихся.
                //Рассмотреть случай, когда известен рост выбывшего учащегося.

                Dictionary<string,int> Students = new Dictionary<string, int>();
                string[] SurnamesDatabase = { "Popov", "Rodichev", "Ivanov", "Petrov", "Smirnov", "Kuznetsov", "Sokolov", "Lebedev", "Kozlov", "Novikov", "Morozov", "Volkov", "Fedorov", "Alekseev", "Egorov", "Pavlov", "Kharitonov", "Abramov", "Belov", "Bogdanov", "Voronin", "Semyonov", "Tarasov", "Filippov", "Makarov" };
                Random rand = new Random();
                for(int i = 0; i<SurnamesDatabase.Length; i++)
                {
                    int heightRND = rand.Next(155, 199);
                    Students.Add(SurnamesDatabase[i], heightRND);
                    Write($"{SurnamesDatabase[i]} | {heightRND}\n");
                }
                List<int> heights = Students.Values.ToList();
                List<string> surnames = Students.Keys.ToList();
                int[] heightsArr = heights.ToArray();
                Array.Sort(heightsArr);
                Dictionary<string,int> StudentsRemap = new Dictionary<string,int>();
                foreach(var item in heightsArr.Reverse())
                {
                    int CurrHeight = item;
                    string CurrName = Students.FirstOrDefault(x=> x.Value == CurrHeight).Key;
                    StudentsRemap.Add(CurrName, CurrHeight);
                    Students.Remove(CurrName);
                }
                WriteLine("\n\n");
                foreach(var item in StudentsRemap) { WriteLine($"{item.Key}: {item.Value}"); }

                void DeleteStudentFromName(string surname)
                {
                    againDelete:
                    try
                    {
                        info($"Delete student {surname} with {StudentsRemap[surname]}\n");  StudentsRemap.Remove(surname);}
                    catch { info("Someone do not work, again please\n");goto againDelete; }
                    foreach (var item in StudentsRemap) { WriteLine($"{item.Key}: {item.Value}"); }
                }
                void DeleteStudentFromHeight(int height, int diapozon = 0)
                {
                    int count = StudentsRemap.Count(x=> height + diapozon >= x.Value && x.Value >= height-diapozon);
                    if (count == 0) { info("Students with this height not defined, maybe?\n"); 
                        DeleteStudentFromHeight(height, diapozon + 10);}
                    if (count == 1)
                    {string surname = StudentsRemap.Where(x => x.Value == height).First().Key;
                        DeleteStudentFromName(surname);
                    }
                    else {
                        var data = StudentsRemap.Where(x => height + diapozon >= x.Value && x.Value >= height - diapozon);
                        foreach (var item in data) {WriteLine($"{item.Key}: {item.Value}");}
                        string surname = input("Choose Surname of Students: ");
                        DeleteStudentFromName(surname); }
                }
                DeleteStudentFromHeight(Convert.ToInt32(input("Выберите студента для отчисления по росту: ")));
                DeleteStudentFromName(input("Выберите студента для отчисления по имени: "));
            }

            info("Hello! its' 11th PracticWork\n");
        againAll:
            int targetTask = Convert.ToInt32(input("What you need to test?: "));

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
