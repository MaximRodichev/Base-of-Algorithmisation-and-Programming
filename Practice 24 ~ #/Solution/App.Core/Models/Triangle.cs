
using System.ComponentModel.DataAnnotations;

[TriangleValidate]
public class Triangle
{
    [Required]
    public float Angle_1 { get;  set; }
    [Required]
    public float Angle_2 { get;  set; }
    [Required]
    public float Angle_3 { get;  set; }

    [TriangleTypeProperty]
    public TriangleType Type { get;  set; }
}
