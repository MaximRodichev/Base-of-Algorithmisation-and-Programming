using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instructs;

namespace Практическая_20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //new object[2] { new Beton(), new Paper() };

            //Zex Zex = new Zex("Умпалумпа", "Родичев Максим Александрович",new IzdelieMain[2]{new Beton(),  new Paper()},10);

            ZavodoYprav zV = new ZavodoYprav("Тиротекс",
                "Родичев Максим",
                new Zex[2] {
                    new Zex("Покраска ткани","Петр Петрович", new IzdelieMain[3]
                    {
                        new Beton(),
                        new Paper(),
                        new Mixer()
                    }, 56),
                    new Zex("Покрой ткани","Олег Олегович", new IzdelieMain[1]
                    {
                        new Mixer()
                    }, 14)
                },
                new Sklad[2] { 
                    new Sklad("РАСПРЕДЕЛИТЕЛЬНЫЙ СКЛАД НОМЕР 1", "Лари Иунеску", 
                    new IzdelieMain[2]
                    {
                        new Paper(),
                        new Mixer()
                    }, 6),

                    new Sklad("РАСПРЕДЕЛИТЕЛЬНЫЙ СКЛАД НОМЕР 2", "Шурдук Виктория",
                    new IzdelieMain[3]
                    {
                        new Mixer(),
                        new Mixer(),
                        new Beton()
                    }, 16) 
                });;
            zV.Info();
            Console.ReadLine();
            zV.ViewSklads();
            zV.ViewZexs();
            Console.ReadLine();
            Zex FirstZ = zV.GetZex(0);
            Zex SecondZ = zV.GetZex(1);

            FirstZ.CountWorkers = 15;
            FirstZ.InfoAll();

            Console.ReadLine();
        }
    }
}
