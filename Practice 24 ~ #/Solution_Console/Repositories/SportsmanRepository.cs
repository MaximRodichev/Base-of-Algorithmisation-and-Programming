using Solution_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using  static Instructs.Instructions;

namespace Solution_Console.Repositories
{
    public class SportsmanRepositoryBase
    {
        public static void CreateSportik()
        {
            Console.WriteLine($"Create a sportik: {SportsmanModel.id}") ;
        }
    }
    public class SportsmanRepository
    {
        public static SportsmanModel CreateSportsman()
        {
            SportsmanRepositoryBase.CreateSportik();
            string name = inputString("Name?: ");
            string surname = inputString("Surname?: ");
            float h = Convert.ToSingle(inputInt("Please input a height: "));
            float w = Convert.ToSingle(inputInt("Please input a weight: "));
            SportsmanModel sportik;
            try
            {
                sportik = new SportsmanModel(name, surname, h, w);
                return sportik;
            }
            catch (Exception ex) { Error(ex.Message); }
            return null;
        }
        public static SportsmanModel CreateSportsman(string name, string surname, float h, float w)
        {
            SportsmanRepositoryBase.CreateSportik();
            SportsmanModel sportik;
            try
            {
                sportik = new SportsmanModel(name, surname, h, w);
                return sportik;
            }
            catch (Exception ex) { Error(ex.Message); }
            return null;
        }

        public static void GetSportsman()
        {
            foreach(SportsmanModel sportik in SportsmanModel.Sportiks)
            {
                Console.WriteLine(sportik);
            }
        }
        public static void GetSportsmanByWeigth()
        {
            foreach (SportsmanModel sportik in SportsmanModel.Sportiks.Where(x=> x.Weight >= SportsmanModel.weightAccurance))
            {
                Console.WriteLine(sportik);
            }
        }
    }
}
