using Solution_Console.Models;
using Solution_Console.Repositories;
using System;
using static Instructs.Instructions;

namespace Solution_Console.Tests
{
    public class SportsmanTests
    {
        public static void CreationTest()
        {
            infoWithStrikeLine("CreationTest Starts");
            string[] prefixes = { "John", "Alice", "Bob", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Emily" };
            string[] suffixes = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string name = prefixes[rnd.Next(prefixes.Length)];
                string surname = suffixes[rnd.Next(suffixes.Length)];
                int h = rnd.Next(110, 250);
                int w = rnd.Next(50, 110);
                SportsmanRepository.CreateSportsman(
                    name,
                    surname,
                    h,
                    w
                );
            }
            infoWithStrikeLine("You must create 2 sportiks");
            SportsmanRepository.CreateSportsman();
            SportsmanRepository.CreateSportsman();

        }
        public static void OutSportiks()
        {
        again:
            Console.Clear();
            infoWithStrikeLine($"Sportiks DATA, All Count: {SportsmanModel.Sportiks.Count}");
            SportsmanRepository.GetSportsmanByWeigth();
        }

    }
}
