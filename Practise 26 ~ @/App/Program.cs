using App;
using App.Task1;
using Practice_25____;
using App.Task2;
using static Instructs.Instructions;
using System;
using System.Xml.Linq;
// See https://aka.ms/new-console-template for more information
//1. Ввести две даты и определить количество дней между ними.
//2. Диспетчерскому центру трамвайного депо требуется разработать 
//программу, которая для введенных значений времени выхода трамвая на 
//маршрут и времени его возврата в депо определяет общее время пребыва
//ния трамвая на маршруте в минутах и количество целых часов.


void Task1()
{
    infoWithStrikeLine("Task 1 Choose a action:");
    againTask1:
    switch (inputInt("Actions\n1 - Get a different of date's\n2 - Tranvai department\n")) {
        case 1:
            DateTime date1 = DateDialogue.dateInput();
            DateTime date2 = DateDialogue.dateInput();
            DateTime date3;
            if (date2 > date1)
            {
                var date = date2;
                date2 = date1;
                date1 = date;
            }
            info($"Between {date2.ToShortDateString()} and {date1.ToShortDateString()} equals {(date1 - date2).TotalDays} days");
            goto default;
        case 2:
            Random rand = new Random();
            foreach(var a in Enumerable.Range(0, 5))
            {
                var dat = DateDialogue.dateRandom();
                new Tramvai(dat, dat.AddDays(rand.Next(0, 2)).AddHours(rand.Next(0,22)).AddMinutes(rand.Next(0,55)));
            }
            againCase2:
            info("Hello its dispetcherskoe depo\n Choose the action\n");
            switch(inputInt("Actions\n1-View all tramvais\n2-Add Tramvai"))
            {
                case 1:
                    foreach(var item in Tramvai.tramvais)
                    {
                        info($"{item.ToString()}\n");
                    }
                    goto default;
                case 2:
                    info("Date Start:\n ");
                    var d1 = DateDialogue.dateInputExp();
                    info("Date End:\n ");
                    var d2 = DateDialogue.dateInputExp();
                    new Tramvai(d1,d2);
                    goto default;
                default:
                    Error("Enter to select new action");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        goto againCase2;
                    }
                    break;
            }
            goto default;
        default:
            Error("Enter to select new action");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                goto againTask1;
            }
            break;
    
    
    }

}

//Структура и ее поля 
#region
//Средства защиты от поражения 
//электрическим током:
// инвентарный номер;
// наименование;
// ФИО ответственного;
// дата последней проверки;
// очередность проверки в 
//месяцах.
#endregion
//задача
#region
// вывести сведения обо всех средствах защиты с указанием для них
//следующей даты проверки;
// вывести информацию о средствах 
//защиты, проверка которых запланирована на следующий месяц этого 
//года.
#endregion

void Task2()
{
    infoWithStrikeLine("Task 2 hellowed you");
    if (!File.Exists("Protections.json"))
    {
        File.Create("Protections.json").Close();
    }
    JSON<ProtectionDevice> jsonparser = new JSON<ProtectionDevice>("Protections.json");
againTask2:
        switch(inputInt("Choose a action:\n1 - Generate data to list\n2 - Print a data of all protetction devices with next date of checked\n3 - Print a data of all protection devices with next checked time less then 1 month"))
    {
        case 1:
           
            for (int i = 0; i<5; i++)
            {
                jsonparser.SaveOrUpdateJson(new ProtectionDevice()
                {
                    lastCheck = DateTime.Now - (DateTime.Now.AddDays(new Random().Next(100)) - DateTime.Now),
                    NameDevice = Generator.protectionDevices(),
                    PeopleManage = Generator.GenerateRandomName() + Generator.GenerateRandomNativeName()
                });
            }
            goto default;
        case 2:
            foreach(var item in jsonparser.GetDataJson())
            {
                if (item.Value.lastCheck.AddMonths(item.Value.PeriodInMonths) > DateTime.Now.AddMonths(1))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Good Checked Time\n");
                    info(item.Value.ToString());
                }
                else if (item.Value.lastCheck.AddMonths(item.Value.PeriodInMonths) < DateTime.Now.AddMonths(1))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Checked time at this Month, need soon to be check\n");
                    info(item.Value.ToString());
                }
                else if (item.Value.lastCheck.AddMonths(item.Value.PeriodInMonths) < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("CHECK PLEASE!!!\n");
                    info(item.Value.ToString());
                }

            }
            goto default;
        case 3:
            foreach (var item in jsonparser.GetDataJson())
            {
                if(item.Value.lastCheck.AddMonths(item.Value.PeriodInMonths) < DateTime.Now.AddMonths(1))
                {
                    info(item.ToString());
                }
            }
            goto default; 
        default:
            Error("Enter to select new action");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                goto againTask2;
            }
            break;
    }
}

