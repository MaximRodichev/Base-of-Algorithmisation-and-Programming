using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_18_19
{
    /*
     * Вариант8 
     * 2. Класс ShiftSupervisor.
     * На некой фабрике начальник смены является штатным сотрудником,
     * который руководит сменой. В дополнение к фиксированному окладу
     * начальник смены получает годовую премию за выполнение его сменой
     * производственного плана. Напишите класс ShiftSupervisor (Начальник смены),
     * который является подклассом класса Ernployee, созданного в задаче по программированию 
     * 1. Класс ShiftSupervisor должен содержать атрибут данных для годового оклада
     * и атрибут данных для годовой производственной премии, которую заработал начальник смены.
     * Продемонстрируйте класс, написав программу, которая применяет объект ShiftSupervisor. 
     */

    public class ShiftSupervisor : Employee
    {
        private int salary_;
        private int bonus_;
        public int Bonus
        {
            get => bonus_; 
            set
            {
                bonus_ = value;
                salary_ = (this.Money + this.Money * Bonus / 100) * 12;
            }
        }
        public int Money
        {
            get
            {
                return base.Money;
            }
            set
            {
                base.Money = value;
                salary_ = (base.Money + base.Money * Bonus / 100) * 12;
            }
        }
        public double Salary { get => salary_; }

        public ShiftSupervisor(string n, string d, int money, int Bonus) : base(n,d,money) {
            this.Bonus = Bonus;
        }

        public override void Info()
        {
            Console.WriteLine($"\n\nShiftSupervisor: {base.Name}\nDecs: {base.Description}\nMoney per Month (as Worker): {base.Money}$\n~~~~~~~\nBonus: {Bonus}%\nSalary for Year (as ShiftSupervisor): {Salary}");
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
