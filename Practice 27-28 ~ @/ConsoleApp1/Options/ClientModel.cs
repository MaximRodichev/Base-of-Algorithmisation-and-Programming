using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Options
{
    public class ClientModel
    {
        public int Id { get; set; } = new Random().Next(10000, 100000);
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartExplotation { get; set; } = DateTime.Now;
        public DateTime EndExplotation { get; set; }


        public override string ToString()
        {
            return $"{Name} => {Description}\nStart using at {StartExplotation.ToLongDateString()} {StartExplotation.ToLongTimeString()}\nEnd Explotation at {EndExplotation.ToLongDateString()} {EndExplotation.ToLongTimeString()}";
        }

    }

    public class clientBase
    {
        public string name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

