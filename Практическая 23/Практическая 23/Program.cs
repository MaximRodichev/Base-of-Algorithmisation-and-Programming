using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Car[] cars = new Car[10];
            string[] models = new string[]
            {
                "Toyota Camry",
                "Honda Civic",
                "Ford Mustang",
                "Chevrolet Silverado",
                "BMW 3 Series",
                "Mercedes-Benz E-Class",
                "Audi Q5",
                "Nissan Altima",
                "Volkswagen Golf",
                "Hyundai Sonata"
            };

            for (int i = 0; i<cars.Length; i++)
            {
                Console.WriteLine($"Set the car with Number: {i}");
                cars[i] = new Car(
                    colors[rand.Next(1, colors.Length)],
                    models[rand.Next(0, models.Length)],
                    rand.Next(90, 150),
                    rand.Next(1999, 2024),
                    rand.Next(1500, 6500)
                    );
            }

            Console.WriteLine("ENDING\n Write info about all? (Y\\n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                foreach(var item in cars)
                {
                    Console.ForegroundColor = item.Color;
                    Console.WriteLine("\n\n"+item.ToString());

                }
            }
            Car.CountryTamojnya();
            Console.ReadLine();


        }
    }
}
