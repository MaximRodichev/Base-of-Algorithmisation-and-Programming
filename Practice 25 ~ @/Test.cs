using Practice_25____._1Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Instructs.Instructions;

namespace Practice_25____
{
    public interface ITest<T>
    {
        public List<T> CreatingData();
    }
    public class Test<T>
    {
        private JSON<T> parser;
        private ITest<T> CreateTest;
        public Test(string filePath, ITest<T> testCreate)
        {
            parser = new JSON<T>(filePath);
            this.CreateTest = testCreate;
        }
        public void Run()
        {
            infoWithStrikeLine($"Start test with {parser.filePath}");
            info("Creation Test");
            parser.SaveOrUpdateJson(CreateTest.CreatingData());
            string textInfo = "Select a action;\n1 -- Check all items\n2 -- Check item by id\n";
            Dictionary<int, T> data = new Dictionary<int, T>();
            int curItem = 0;
            T itemThis = default(T);
            bool flagChanged = false;
            again:
            switch (inputInt(textInfo))
            {
                case 1:
                    data = parser.GetDataJson();
                    foreach (var item in data)
                    {
                        info($"{item.Key}:\n{item.Value}");
                    }
                    goto default;
                case 2:
                    curItem = inputInt("Get id: ");
                    itemThis = data[curItem];
                    info(itemThis.ToString());
                    info("Want to update this item? Press Spacebar - yes");
                    if(Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        flagChanged = true;
                        goto case 3;
                    }
                    goto default;
                case 3:
                    if (flagChanged)
                    {
                        var information = itemThis.GetType().GetProperties();
                        for(int i = 0; i < information.Length; i++)
                        {
                            var property = information[i];
                            info($"{i}  -  {property.Name}");
                        }
                        int choose = inputInt("Choose to update");
                        try
                        {
                            var property = information[choose];
                            info($"{property.Name}: {property.GetValue(itemThis)}");
                            string update = inputString("Set new value: ");
                            property.SetValue(itemThis, update);
                            info(itemThis.ToString());
                            parser.UpdateObject(curItem, itemThis);
                            data = parser.GetDataJson();
                            info("Exit? Press Space to exit");
                            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                            {
                                goto default;
                            }
                        }
                        catch
                        {

                        }
                        
                    }
                    flagChanged = false;
                    goto default;
                default:
                    info("Restart? Press Space to exit");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar) {
                        break;
                    }
                    goto again;
            }
        }
    }
}
