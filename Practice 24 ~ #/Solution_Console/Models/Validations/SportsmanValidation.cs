using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Console.Models
{
    public class SportsmanValidation 
    {
        public static void Validate(float W, float H)
        {
            if (H >= 240 || H <= 110)
            {
                throw new Exception("Рассмотрите рост вашего спорстмена, возможно допущена ошибка");
            }
            if (W <= 50 || W >= 110)
            {
                throw new Exception("Недопустимое значение веса спортсмена");
            }
        }
    }

}
