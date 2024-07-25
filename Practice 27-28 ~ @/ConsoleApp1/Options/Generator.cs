
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Instructs.Instructions;

namespace App.Task2
{
    public class Generator
    {
        public static string GenerateAutoFirm()
        {
            List<string> autoFirms = new List<string>
        {
            "Toyota",
            "Mercedes",
            "BMW",
            "Honda",
            "Ford",
            "Chevrolet",
            "Volkswagen",
            "Audi",
            "Nissan",
            "Tesla",
            "Hyundai",
            "Kia",
            "Fiat",
            "Subaru",
            "Volvo"
        };
            return autoFirms[new Random().Next(autoFirms.Count)];
        }
        public static string protectionDevices()
        {
            List<string> names = new List<string>
            {
                "Circuit Breaker",
                "Residual Current Device (RCD)",
                "Surge Protector",
                "Ground Fault Circuit Interrupter (GFCI)",
                "Isolation Transformer",
                "Arc Fault Circuit Interrupter (AFCI)",
                "Electrical Insulation",
                "Safety Switch",
                "Lockout/Tagout Device",
                "Electrical Protective Gloves",
                "Safety Glasses",
                "Ear Protection (Earplugs/Ear Muffs)",
                "Voltage Tester",
                "Insulated Tools",
                "Fire Extinguisher",
                "Emergency Exit Sign",
                "Emergency Lighting",
                "First Aid Kit",
                "High Visibility Clothing",
                "Warning Signs/Labels",
                "Safety Barrier/Tape"
            };
            Random random = new Random();
            return names[random.Next(names.Count)];
        }
        public static string GenerateRandomName()
        {
            string[] names = { "John", "Alice", "Bob", "Eve", "Michael", "Emma", "David", "Sarah" };
            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        public static string GenerateRandomSurname()
        {
            string[] surnames = { "Smith", "Johnson", "Brown", "Taylor", "Williams", "Jones", "Garcia", "Davis" };
            Random random = new Random();
            return surnames[random.Next(surnames.Length)];
        }

        public static string GenerateRandomNativeName()
        {
            string[] nativeNames = { "John", "Alice", "Bob", "Eve", "Michael", "Emma", "David", "Sarah" };
            Random random = new Random();
            return nativeNames[random.Next(nativeNames.Length)];
        }

        public static char GenerateRandomGender()
        {
            Random random = new Random();
            return random.Next(2) == 0 ? 'M' : 'F'; // Randomly selects between 'M' and 'F'
        }

        public static string GenerateRandomNationality()
        {
            string[] nationalities = { "Chinese", "Indian", "United States", "Indonesian", "Pakistan", "Brazilian", "Nigerian", "Bangladeshi", "Russian", "Japanese" };
            Random random = new Random();
            return nationalities[random.Next(nationalities.Length)];
        }

        public static DateTime GenerateRandomBirthday()
        {
            Random random = new Random();
            int year = random.Next(1980, 2001); // Random year between 1980 and 2000
            int month = random.Next(1, 13); // Random month
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1); // Random day
            return new DateTime(year, month, day);
        }

        public static string GenerateRandomPhoneNumber()
        {
            Random random = new Random();
            return $"{random.Next(100, 1000)}-{random.Next(100, 1000)}-{random.Next(1000, 10000)}";
        }

        public static string GenerateRandomAddress()
        {
            string[] streetNames = { "Oak", "Maple", "Elm", "Cedar", "Pine", "Main", "First", "Second" };
            string[] streetTypes = { "Street", "Avenue", "Lane", "Road", "Boulevard", "Drive", "Court", "Place" };
            Random random = new Random();
            return $"{random.Next(1, 1000)} {streetNames[random.Next(streetNames.Length)]} {streetTypes[random.Next(streetTypes.Length)]}";
        }

        public static string GenerateRandomWorkStatus()
        {
            string[] workStatustypes = { "HeadScientist", "Laborant", "Injeneer", "Student", "DoctorOfScience" };
            Random random = new Random();
            return $"{workStatustypes[random.Next(workStatustypes.Length)]}";
        }

        public static string GenerateRandomScienceGrade()
        {
            string[] scienceGrade = { "Higher 1st Grade", "2nd Grade", "Without Grade" };
            Random random = new Random();
            return $"{scienceGrade[random.Next(scienceGrade.Length)]}";
        }

    }
}

