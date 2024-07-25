using System;
using static Instructs.Instructions;

namespace Solution_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void TriangleTask()
            {
                infoWithStrikeLine("TRIANGLE TASK!");
                Console.ReadKey();
                Tests.TriangleTests.CreationTest();
                Tests.TriangleTests.OutTriangles();
            }

            void SportsmanTask()
            {
                infoWithStrikeLine("SPORTIK TASK!");
                Console.ReadKey();
                Tests.SportsmanTests.CreationTest();
                Tests.SportsmanTests.OutSportiks();
            }

            void BookTask()
            {
                infoWithStrikeLine("BOOKS TASK!");
                Console.ReadKey();
                Tests.BookTests.CreationTest();
                Tests.BookTests.OutBooks();
            }

            WorkList(new Action[] { () => TriangleTask(), ()=>SportsmanTask(), ()=>BookTask() });
            Console.ReadKey();
        }
    }
}
