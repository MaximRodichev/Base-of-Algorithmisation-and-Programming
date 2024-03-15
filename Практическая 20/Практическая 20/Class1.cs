using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_20
{
    /* 2. Разработать класс, содержащий вложенные объекты других классов.
     * Обратиться к методам	этих классов.
     * Провести полное тестирование разработанных классов, убедившись в том, что все методы работоспособны.
        Класс Завод.	Вложенные объекты: цех1, цех2, склад1, склад2, заводоуправление, изделие1, изделие2, изделие3.
        По требованию оператора выдать на экран информацию о:
        -	выбранном цехе (название, ФИО начальника, кол-во работающих, что выпускает);
        -	выбранном складе (название, ФИО начальника, кол-во работающих, что хранит);
        -	предприятии (название, ФИО директора, продукция, кол-во работающих и т.п.).
        Программа должна обеспечить возможность изменения некоторых данных.
    */
    internal class Zex
    {
        public string Name { get; set; }
        public string Batya { get; set; }
        public int CountWorkers { get; set; }
        public void Izdelias()
        {

        }

    }
    internal class Sklad
    {

    }

    internal class Main
    {
        
    }

    class IzdelieMain
    {
        protected string Name = "None";
        protected int Zena = 0;
        protected string Postavshik = "None";

        public IzdelieMain(string name_, int zena_, string Postavshik_) {
            this.Name = name_;this.Zena = zena_;this.Postavshik = Postavshik_;
        }

        public virtual void Info()
        {
            Console.WriteLine($"Izdelie:\nName: {Name},\nZena: {Zena},\nPostavshik: {Postavshik}");
        }

    }
    class Paper : IzdelieMain
    {
        protected int plotnost = 80;
        protected string color = "white";
        public Paper(int zena_, string Postavshik, int plotnost_, string color_) : base("Bumaga", zena_, Postavshik)
        {
            this.plotnost = plotnost_;
            this.color = color_;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"~~~~~~~~~\nPlotnost': {plotnost},\nColor: {color}");
        }
    }
    class Izdelie3
    {

    }
    public class Zavod
    {



    }
}
