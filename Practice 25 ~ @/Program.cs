using Practice_25____;
using Practice_25____._1Task;
using Practice_25____._3Task;
using System.Text.Json;
using static Instructs.Instructions;



void Task1()
{
    Test<ScientistModel> testScience = new Test<ScientistModel>("scientists.json", new ScientistTest());
    testScience.Run();
}
//Zаписать в файл g все чётные числа файла f, а в файл h все нечётные. 
//Порядок следования чисел сохраняется.
void Task2()
{
    #region
    string fileG_path = "G_file.json";
    File.Create(fileG_path).Close();
    File.WriteAllText(fileG_path, "");
    JSON<int> fileG_json = new JSON<int>(fileG_path);
    
    string fileF_path = "F_file.json";
    File.Create(fileF_path).Close();
    File.WriteAllText(fileF_path, "");
    JSON<int> fileF_json = new JSON<int>(fileF_path);
    
    string fileH_path = "H_file.json";
    File.Create(fileH_path).Close();
    File.WriteAllText(fileH_path, "");
    JSON<int> fileH_json = new JSON<int>(fileH_path);
    #endregion 
    Random rand = new Random();
    List<int> data = new List<int>();
    foreach (var item in Enumerable.Range(0,10))
    {
        data.Add(rand.Next(100));
    }
    fileF_json.SaveOrUpdateJson(data);
    info("FILE F DATA");
    List<int> dataFromFile = fileF_json.GetDataJson().Values.ToList();
    foreach(var item in fileF_json.GetDataJson())
    {
        info($"{item.Key} => {item.Value}");
        if(item.Value%2 == 0)
        {
            fileG_json.SaveOrUpdateJson(item.Value);
        }
        else
        {
            fileH_json.SaveOrUpdateJson(item.Value);
        }
    }
    info("FILE G");
    foreach(var item in fileG_json.GetDataJson())
    {
        info($"{item.Key} => {item.Value}");
    }
    info("FILE H");
    foreach (var item in fileH_json.GetDataJson())
    {
        info($"{item.Key} => {item.Value}");
    }
}
//первом файле хранится k матриц размерности m × n, во втором - l 
//матриц размерности m x n. Поменять местами все четные (по порядковому номеру в файле) матрицы из первого и второго файлов (до конца 
//меньшего из файлов). Вывести на экран содержимое первого и второго 
//файлов.
void Task3()
{
    #region
    string fileFirst = "matrixies_1.json";
    string fileSecond = "matrixies_2.json";
    File.Create(fileFirst).Close();
    File.Create(fileSecond).Close();
    File.WriteAllText(fileFirst, "");
    File.WriteAllText(fileSecond, "");
    JSON<Dictionary<int, List<int>>> matrixJson_First = new JSON<Dictionary<int, List<int>>>(fileFirst);
    JSON<Dictionary<int, List<int>>> matrixJson_Second = new JSON<Dictionary<int, List<int>>>(fileSecond);
    #endregion
    #region
    Random rand = new Random();
    var data_1 = new  List<Dictionary<int, List<int>>>();
    var data_2 = new List<Dictionary<int, List<int>>>();
    int k = inputInt("Введите K матриц первого файла: ");
    foreach (var i in Enumerable.Range(0, k))
    {
        data_1.Add(new MatrixModel().data);
    }
    int l = inputInt("Введите L матриц первого файла: ");
    foreach (var i in Enumerable.Range(0, l))
    {
        data_2.Add(new MatrixModel().data);
    }
    matrixJson_First.SaveOrUpdateJson(data_1);
    matrixJson_Second.SaveOrUpdateJson(data_2);
    #endregion
    info("Data NOW");
    info("data of 1st File");
    foreach (var item in matrixJson_First.GetDataJson())
    {
        Console.WriteLine($"{item.Key}:\n{MatrixModel.View(item.Value)}");
    }
    info("data of 2nd File");
    foreach (var item in matrixJson_Second.GetDataJson())
    {
        Console.WriteLine($"{item.Key}:\n{MatrixModel.View(item.Value)}");
    }
    inputString("Any key to start moving");
    var data_1_fromfile = matrixJson_First.GetDataJson();
    var data_2_fromfile = matrixJson_Second.GetDataJson();
    int count = data_1_fromfile.Count < data_2_fromfile.Count ? data_1_fromfile.Count : data_2_fromfile.Count;
    foreach(var item in Enumerable.Range(0, count))
    {
        if (item % 2 == 0)
        
        {
            var a = data_1_fromfile.Values.ToList()[item];
                matrixJson_First.UpdateObject(item, data_2_fromfile.Values.ToList()[item]);
                matrixJson_Second.UpdateObject(item, a);
        }
    }
    Console.ForegroundColor = ConsoleColor.Green;
    info("Data after Moving");
    info("data of 1st File");
    foreach (var item in matrixJson_First.GetDataJson())
    {
        if(item.Key % 2 == 0)
        {
            Console.WriteLine($"{item.Key}:\n{MatrixModel.View(item.Value)}");
        }
    }
    info("data of 2nd File");
    foreach (var item in matrixJson_Second.GetDataJson())
    {
        if (item.Key % 2 == 0)
        {
            Console.WriteLine($"{item.Key}:\n{MatrixModel.View(item.Value)}");
        }
    }
}

WorkList(new Action[]{
    () => Task1(),
    () => Task2(),
    () => Task3()
});