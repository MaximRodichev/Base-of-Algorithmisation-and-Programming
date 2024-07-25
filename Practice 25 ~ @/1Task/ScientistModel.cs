using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_25____
{
//     «Ученый»:
//фамилия; имя; отчество; пол; национальность; дата рождения(год, месяц
//число); ученая степень, должность, номер телефона; домашний адрес
//(почтовый индекс, страна, область, район, город, улица, дом, квартира). 
    public class ScientistModel : PersonBaseModel
    {
        public string WorkStatus {  get; set; }
        public string ScienceGrade { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nScientist: WorkStatus: {WorkStatus} | ScientistGrade: {ScienceGrade}";
        }
    }
}
