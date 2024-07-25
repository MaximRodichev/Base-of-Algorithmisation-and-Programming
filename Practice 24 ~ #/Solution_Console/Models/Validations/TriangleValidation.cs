using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Console.Models
{
    public class TriangleValidate 
    {
        public static void Validate(float Angle_1, float Angle_2, float Angle_3)
        {
            if (Angle_3 <= 0)
            {
                throw new Exception("Угол 3 не может быть равным 0 или отрицательным.");
            }
            if (Angle_2 <= 0)
            {
                throw new Exception("Угол 2 не может быть равным 0 или отрицательным.");
            }
            if (Angle_1 <= 0)
            {
                throw new Exception("Угол 1 не может быть равным 0 или отрицательным.");
            }
            if (Angle_1 + Angle_2 + Angle_3 != 180)
            {
                throw new Exception("Сумма углов треугольника должна быть равна 180 градусов.");
            }
        }
    }

}
