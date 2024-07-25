using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_25____._3Task
{
    public class MatrixModel
    {
        public Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();
        private int rows;
        private int cols;
        public MatrixModel(){ 
            Random rand = new Random();
            this.rows = rand.Next(4,6);
            this.cols = rand.Next(4,6);
            for (int i = 0; i < this.rows; i++)
            {
                List<int> list = new List<int>();
                for(int j = 0; j<this.cols; j++)
                {
                    list.Add(rand.Next(20));
                }
                data.Add(i, list);
            }
        }
        public static string View(Dictionary<int, List<int>> data)
        {
            string dataS = "";
            foreach (var item in data) {
                dataS += $"Row: {item.Key} \t=>\t {string.Join("\t", item.Value)}\n";
            }
            return dataS; 
        }
       

    }
    
}
