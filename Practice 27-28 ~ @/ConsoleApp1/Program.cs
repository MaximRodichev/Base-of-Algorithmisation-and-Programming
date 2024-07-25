//Дан список, содержащий информацию о клиентах пункта проката автомобилей:
//ФИО и марка машины. Отсортировать его марке машины.
//Записать в стек данные только тех людей, кто ездит на "Audi",
//предварительно удалив их из исходного списка.
//Организовать запрос на наличие в исходном списке требуемого человека. 
using System;
using System.Data;
using System.Text.Json;
using App.Task2;
using ConsoleApp1.Options;
using Practice_25____;
using static Instructs.Instructions;
Dictionary<string, List<KeyValuePair<int, ClientModel>>>? sortByMarks(Dictionary<int, ClientModel> data)
{
    var autoFirmClients = data
.GroupBy(client => client.Value.Description)
.ToDictionary(
    group => group.Key,
    group => group.ToList()
);
    return autoFirmClients;
}


string TEXT_Switch = "Choose the action\n" +
    "1 - GenerateData to Test\n" +
    "2 - Sorted List View\n" +
    "3 - Get Stack of Audi Customers\n" +
    "4 - Edit Data\n" +
    "5 - Get Clients with expired time\n" +
    "6 - Exit" +
    "\n";
