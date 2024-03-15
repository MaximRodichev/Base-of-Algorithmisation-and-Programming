using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Шандригоз_Методы_Треугольник_по_координатам
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

            double Len(double[] st1, double[] nd2) {
                double temp = Math.Sqrt(Math.Pow(nd2[0] - st1[0], 2) + Math.Pow(nd2[1] - st1[1], 2));
                info($"Len:= {temp}\n");
                return temp;
            }
            double P(double a, double b, double c) {
                if(a<b+c & b<a+c & c<a+b)
                {
                    //return a+b+c;
                    double temp = a+c+b;
                    info($"Per:= {temp}\n");
                    return S(a, b, c, a + b + c);
                }
                return 0;
            }
            double S(double a, double b, double c, double Per){
                Per = Per / 2;
                double temp = Per * (Per - a) * (Per - b) * (Per - c);
                temp = Math.Sqrt(temp);
                info($"Square:= {temp}\n");
                return temp;
            }
            double[] _1 = { input("Hello x: "), input("Hello y: ") };
            double[] _2 = { input("Hello x: "), input("Hello y: ") };
            double[] _3 = { input("Hello x: "), input("Hello y: ") };

            info($"{P(Len(_1,_2), Len(_2, _3), Len(_1, _3))}");
            ReadLine();


        }
    }
}
