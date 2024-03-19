using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_21
{       //  Описать класс дат Date. Определить в нем: 
        //• конструктор, принимающий номера дня, месяца и года(рассматривать только положительные номера года);
        //• копирующий конструктор;
        //• методы Next и Prev, возвращающие следующий или предыдущий день;
        //• метод IsLeapYear, проверяющий, является ли текущий год високосным;
        //• операции прибавления и вычитания целого числа, позволяющие получить следующие за текущим или предыдущие дни;
        //• метод для вывода текстового представления даты(например, 12 февраля 1994 г.).   
    internal class Date
    {   
        private int year_;
        private int month_;
        private int day_;
        private bool isLeap_;
        public bool isLeap
        {
            get { return isLeap_; }
        }
        private Dictionary<string, int> dayMap_ = new Dictionary<string, int>()
        {
            {"January", 31},
            {"February", 28},
            {"March", 31},
            {"April", 30},
            {"May", 31},
            {"June", 30},
            {"July", 31},
            {"August", 31},
            {"September", 30},
            {"October", 31},
            {"November", 30},
            {"December", 31},
        };
        //2024 - isLeap

        public int Year
        {
            get { return year_; }
            set
            {
                if (value >= 0 && value < 3000) 
                { 
                    year_ = value;
                    isLeap_ = value % 4 == 0;
                    dayMap_["February"] = isLeap_ ? 29 : 28;
                }
                else { throw new Exception("Year isn't in 0<x<3000"); }
            }
        }
        public int Month
        {
            get { return month_; }
            set
            {
                if (value >-1 && value < 12) { month_ = value; } else { throw new Exception("Month isn't in 0<x<13"); }
            }
        }
        public int Day
        {
            get { return day_; }
            set
            {
                if (dayMap_.Values.ToArray()[month_] > value && value<1 )
                {
                    throw new Exception("Vse slomalos in DAY");
                }
                else { day_ = value; }
            }
        }

        public Date(int day, int month, int year) //Main Constructor
        {
            this.Month = month;
            this.Day = day;    
            this.Year = year;
        }
        public Date(Date a)
        {
            this.year_ = a.year_;
            this.month_ = a.month_;
            this.day_ = a.day_;
        } //Copying Constructor
        public Date Previous(int dayUp = 1)
        {
            int rY = year_;
            int rM = month_;
            int rD = day_;
            var e = this.dayMap_;
            
            if(rD - dayUp <= 0)
            {
                while (rD - dayUp <= 0)
                {
                    dayUp -= rD;
                    if (rM == 0)
                    {
                        rM = 11;
                        rY -= 1;
                        e["February"] = rY % 4 == 0 ? 29 : 28;
                    }
                    else
                    {
                        rM -= 1;
                    }
                    rD = e.Values.ToArray()[rM];
                }
                return new Date(rD-dayUp, rM, rY);
            }
            else
            {
                return new Date(day_-dayUp, month_, year_);
            }
        }
        public Date Next(int dayUp = 1)
        {
            int rY = year_;
            int rM = month_;
            int rD = day_;
            var e = this.dayMap_;

            if (rD + dayUp > e.Values.ToArray()[rM])
            {
                while (rD + dayUp > e.Values.ToArray()[rM])
                {
                    dayUp -= e.Values.ToArray()[rM] - rD;
                    if (rM == 11)
                    {
                        rM = 1;
                        rY += 1;
                        e["February"] = rY % 4 == 0 ? 29 : 28;
                    }
                    else
                    {
                        rM += 1;
                    }
                    rD = 0;
                }
                return new Date(dayUp, rM, rY);
            }
            else
            {
                return new Date(day_ + dayUp, month_, year_);
            }
        }
        public void ReJoin(Date d)
        {
            this.Day = d.Day;
            this.Month = d.Month;
            this.Year = d.Year;
        }
        public int days()
        {
            int count = 0;
            for (int i = 0; i < year_; i++)
            {
                if (i%4 == 0) { count += 366; }
                else { count += 365; }
            }
            for(int i=0; i<month_; i++)
            {
                count += dayMap_.Values.ToArray()[month_];
            }
            count += day_;
            return count;
        }
        public static Date operator -(Date a, Date b)
        {
            return new Date(a.Previous(b.days()));
        }
        public void Info()
        {
            Console.WriteLine($"Date isLeap: {isLeap}\nDay: {this.day_}\nMonth: {this.dayMap_.Keys.ToArray()[this.month_]}\nYear: {year_}");
        }

    }
}