void Task1()
{
    if (!File.Exists("Clients.json"))
    {
        File.Create("Clients.json").Close();
    }
    JSON<ClientModel> clientsJson = new JSON<ClientModel>("Clients.json");
    infoWithStrikeLine("Hello to AutoRent Service");
Start:
    Dictionary<int, ClientModel> dataFile;
    Dictionary<int, ClientModel> dataFile_Lost;
    Dictionary<string, List<KeyValuePair<int, ClientModel>>>? sortData;
    Stack<ClientModel> dataStack;
    
    try
    {
        dataFile = clientsJson.GetDataJson();
        dataStack = new Stack<ClientModel>(dataFile.Values.Where(x => x.Description == "Audi"));
        sortData = sortByMarks(dataFile);
        dataFile_Lost = dataFile.Where(x => x.Value.EndExplotation < DateTime.Now).ToDictionary();
    }
    catch
    {
        Error("Error at get Data from json");
        dataFile = new Dictionary<int, ClientModel>();
        dataStack = new Stack<ClientModel>();
        sortData = new Dictionary<string, List<KeyValuePair<int, ClientModel>>>();
        dataFile_Lost = new Dictionary<int, ClientModel>();
    }
    if (dataFile_Lost.Count() > 0)
    {
        info("This Clients are Lost: ", ConsoleColor.Red);
        info($"{string.Join("\n\n", dataFile_Lost.Values)}", ConsoleColor.White);
        info("Would you like to delete this clients from data? [Y/n]");
        if(Console.ReadKey().Key == ConsoleKey.Y)
        {
            foreach(var item in dataFile_Lost)
            {
                clientsJson.DeleteObject(item.Key);
            }
            info("Deletes done");
            Console.ReadKey();
            Console.Clear();
            goto Start;
        }
    }
    switch (inputInt(TEXT_Switch))
    {
        case 1:
            List<ClientModel> dataThis = new List<ClientModel>();
            foreach (var a in Enumerable.Range(0, 10))
            {
                var model = new ClientModel()
                {
                    Name = Generator.GenerateRandomName() + " " + Generator.GenerateRandomSurname(),
                    Description = Generator.GenerateAutoFirm(),
                    StartExplotation = DateTime.Now,
                    EndExplotation = DateTime.Now.AddHours(new Random().Next(12, 48))
                };
                if (ValidationModel.Validate(model, clientsJson))
                {
                    dataThis.Add(model);
                }
            }
            clientsJson.SaveOrUpdateJson(dataThis);
            info($"CountMembers: {dataThis.Count()}");
            goto default;
        case 2:
            foreach(var item in sortData)
            {
                Console.Clear() ;
                info($"\n{item.Key}", ConsoleColor.White);
                info($"{string.Join("\n", item.Value)}");
                info("\n\nAny key to next, enter to exit", ConsoleColor.Green);
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    goto Start;
                }
            }
            info("All data", ConsoleColor.Magenta);
            Console.ReadKey();
            goto Start;
        case 3:
            infoWithStrikeLine("Audi Customers");
            foreach (var item in dataStack)
            {
                info($"{item.ToString()}");
            }
            goto default;
        case 4:
        StartEdit:
            Console.Clear();
            int choosen = inputInt("Choose the action:\n1-- Delete Client\n2-- Add Client\n3-- Update ClientData\n4-- Return to MainMenu\n");
            if(choosen == 1 || choosen == 3)
            {
                infoWithStrikeLine("edit Data");
                foreach (var item in dataFile)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{item.Value.Id} => ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{item.Value.Name}  |  {item.Value.Description}\n");
                }
                int id = inputInt("Get me a id of client: ");
                ClientModel? modelEdit = dataFile.Values.FirstOrDefault(x => x.Id == id);
                if (modelEdit == null)
                {
                    info("Not Found user by id");
                        Console.ReadKey();
                    goto default;
                }
                Console.Clear();
                info($"Edit model:\n{modelEdit}\n", ConsoleColor.White);
                if (choosen == 1)
                {
                    Console.WriteLine("Delete this item [Y/n]");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        try
                        {
                            clientsJson.DeleteObject(dataFile.First(x => x.Value.Id == id).Key);
                            info("Successfull delete item");
                        }
                        catch (Exception e) { Error($"{e.Message}"); }
                        Console.ReadKey();
                        Console.Clear();
                        goto defaults;
                    }
                    else
                    {
                        Console.Clear();
                        goto defaults;
                    }
                }
                else if (choosen == 3)
                {
                    string newName = modelEdit.Name;
                    string newAuto = modelEdit.Description;
                    DateTime newDateEnd = modelEdit.EndExplotation;
                againEdit:
                    Console.Clear();
                    info(modelEdit.ToString());
                    int choose = inputInt("Update Client Data\n1 -- Name, 2 -- AutoRent, 3 -- EndExplotation, 4 -- Save this\n");
                    if (choose == 1)
                    {
                        newName = inputString("Name: ");
                        modelEdit.Name = newName;
                        goto againEdit;

                    }
                    else if (choose == 2)
                    {
                        newAuto = inputString("AutoRent: ");
                        modelEdit.Description = newAuto;
                        goto againEdit;
                    }
                    else if (choose == 3)
                    {
                        newDateEnd = newDateEnd.AddDays(inputInt("How many days add?: ")).AddHours(inputInt("How many hours add?: "));
                        modelEdit.StartExplotation = DateTime.Now;
                        modelEdit.EndExplotation = newDateEnd;
                        goto againEdit;
                    }
                    else if (choose == 4)
                    {
                        clientsJson.UpdateObject(dataFile.First(x => x.Value.Id == modelEdit.Id).Key, modelEdit);
                        info("Update Successful");
                        Console.Clear();
                        goto Start;
                    }
                    else
                    {
                        Error("Not found action, please retry");
                        goto defaults;
                    }
                    goto defaults;
                }
            }
            else if (choosen == 2)
            {
                Console.Clear();
                info("Add Client Dialogue", ConsoleColor.White);
                string Name = inputString("Please give a Name data: ");
                string Decs = inputString("Please give a auto data:");
                int hours = inputInt("How many hours to rent? => ");
                var customer = new ClientModel()
                {
                    Description = Decs,
                    Name = Name,
                    EndExplotation = DateTime.Now.AddHours(hours)
                };
                info(customer.ToString());
                info("View data and agree with [Y/n]");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    clientsJson.SaveOrUpdateJson(customer);
                    info("Successful Save data", ConsoleColor.Green);
                    Console.ReadKey();
                }
                Console.Clear();
                goto Start;
            }
            defaults:
            #region

            Console.Clear();
            Error("Want to actionEdit again? [Y/n]");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                goto StartEdit;
            }
                    else
                    {
                goto Start;
                    }
            #endregion
        case 5:
            int expiredHours = inputInt("Please get me a expired time (in hours): ");
            info(string.Join("\n", dataFile.Values.Where(x=> x.EndExplotation < DateTime.Now.AddHours(expiredHours))));
            goto default;
        default:
            Error("Enter to exit");
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                break;
            }
            else
            {
                Console.Clear();
                goto Start;
            }

    }
}

void createFile(string filePath) {
    if (!File.Exists(filePath))
    {
        File.Create(filePath).Close();
    }
}

void Task2()
{
    string filePath = "solution.json";
    createFile(filePath);

    string fileStringData = File.ReadAllText(filePath); 
    Dictionary<int, clientBase> dataFromFile = JsonSerializer.Deserialize<Dictionary<int, clientBase>>(fileStringData);
    foreach(var item in dataFromFile)
    {
        info($"{item.Value.Birthday} => {item.Value.name}");
    }
    Dictionary<int,clientBase> data = new Dictionary<int,clientBase>();
    info($"{dataFromFile.Last().Key}");
    foreach(var i in Enumerable.Range(0, 10))
    {
        data.Add(i + dataFromFile.Last().Key + 1,
            new clientBase()
            {
                name = Generator.GenerateRandomName(),
                Birthday = DateTime.Now.AddYears(new Random().Next(-100,-10))
            }

            );
    }

    var saveData = dataFromFile.Concat(data).ToDictionary();
    string savesString = JsonSerializer.Serialize<Dictionary<int, clientBase>>(saveData);
    File.WriteAllText(filePath, savesString);

}

Task2();