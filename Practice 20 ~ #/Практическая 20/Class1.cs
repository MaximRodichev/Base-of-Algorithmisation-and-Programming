using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

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
    class Zex
    {
        private protected string Name_ = "NoName";
        private protected string Batya_ = "No Batya";
        private protected IzdelieMain[] Izdelias = null;
        public int CountWorkers = 0;

        public string Name { get { return Name_; } }
        public string Batya { get { return Batya_; } }

        public Zex(string name_, string Batya, IzdelieMain[] Izdelias, int Workers)
        {
            this.Name_ = name_;
            this.Batya_ = Batya;
            this.Izdelias= Izdelias;
            this.CountWorkers= Workers;
        }

        public void InfoAll()
        {
            Console.WriteLine($"НАИМЕНОВАНИЕ ЦЕХА: {Name_}\n~~~~~~~~~~~~\nГенеральный директор: {Batya_}\nКоличество рабочих: {CountWorkers}\n~~~~~~~\nИнформация по изделиям:");
            foreach(var item in Izdelias) { item.Info(); }
        }
        public void IzdeliasInfo()
        {
            foreach (var item in Izdelias) { item.Info(); }
        }

    }
    class Sklad : Zex
    {

        public Sklad(string name_, string Batya, IzdelieMain[] Izdelias, int Workers) : base(name_,Batya,Izdelias,Workers) { }
        public void Info()
        {
            Console.WriteLine($"НАИМЕНОВАНИЕ СКЛАДА: {Name_}\n~~~~~~~~~~~~\nГенеральный директор: {Batya_}\nКоличество рабочих: {CountWorkers}\n~~~~~~~\nИнформация по изделиям:");
            foreach (var item in Izdelias) { item.Info(); }
        }
        public void InfoIzdelias()
        {
            base.IzdeliasInfo();
        }
    }

    class ZavodoYprav
    {

        private string name_ = "Noname";
        private string batya_ = "NonBatya";
        private Zex[] Zexs;
        private Sklad[] Sklads;
        public string Name { get { return name_; } }
        public string Batya { get { return batya_; } }


        public ZavodoYprav(string name, string Batya, Zex[] Zexs, Sklad[] Sklads)
        {
            this.Zexs = Zexs;
            this.Sklads = Sklads;
            this.name_ = name;
            this.batya_ = Batya;
        }

        public void Info()
        {
            Console.WriteLine("");
            Console.WriteLine($"Заводоуправление {Name} под руководством {Batya}\nЗаведует цехами: {string.Join(" || ", Zexs.Select(x=>x.Name))}\n\nСкладами: {string.Join(" || ", Sklads.Select(x => x.Name))}");
        }
        public void ViewZexs()
        {
            foreach (var item in Zexs)
            {
                item.InfoAll();
            }
        }
        public void ViewSklads()
        {
            foreach (var item in Sklads)
            {
                item.InfoAll();
            }
        }
        public Sklad GetSklad(int n)
        {
            return Sklads[n];
        }
        public Zex GetZex(int n)
        {
            return Zexs[n];
        }

    }

    class IzdelieMain
    {
        protected string Name = "None";
        protected int Zena = 0;
        protected string Postavshik = "None";

        /// <summary>
        /// Исходный конструктор классов Изделие: ИзделиеМаин
        /// </summary>
        /// <param name="name_">Наименование изделия</param>
        /// <param name="zena_">Стоимость изделия</param>
        /// <param name="Postavshik_">Изготовитель (Поставщик)</param>
        public IzdelieMain(string name_, int zena_, string Postavshik_) {
            this.Name = name_;this.Zena = zena_;this.Postavshik = Postavshik_;
        }

        public virtual void Info()
        {
            Console.WriteLine($"\n\n~~~~~~~~~~~~\nТовар:\nНазвание: {Name},\nСтоимость: {Zena},\nПоставщик: {Postavshik}");
        }

    }
    class Paper : IzdelieMain
    {
        protected int plotnost = 80;
        protected string color = "white";

        /// <summary>
        /// Конструктор класса Изделие: Бумага
        /// </summary>
        /// <param name="plotnost_">Плотность бумаги (гр\м2)</param>
        /// <param name="color_">Цвет бумаги</param>
        public Paper(int zena_, string Postavshik, int plotnost_, string color_) : base("Bumaga", zena_, Postavshik)
        {
            this.plotnost = plotnost_;
            this.color = color_;
        }
        public Paper() : base("Bumaga", 100, "Tiraspol")
        {
            this.plotnost = 80;
            this.color = "White";
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"~~~~~~~~~\nПлотность: {plotnost} гр/м2,\nЦвет материала: {color}");
        }
    }
    class Beton : IzdelieMain
    {

        protected int Marka = 400;
        protected int Fasovka = 50; // kg

        /// <summary>
        /// Конструктор класса Бетон(Цемент)
        /// </summary>
        /// <param name="Marka_">Марка цемент 400 \ 500 ая</param>
        /// <param name="Fasovka_">Фасовка, количесство кг в мешке</param>
        public Beton(int zena_, string Postavshik_, int Marka_, int Fasovka_) : base("Beton", zena_, Postavshik_)
        {
            this.Marka = Marka_;
            this.Fasovka = Fasovka_;
        }
        public Beton() : base("Цемент", 350, "Dnestrovsk")
        {
            this.Marka = 500;
            this.Fasovka = 50;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"~~~~~~~~~\nМарка Цемента: {Marka},\nМешки расвасованы по: {Fasovka} кг");
        }

    }
    class Mixer : IzdelieMain
    {

        protected int MicroPreamps_;
        protected string Type_;
        public int MicroPreamps
        {
            get { return MicroPreamps_; }
            set { if (value < 16) { MicroPreamps_ = value; } else throw new Exception("Preamps <16");}
        }
        protected string Type
        {
            get { return Type_; }
            set { if ("Analog".Contains(value)) { Type_ = value; } else { Type_ = "Цифровой"; } }
        } 

        /// <summary>
        /// Конструктор класса Изделие: Микшер
        /// </summary>
        /// <param name="Preamps_">Количество Каналов с микрофонным предусилителем</param>
        /// <param name="Type_">Тип микшера: Analog or Цифровой</param>
        public Mixer(int zena_, string Postavshik_, int Preamps_, string Type_) : base("Микшерный пульт", zena_, Postavshik_)
        {
            this.MicroPreamps = Preamps_;
            this.Type = Type_;
        }
        public Mixer() : base("Микшерный пульт", 250, "Niderlands")
        {
            this.MicroPreamps_ = 6;
            this.Type_ = "Analog";
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"~~~~~~~~~\nКоличество каналов с микрофонным предусилителем: {MicroPreamps_},\nТип микшерного пульта: {Type}");
        }

    }
    public class Zavod
    {
        
    }
}
