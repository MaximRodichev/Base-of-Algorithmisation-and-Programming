using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_25____
{
    //     «Ученый»:
    //фамилия; имя; отчество; пол; национальность; дата рождения(год, месяц
    //число); ученая степень, должность, номер телефона; домашний адрес
    //(почтовый индекс, страна, область, район, город, улица, дом, квартира). 
    public class PersonBaseModel
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string NativeName { get;set; }
        public char gender { get; set; }
        public string National {  get; set; }
        public DateTime Birthday { get; set; }
        [Phone]
        public string Phone { get;set; }
        public string Address {  get; set; }

        public override string ToString()
        {
            return $"LastName: {LastName} | FirstName: {FirstName} | NativeName: {NativeName}\n" +
                $"Gender: {gender} | National : {National}\n" +
                $"Birthday: {Birthday}\n" +
                $"Phone: {Phone} | Address: {Address}";
        }
    }
}
