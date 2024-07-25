using static Instructs.Instructions;

namespace App
{
    public class DateDialogue
    {
        public static int[] map = new int[]
        {
            31,28,31,30,31,30,31,31,30,31,30,31
        };
        public static DateTime dateInput()
        {
            
            info("Set a date:");
        againYear:
            int year = inputInt("Set year: ");
            if (year < 1 || year > 2050) {
                Error("Diapozone of Year 1 - 2050");
                goto againYear;
            }
        againMonth:
            int month = inputInt("Set month");
            if(month < 1 || month > 12)
            {
                Error("Dizpozone of Month is 1 - 12");
                goto againMonth;
            }
        againDay:
            int day = inputInt("Set a day: ");
            if(day < 1)
            {
                Error("Day is not be negative");
                goto againDay;
            }
            if (day > (map[month-1] + Convert.ToInt16(month == 2 && year % 4 == 0)))
            {
                Error($"Month equals a {map[month - 1]} days");
                goto againDay;
            }

            var date = new DateTime(year, month, day);

            return date;
        }
        public static DateTime dateInputExp()
        {

            info("Set a date:");
        againYear:
            int year = inputInt("Set year: ");
            if (year < 1 || year > 2050)
            {
                Error("Diapozone of Year 1 - 2050");
                goto againYear;
            }
        againMonth:
            int month = inputInt("Set month");
            if (month < 1 || month > 12)
            {
                Error("Dizpozone of Month is 1 - 12");
                goto againMonth;
            }
        againDay:
            int day = inputInt("Set a day: ");
            if (day < 1)
            {
                Error("Day is not be negative");
                goto againDay;
            }
            if (day > (map[month - 1] + Convert.ToInt16(month == 2 && year % 4 == 0)))
            {
                Error($"Month equals a {map[month - 1]} days");
                goto againDay;
            }
        againHour:
            int hours = inputInt("Set a hours: ");
            if (hours < 0 || hours > 23)
            {
                Error($"Diapozone of hours its 0 - 23");
                goto againHour;
            }

        againMin:
            int minutes = inputInt("Set a minutes: ");
            if(minutes < 0 || minutes > 59)
            {
                Error($"Diapozone of minutes its 0 - 59");
                goto againMin;
            }

            var date = new DateTime(year, month, day, hours, minutes, 0);

            return date;
        }
        public static DateTime dateInput(int month, int day, int year)
        {
            if (year < 1 || year > 2050)
            {
                throw new Exception("Diapozone of Year 1 - 2050");
            }
            if (month < 1 || month > 12)
            {
                throw new Exception("Dizpozone of Month is 1 - 12");
               
            }
            if (day < 1)
            {
                throw new Exception("Day is not be negative");
            }
            if (day > (map[month - 1] + Convert.ToInt16(month == 2 && year % 4 == 0)))
            {
                throw new Exception($"Month equals a {map[month - 1]} days");
            }

            var date = new DateTime(year, month, day);

            return date;
        }

        public static DateTime dateRandom()
        {
            try
            {
                return dateInput(
                    new Random().Next(1, 12),
                    new Random().Next(1, 30),
                    2024
                    );
            }
            catch(Exception ex)
            {
                info(ex.Message);
            }
            return new DateTime();
        }
    }
}
