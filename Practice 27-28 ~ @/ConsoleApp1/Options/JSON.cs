using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using System.Linq.Expressions;
namespace Practice_25____
{
    public class JSON<T>
    {
        public string filePath { get; }
        public JSON(string filepath) 
        {
            this.filePath = filepath;
        }
        public void DeleteObject(int id)
        {
            Dictionary<int, T> dictCurrent = GetDataJson();
            dictCurrent.Remove(id);
            File.WriteAllText(filePath, "");
            string jsonSerialize = JsonSerializer.Serialize<Dictionary<int, T>>(dictCurrent);
            File.WriteAllText(filePath, jsonSerialize);
        }
        public void UpdateObject(int Id, T value)
        {   
            Dictionary<int, T> dictCurrent = GetDataJson();
            dictCurrent[Id] = value;
            File.WriteAllText(filePath, "");
            string jsonSerialize = JsonSerializer.Serialize<Dictionary<int, T>>(dictCurrent);
            File.WriteAllText(filePath, jsonSerialize);
        }
        public Dictionary<int,T> GetDataJson()
        {
            string jsonString;
            Dictionary<int, T> jsonData = new Dictionary<int, T>();

            using (StreamReader json = new StreamReader(filePath))
            {
                jsonString = json.ReadToEnd();
                if (jsonString.Length > 5)
                {
                    jsonData = JsonSerializer.Deserialize<Dictionary<int, T>>(jsonString);

                }
                else return new Dictionary<int, T>();
            }
            if (jsonData != null || jsonData.Count > 0)
            {
                return jsonData;
            }
            else
            {
                Console.WriteLine("Not found objects");
                return null;
            }
        }
        public void SaveOrUpdateJson(List<T> addedNew)
        {
            string jsonString;
            Dictionary<int, T> jsonData = new Dictionary<int, T>();
            using (StreamReader json = new StreamReader(filePath))
            {
                jsonString = json.ReadToEnd();
                if(jsonString.Length > 3)
                {
                    jsonData = JsonSerializer.Deserialize<Dictionary<int, T>>(jsonString);
                }
            }
            int count = jsonData.Keys.Last()+1;
            foreach(var model in addedNew)
            {
                jsonData.Add(count++, model);
            }
            jsonString = JsonSerializer.Serialize<Dictionary<int, T>>(jsonData);
            File.WriteAllText(filePath, jsonString);
        }
        public void SaveOrUpdateJson(T model)
        {
            try
            {
                string jsonString;
                Dictionary<int, T> jsonData = new Dictionary<int, T> { };
                using (StreamReader json = new StreamReader(filePath))
                {
                    jsonString = json.ReadToEnd();
                    if (jsonString.Length > 3)
                    {
                        jsonData = JsonSerializer.Deserialize<Dictionary<int, T>>(jsonString);
                    }
                }
                jsonData.Add(jsonData.Keys.Last()+1, model);
                jsonString = JsonSerializer.Serialize<Dictionary<int, T>>(jsonData);

                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
