using Practice_25____;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Options
{
    public class ValidationModel
    {
        public static bool Validate(ClientModel a, JSON<ClientModel> b)
        {
            if(b.GetDataJson().Values.Where(x=> x.Id == a.Id).Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
