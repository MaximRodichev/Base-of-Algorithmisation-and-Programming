using Solution_Console.Models;
using System;
using static Instructs.Instructions;

namespace Solution_Console.Tests
{
    public class TriangleTests
    {
        public static void CreationTest()
        {
            infoWithStrikeLine("CreationTest Starts");
            Random rnd = new Random();
            for(int i=0; i<10; i++)
            {
                int a = rnd.Next(40,120);
                int b = rnd.Next(0,180-a);
                int c = 180 - a - b;
                TriangleRepository.CreateTriangle(
                    a,
                    b,
                    c
                    );
            }
            infoWithStrikeLine("You must create 2 triangles");
            TriangleRepository.CreateTriangle();
            TriangleRepository.CreateTriangle();
        }
        public static void OutTriangles() {
            again:
            Console.Clear();
            infoWithStrikeLine($"Triangles DATA, All Count: {TriangleModel.id}");
            info("1 - Acutes;\n2 - Obtuse;\n3 - Rights\n");
            int a = inputInt("choose: ");
            if(a<4 && a > 0)
            {
                TriangleRepository.Triangles((TriangleType)(a - 1));
                if(Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    return;
                }
                goto again;
            }
            else { goto again; }
        }
    }
}
