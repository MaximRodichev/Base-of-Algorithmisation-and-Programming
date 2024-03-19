using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_18_19
{
    public class ShiftSupervisor : Employee
    {
        public int Bonus { get; set; }
        public double Salary { get; set; }

        public ShiftSupervisor(string n, string d, int money, int Bonus) : base(n,d,money) {
            this.Bonus = Bonus;
            Salary = money + money * (double)Bonus/100;
            Salary *= 12;
        }

        public override void Info()
        {
            Console.WriteLine($"ShiftSupervisor: {base.Name}\nDecs: {base.Description}\nMoney per Month (as Worker): {base.Money}$\n~~~~~~~\nBonus: {Bonus}%\nSalary for Year (as ShiftSupervisor): {Salary}");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Money { get; set; }

        protected Employee(string name, string decs, int money) {
            Name = name; Description = decs; Money = money;
        }

        public virtual void Info()
        {
            Console.WriteLine($"Worker: {Name}\nDecs: {Description}\nMoney per Month: {Money}");
        }
    }
}
