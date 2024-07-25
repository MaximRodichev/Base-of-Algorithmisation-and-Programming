using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

[AttributeUsage(AttributeTargets.Class)]
public class TriangleValidate : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        try
        {
            Triangle triangle = (Triangle)validationContext.ObjectInstance;
            if(triangle.Angle_3 <= 0)
            {
                return new ValidationResult("Угол 3 не может быть равным 0 или отрицательным.");
            }
            if (triangle.Angle_2 <= 0)
            {
                return new ValidationResult("Угол 2 не может быть равным 0 или отрицательным.");
            }
            if (triangle.Angle_1 <= 0)
            {
                return new ValidationResult("Угол 1 не может быть равным 0 или отрицательным.");
            }
            if (triangle.Angle_1 + triangle.Angle_2 + triangle.Angle_3 != 180)
            {
                return new ValidationResult("Сумма углов треугольника должна быть равна 180 градусов.");
            }
        }
        catch
        {
            return new ValidationResult("Crash");
        }
        return ValidationResult.Success;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class TriangleTypePropertyAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        Triangle triangle = (Triangle)validationContext.ObjectInstance;

        if (triangle.Angle_1 > 90 || triangle.Angle_2 > 90 || triangle.Angle_3 > 90)
        {
            triangle.Type = "Obtuse";
        }
        else if (triangle.Angle_1 == 90 || triangle.Angle_2 == 90 || triangle.Angle_3 == 90)
        {
            triangle.Type = "Right";
        }
        else
        {
            triangle.Type = "Acute";
        }

        return ValidationResult.Success;
    }
}
