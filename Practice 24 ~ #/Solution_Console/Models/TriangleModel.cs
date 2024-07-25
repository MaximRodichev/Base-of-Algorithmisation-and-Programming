using Solution_Console.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Console
{
    public class TriangleModel
    {
        public static int id { get; private set; }
        public int thisId { get; private set; }
        public float Angle_1 { get; set; }
        public float Angle_2 { get; set; }
        public float Angle_3 { get; set; }
        

        public TriangleType type { get; set; }

        public static int CountAcutes { get; private set; }
        public static int CountObtuse { get; private set; }
        public static int CountRights { get; private set; }

        private static List<TriangleModel> Acutes_ = new List<TriangleModel>();
        private static List<TriangleModel> Obtuse_ = new List<TriangleModel>();
        private static List<TriangleModel> Rights_ = new List<TriangleModel>();

        public static List<TriangleModel> Acutes { get
            {
                return Acutes_;
            }
        }
        public static List<TriangleModel> Obtuse { get {
                return Obtuse_;
            }
        }
        public static List<TriangleModel> Rights { get {
                return Rights_;
            }
        }

        public TriangleModel(float Angle_1, float Angle_2, float Angle_3)
        {
            TriangleValidate.Validate(Angle_1, Angle_2, Angle_3);
            id++;
            thisId = id;
            this.Angle_1 = Angle_1;
            this.Angle_2 = Angle_2;
            this.Angle_3 = Angle_3;
            if(Angle_1 < 90 && Angle_2 < 90 && Angle_3 < 90)
            {
                this.type = TriangleType.Acute;
                CountAcutes++;
                Acutes_.Add(this);
            }
            else if (Angle_1 == 90 || Angle_2 == 90 || Angle_3 == 90)
            {
                this.type = TriangleType.Right;
                CountRights++;
                Rights_.Add(this);
            }
            else
            {
                this.type = TriangleType.Obtuse;
                CountObtuse++;
                Obtuse_.Add(this);
            }
        }

        public override string ToString()
        {
            return $"Triangle {thisId} from {id} triangles founded and:\nIt is type: {this.type} with params\nAngle_1: {Angle_1}\tAngle_2: {Angle_2}\tAngle_3: {Angle_3}";
        }
    }
    
    public enum TriangleType
    {
        Acute,
        Obtuse,
        Right
    }
}
