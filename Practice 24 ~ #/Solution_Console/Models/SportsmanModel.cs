using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Console.Models
{
    public class SportsmanModel
    {
        public int thisId { get; private set; }
        public static int id { get; private set; }  
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public static float weightAccurance = 70;
        private static List<SportsmanModel> Sportiks_ = new List<SportsmanModel>();
        public static List<SportsmanModel> Sportiks { get => Sportiks_; }

        
        private SportsmanModel() {
            this.Name = "NoName";
            this.Surname = "NoName";
        } 
        public SportsmanModel(float height, float weight) : this()
        {
            SportsmanValidation.Validate(height, weight);
            Height = height;
            Weight = weight;
            Sportiks_.Add(this);
            thisId++;
            id = thisId;
        }
        public SportsmanModel(string name, string surname, float height, float weight)
        {
            Name = name;
            Surname = surname;
            SportsmanValidation.Validate(weight, height);
            Height = height;
            Weight = weight;
            Sportiks_.Add(this);

            id++;
            thisId = id;
        }
        public override string ToString()
        {
            return $"Sportik: {Name} {Surname}, index at: {thisId}\nWeight: {Weight} | Height: {Height}";
        }
    }
}
