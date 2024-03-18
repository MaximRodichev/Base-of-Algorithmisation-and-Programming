using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_22
{
    class OKrug
    {
        private protected double Radius_;
        public double Radius
        {
            get { return Radius_; }
            set { 
                if (value < 0) { throw new Exception("Radius is negative"); }
                else { Radius_ = value; }
            }
        }

        public OKrug(double k)
        {
            this.Radius = k;
        }
        public double S()
        {
            return Radius * 2 * Math.PI;
        }
        public void Info()
        {
            Console.WriteLine($"Okrujnost'\nRadius: {Radius}\nS: {S()}");
        }

    }

    class Zillinder : OKrug
    {
        private double Height_;
        public double Height
        {
            get { return Height_; }
            set
            {
                if (value < 0) { throw new Exception("Height is negative"); }
                else { Height_ = value; }
            }
        }

        public Zillinder(double Radius, double Height) : base(Radius)
        {
            this.Height = Height;
        }
        public Zillinder(OKrug a, double Height) : base(a.Radius)
        {
            this.Radius = a.Radius;
            this.Height = Height;
        }
        public double S()
        {
            return base.S() * Height;
        }
        public double V()
        {
            return Math.PI * Radius * Radius * Height;
        }
        public void Info()
        {
            Console.WriteLine($"Zillinder\nRadius: {Radius}\nS: {S()}");
            Console.WriteLine($"V: {V()}");
        }
    }
}
