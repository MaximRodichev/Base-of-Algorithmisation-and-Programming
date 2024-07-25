using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Task2
{
    public class ProtectionDevice
    {
        public int InventaryNumber { get; set; } =  new Random().Next(100000);
        public string NameDevice { get; set; }
        public string PeopleManage {  get; set; }
        public DateTime lastCheck {  get; set; }
        public int PeriodInMonths { get; private set; } = 3;
        public override string ToString()
        {
            return $"Protection Device: {NameDevice}\nPeople Manages: {PeopleManage}\nLast Check: {lastCheck.ToLongDateString()}\t\tNext Check: {lastCheck.AddMonths(this.PeriodInMonths).ToLongDateString()}";
        }

    }
}
