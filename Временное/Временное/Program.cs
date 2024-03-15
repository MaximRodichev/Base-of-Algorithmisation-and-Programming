using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Временное
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input(string txt)
            {
            inputError:
                ForegroundColor = ConsoleColor.Green;
                Write(txt);
                ForegroundColor = ConsoleColor.Red;
                int a;
                if (!int.TryParse(ReadLine(), out a)) { goto inputError; }
                else
                {

                    ResetColor();
                    return a;
                }
            }
            void info(string txt)
            {
                ForegroundColor = ConsoleColor.Yellow;
                Write(txt);
                ForegroundColor = ConsoleColor.Red;
            }

            void task1()
            {
                var values = new List<int>();
                int x = 0;
                int n = input("Длину массива введите плиз: ");
                while (x < n)
                {
                    x++;
                    values.Add(input("Append mass: "));
                }
                int max = 0;
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] != 0)
                    {
                        max = values[i] < max ? max : values[i];
                    }
                }
                x = values.Where(y => y == max).Count();
                info($"{x} | {max}");
                Read();
            }
            
            void task2()
            {
                
                int x = 0;
                int n = input("Длину массива введите плиз: ");
                int[] mass = {};
                while (x < n)
                {
                    int[] mass_temp = new int[mass.Length+1];
                    Array.Copy(mass,mass_temp,mass.Length);
                    mass_temp[x] = input("Add num: ");
                    mass = mass_temp;
                    x++;
                }
                int max = 0;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] > 0)
                    {
                        max = mass[i] < max ? max : mass[i];
                    }
                }
                x = mass.Where(y => y == max).Count();
                info($"{x} | {max}");
                Read();
            }

            task2();
        }
    }
}
