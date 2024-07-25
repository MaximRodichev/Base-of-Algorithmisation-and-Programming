
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[TriangleValidate]
public class Triangle
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    public float Angle_1 { get; set; }
    [Required]
    public float Angle_2 { get; set; }
    [Required]
    public float Angle_3 { get; set; }
    public String? Type { get; set; }
}