//-ввести две даты и подсчитать количество выполненных проверок для 
//указанного интервала дат;
//-определить средство защиты, проверенное первым в этом месяце;
//-упорядочить исходную информацию по дате последней проверки,
//создав для этого необходимое количество файлов, где в качестве имени 
//файла используется дата проверки, а содержимым является информация 
//обо всех проверках за эту дату

void Task3()
{
    infoWithStrikeLine("Alloha, its 3rd task");
    if (!File.Exists("Protections.json"))
    {
        File.Create("Protections.json").Close();
    }
    JSON<ProtectionDevice> jsonparser = new JSON<ProtectionDevice>("Protections.json");
againTask3:
    Dictionary<int,ProtectionDevice> data;
    switch (inputInt("Choose a action:\n" +
        "1 - Ввод двух дат и подсчет кол-ва выполненных проверок для указанного интервала дат\n" +
        "2 - Определить средство защиты, проверенное первым в этом месяце\n" +
        "3 - Упорядочить исходную информацию по дате последней проверки"))
    {
        case 1:
            info("Dates:\n");
            DateTime date1 = DateDialogue.dateInput();
            DateTime date2 = DateDialogue.dateInput();
            if (date1 < date2)
            {
                var g = date1;
                date1 = date2;
                date2 = g;
            }
            data = jsonparser.GetDataJson();
            var count = 0;
            var list = new List<ProtectionDevice>();
            foreach (var i in data) { 
                if(i.Value.lastCheck > date2 && i.Value.lastCheck < date1)
                {
                    count++;
                    list.Add(i.Value);
                }
            }
            var t = inputInt($"In period i can find a {count} devices with check\nWhat you do with?\n1--Save to file this devices\n2--Output here\n3--Exit");
            switch(t)
            {
                case 1:
                    Console.Write("Choose select name of file\t\t");
                againFileCreate:
                    if (!Directory.Exists("SavesData/"))
                    {
                        Directory.CreateDirectory("SavesData/");
                    }
                    string filePath = "SavesData/" + inputString("SavesData/");
                    if (File.Exists(filePath))
                    {
                        Error("File with same name exists\nWant to write override? [Y/n]");
                        if(Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            goto Save;
                        }
                        goto againFileCreate;
                    }
                    else { goto Save; }
                Save:
                    File.Create(filePath).Close();
                    JSON<ProtectionDevice> thisFile = new JSON<ProtectionDevice>(filePath);
                    thisFile.SaveOrUpdateJson(list);
                    goto default;
                case 2:
                   foreach(var i in list)
                    {
                        info(i.ToString());
                    }
                    goto default;
                case 3:
                    break;
                default:
                    Error("Enter to select new action");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        goto againTask3;
                    }
                    break;
            }
            goto default;
        case 2:
            data = jsonparser.GetDataJson();
            ProtectionDevice item = null;
            foreach (var i in data)
            {
                var property = i.Value.lastCheck;
                if (property.Month == DateTime.Now.Month)
                {
                    if (item == null) { item = i.Value; }
                    else if (property < item.lastCheck)
                    {
                        item = i.Value;
                    }
                }
            }
            if (item == null) { info("Not found last cheks at this month"); }
            else
            {
                info($"Last checked in this month: {item.lastCheck}\n{item}");
            }
            goto default;
        case 3:
            List<JSON<ProtectionDevice>> dataJsonControllers = new List<JSON<ProtectionDevice>>();
            data = jsonparser.GetDataJson();
            Dictionary<string, List<ProtectionDevice>> MaptoDates = new Dictionary<string, List<ProtectionDevice>>();
            foreach(var i in data)
            {
                string a = i.Value.lastCheck.ToShortDateString();
                if (MaptoDates.ContainsKey(a))
                {
                    MaptoDates[a].Add(i.Value);
                }
                else
                {
                    MaptoDates.Add(a, new List<ProtectionDevice>() { i.Value });
                }
            }
            foreach(var i in MaptoDates)
            {
                info($"{i.Key} => {i.Value.Count()} items contain");
            }
            info("Would you to save sata? [Y/n]");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                string filepath = inputString("Choose folder name: / ");
                if (Directory.Exists(filepath))
                {
                    Error("Folder is exists\nWould ovveride write? [Y/n]");
                    if(Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Directory.Delete(filepath, true );
                        Directory.CreateDirectory(filepath);
                    }
                }
                else
                {
                    Directory.CreateDirectory(filepath);
                }
                foreach(var i in MaptoDates)
                {
                    string filethis = filepath + "\\" + i.Key.Replace('/', '.') + ".json";
                    
                    File.Create(filethis).Close();
                    JSON<ProtectionDevice> jsonControl = new JSON<ProtectionDevice>(filethis);
                    dataJsonControllers.Add(jsonControl);
                    jsonControl.SaveOrUpdateJson(i.Value);
                }
                info("You can work with any file");
                goto default;
            }
            goto default;
        default:
            Error("Enter to select new action");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                goto againTask3;
            }
            break;
    }
}

WorkList(new Action[] {
    () => Task1(),
    () => Task2(),
    () => Task3()
});