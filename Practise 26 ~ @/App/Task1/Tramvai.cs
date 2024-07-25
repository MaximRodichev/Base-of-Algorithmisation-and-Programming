using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Task1
{
    public class Tramvai
    {
        public Tramvai(DateTime DateStart, DateTime dateEnd) {
            if (DateStart > dateEnd)
            {
                throw new Exception("Invalid dates");
            }
            this.dateStart = DateStart;
            this.dateDepo = dateEnd;
            this.ExpiresDate = new DateTime() + (dateDepo - dateStart);
            this.id = tramvais.Count+1;
            tramvais.Add(this);
        }
        public int id;
        public DateTime dateStart;
        public DateTime dateDepo;
        public DateTime ExpiresDate;
        public static List<Tramvai> tramvais = new List<Tramvai>(){ };

        public override string ToString()
        {
            return $"Tramvai {id}:\nDateStart: {this.dateStart.ToLongDateString()} | {this.dateStart.ToLongTimeString()}\t\tDate End: {this.dateDepo.ToLongDateString()} | {this.dateDepo.ToLongTimeString()}\nDateExpires => {this.ExpiresDate.Hour+(24* ( this.ExpiresDate.Day-1))} hours {this.ExpiresDate.Minute} minutes";
            
        }
    }
}
