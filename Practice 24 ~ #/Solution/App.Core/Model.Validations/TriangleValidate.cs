using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Class)]
public class TriangleValidate : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        try
        {
            Triangle triangle = (Triangle)validationContext.ObjectInstance;

            if (triangle.Angle_1 + triangle.Angle_2 + triangle.Angle_3 != 180)
            {
                return new ValidationResult("Сумма углов треугольника должна быть равна 180 градусов.");
            }

            return ValidationResult.Success;
        }
        catch
        {
            return new ValidationResult("Crash");
        }
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class TriangleTypePropertyAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Triangle triangle = (Triangle)validationContext.ObjectInstance;

        if (triangle.Angle_1 > 90 || triangle.Angle_2 > 90 || triangle.Angle_1 > 90)
        {
            triangle.Type = TriangleType.Obtuse;
        }
        else if (triangle.Angle_1 == 90 || triangle.Angle_2 == 90 || triangle.Angle_1 == 90)
        {
            triangle.Type = TriangleType.Right;
        }
        else
        {
            triangle.Type = TriangleType.Acute;
        }

        return ValidationResult.Success;
    }
}
public enum TriangleType
{
    Acute, // острый
    Obtuse, // тупой
    Right // прямой
}
