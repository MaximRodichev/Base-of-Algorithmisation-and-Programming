using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Instructs
{
    internal class Instructions
    {
        /// <summary>
        /// ИНПУТ ПИТОНА КСТА
        /// </summary>
        public static int inputInt(string txt)
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

        /// <summary>
        /// ИНПУТ ПИТОНА КСТА
        /// </summary>
        public static string inputString(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(txt);
            Console.ForegroundColor = ConsoleColor.Red;
            string a = Console.ReadLine();
            Console.ResetColor();
            return a;
        }

        /// <summary>
        /// ПРИНТ ПИТОНА КСТА
        /// </summary>
        public static void info(string txt, ConsoleColor a = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = a;
            Console.Write(txt + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Форматирование строки: *-*-*-*-*-*-* {txt} *-*-*-*-*-*-*
        /// </summary>
        public static void infoWithStrikeLine(string txt, ConsoleColor a = ConsoleColor.Black)
        {
            txt = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\n" + txt + "\n" + "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
            Console.ForegroundColor = a;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(txt + "\n\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод ошибки
        /// </summary>
        public static void Error(string txt, ConsoleColor a = ConsoleColor.Red)
        {
            Console.ForegroundColor = a;
            Console.Write(txt + "\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Функция создания проверки заданий практической
        /// </summary>
        /// <param name="actions"> Action[] needed ()=>Task1() </param>
        public static void WorkList(Action[] actions)
        {again:
            byte target = Convert.ToByte(inputInt("Hello, what do you want to check? Enter the task number (zero is exit): "));
            if (target == 0) { Error("Check my homework is over. Any key to exit"); Console.ReadLine(); }
            else if (target >= 1 && target <= actions.Length)
            { 
                string text = $"- - - - - Task: {target} - - - - -";
                Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.CursorTop);
                Console.WriteLine($"{text}");
            againTask:
                actions[target - 1]();
                Error("Enter to again this Task");
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    goto againTask;
                }
                goto again;
            }
            else
            {
                info("Invalid task number, please Write Correctly: ");
                goto again;
            }
        }

    }
}
