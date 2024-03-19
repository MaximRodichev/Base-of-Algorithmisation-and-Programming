using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Практическая_23
{
    /*
     *  15.АВТОМОБИЛЬ: марка, цвет, мощность двигателя,
     *  расход горючего на 100 км, год изготовления, стоимость.
     *  
     *  Написать программу, позволяющую вести набор данных о 10 автомоби-лях.
     *  Рассчитать стоимость автомобиля.
     *  Учесть, что эта стоимость состоит из стоимости, заданной владельцем автомобиля
     *  и налога, который зависит от даты изготовления автомобиля.
     * xНапример, если возраст автомобиля >10 лет, то это 20% его стоимости,
     * если <=10 лет, то это 10% его стоимости.
     * 
     * Статиче-ский метод должен выдавать название страны, в которой производится рас-таможивание автомобиля.
     */
    class Car
    {
        private Dictionary<char, ConsoleColor> Colors = new Dictionary<char, ConsoleColor>()
        {
            {'b', ConsoleColor.Black },
            {'r', ConsoleColor.Red },
            {'g', ConsoleColor.Green },
            {'y', ConsoleColor.Yellow },
            {'a', ConsoleColor.Blue },
            {'m', ConsoleColor.Magenta },
            {'c', ConsoleColor.Cyan },
            {'w', ConsoleColor.White },
        };

        private string Country = "Russia";
        private int cost_;
        private ConsoleColor color_;
        private int nalog_;
        private int rashod_;
        private int enginePower_;
        private string model_;
        private int year_;
        public string Model { get { return model_; } set { if (model_ is null) { model_ = value; } } }
        public ConsoleColor Color { get { return color_; } set { color_ = value; } }
        public int EnginePower { get { return enginePower_; } set { enginePower_ = value; Rashod = EnginePower / Model.Length; } }
        private int Rashod { get { return rashod_; } set { rashod_ = value; } }
        public int YearOf { get { return year_; } set { if (year_==0) { year_ = value; Nalog = 0; } } }
        private int Nalog { get { return nalog_; } set {
                if (new DateTime(2024).Year - YearOf > 10) { nalog_ = 20; }
                else { nalog_ = 10; }
            } 
        }
        public int Cost { get { return cost_; }
            set {
                cost_ = value + value * Nalog / 100;
            }
        }
        public Car(ConsoleColor color, string model, int Epower, int YearOf, int Cost) {
            Color = color; Model = model; this.YearOf = YearOf; EnginePower = Epower; this.Cost = Cost;
        }

        public static void CountryTamojnya()
        {
            Console.WriteLine($"Russia is country exporter or importer");
        }

        public override string ToString()
        {
            return $"Model: {Model}\n$YearOf: {YearOf}year\nEnginePower: {enginePower_} Horse powers\n~~Rashod: {rashod_} litr na 100 km\n~~~~~\nExport country: {Country}\nCost: {cost_}$\nNalog {nalog_}% ({nalog_*cost_/100})";
        }



    }
}
