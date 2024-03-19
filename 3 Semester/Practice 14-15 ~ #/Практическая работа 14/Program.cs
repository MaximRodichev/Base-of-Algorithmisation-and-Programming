using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static System.Console;

namespace Практическая_работа_14
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
            void info(string txt, ConsoleColor a)
            {
                Console.ForegroundColor = a;
                Console.Write(txt+"\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }


            //20.	Удалить в строке все лишние пробелы,
            //то есть серии подряд идущих пробелов
            //заменить на одиночные пробелы.
            //Крайние пробелы в строке удалить.
            void Task1()
            {
                string hh = "    Это      строка        с        лишними   пробелами.       Проверьте     свой     код.    ";
                var a = string.Join(" ", hh.TrimEnd().TrimStart().Split(' ').Where(x=> x != ""));
                Write(a);
            }
            //50.	Дана строка. Вставить после каждого символа пробел.
            void Task2() 
            {
                string hh = "1haekgvlx,we lf lw l wel lgelwdsl    l ldl    l ldl ld l l dl 123  444";
                Write(string.Join(" ", hh.Where(x => x != ' ')));
            }


            //20.	Непустая строка, содержащая некоторое слово, называется палиндромом,
            //если это слово одинаково читается как слева направо, так и справа налево.
            //Пусть дана строка, в которой записано слово s, состоящее из n прописных букв
            //латинского алфавита. Вычеркиванием из этого слова некоторого набора символов
            //ожно получить строку, которая будет палиндромом. Требуется найти количество способов вычеркивания
            //из данного слова некоторого (возможно, пустого) набора таких символов,
            //что полученная в результате строка является палиндромом.
            //Способы, различающиеся только порядком
            //вычеркивания символов, считаются одинаковыми.
            void Task3() {
                string a = "racecar";
                bool isPalindrom(string txt)
                {
                    
                    if (string.IsNullOrEmpty(txt) || txt.Length < 2) {  return false; }

                    for (int i = 0; i < txt.Length / 2 + 1; i++)
                    {
                        int min = i;
                        int max = txt.Length - i - 1;
                        if (txt[min] == txt[max])
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    //info($"{txt} isPalindrom: True", ConsoleColor.Yellow);
                    return true;
                }
                

                //check from random delete
                Dictionary<string,string> CheckFromRandomDelete(string txt)
                {
                    Dictionary<string, string> bookOfWords = new Dictionary<string, string>();
                   
                    for (int i = 0; i < txt.Length; i++)
                    {
                        
                        for (int j = 0; j < txt.Length; j++) 
                        {
                            for(int k = 0; k < txt.Length - j; k++)
                            {
                                string checkedIt = txt.Remove(j, k);
                                string removedIt = txt.Substring(j, k);
                                if (isPalindrom(checkedIt)){
                                    // info($"{removedIt}\n", ConsoleColor.Blue);
                                    try
                                    {
                                        bookOfWords.Add(checkedIt, removedIt);
                                    }
                                    catch { }                                
                                }
                            }
                        }
                        return bookOfWords;
                    }
                    
                    /*
                    for (int i = 0; i < txt.Length; i++)
                    {
                        for (int l = 0; l < txt.Length - i; l++)
                        {
                            string textRemap = txt.Remove(i, l);
                            for (int j = textRemap.Length; j > 0; j--)
                            {
                                for (int k = 0; k < textRemap.Length - j; k++)
                                {
                                    string checkedIt = txt.Remove(i, l);
                                    checkedIt = checkedIt.Remove(j, k);
                                    string removedIt = txt.Substring(i, l);
                                    removedIt += txt.Substring(j, k);
                                    if (isPalindrom(checkedIt))
                                    {
                                        // info($"{removedIt}\n", ConsoleColor.Blue);
                                        try
                                        {
                                            bookOfWords.Add(checkedIt, removedIt);
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                    return bookOfWords;
                }
                    */
                Dictionary<string, string> Dict = CheckFromRandomDelete(a);
                foreach (var item in Dict) { WriteLine($"{item.Key} : {item.Value}"); }
                Write($"\n{Dict.Count()}");
            }
            //50.	Даны два текста. Придумать численную характеристику,
            //показывающую насколько близки данные предложения по смыслу
            //и написанию. Проверить эту характеристику на следующей задаче.
            //Имеется несколько различных текстов. Необходимо определить,
            //добавить ли к ним еще один.
            //Новый текст стоит добавлять только,
            //если он достаточно отличен от уже имеющихся.
            void Task4() 
            {
                string textAplha = "Лето в горах прекрасно: свежий воздух, голубое небо и пение птиц.";
                string textBeta = "Горы летом восхитительны: свежий воздух, ясное небо и пение птиц.";

                string textAlpha2 = "Спорт — это важная часть моей жизни, я посвятил ему много времени.";
                string textBeta2 = "Искусство и творчество играют ключевую роль в моей жизни, они вдохновляют меня каждый день.";
                void CheckedIt(string text1st, string text2nd) 
                {
                    string[] Alpha = text1st.ToLower().Split(' ');
                    string[] Beta = text2nd.ToLower().Split(' ');
                    double Comp_Alpha_to_Beta = 0;
                    double Comp_Beta_to_Alpha = 0;

                    Comp_Alpha_to_Beta = Alpha.Intersect(Beta).Count()/(double)Alpha.Length;
                    Comp_Beta_to_Alpha = Beta.Intersect(Alpha).Count() / (double)Beta.Length;
                    info("\ntext Alpha: " + text1st+ "\nText Beta: " + text2nd + "\n", ConsoleColor.Magenta);
                    info($"Alpha to Beta: {Comp_Alpha_to_Beta}\nBeta to Alpha: {Comp_Beta_to_Alpha}\n", ConsoleColor.Green);
                }
                CheckedIt(textAplha, textBeta);
                CheckedIt(textAlpha2, textBeta2);
            }

            //19.	В сообщении, состоящем из одних русских
            //букв и пробелов, каждую букву заменили
            //ее порядковым номером в русском алфавите (А — 1, Б — 2, ..., Я — 33),
            //пробел — нулем. Требуется по заданной последовательности
            //цифр найти количество исходных сообщений,
            //из которых она могла получиться. Материал сайта www.itmathrepetitor.ru
            void Task5()
            {
                Dictionary<char, int> alphabet = new Dictionary<char, int>()
        {
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ё', 7 },
            { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 }, { 'Й', 11 }, { 'К', 12 }, { 'Л', 13 }, { 'М', 14 },
            { 'Н', 15 }, { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 }, { 'У', 21 },
            { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 },
            { 'Ы', 29 }, { 'Ь', 30 }, { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 }, {' ', 0}
        };
                string Input = "Лето в горах прекрасно: свежий воздух, голубое небо и пение птиц.";
                
                string Encode(string text)
                {
                    text = text.ToUpper();
                    StringBuilder InputEncode = new StringBuilder();
                    for (int i = 0; i< text.Length; i++) {
                        try
                        {
                            InputEncode.Append(alphabet[text[i]]);
                        }
                        catch { }
                    }
                    return InputEncode.ToString();
                }
                info(Encode(Input), ConsoleColor.Magenta);
            }






            info("Hello! its' 8th PracticWork\n", ConsoleColor.Red);
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
                case 5:
                    Task5();
                    goto default;
                default:
                    info("\nSpace to Again",ConsoleColor.Red);
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) { goto againAll; }
                    else break;
            }
        }
    }
}
