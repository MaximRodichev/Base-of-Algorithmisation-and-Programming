using System;
using System.Collections.Generic;
using static Instructs.Instructions;

namespace Solution_Console.Models
{
    internal class TriangleRepositoryBase
    {
        internal static void CreateTriangle()
        {
            Console.WriteLine($"Create a new treangle with id: {TriangleModel.id}");
        }
    }
    public class TriangleRepository
    {
        public static TriangleModel CreateTriangle()
        {
            TriangleRepositoryBase.CreateTriangle();
            again:
            float A_1 = Convert.ToSingle(inputInt("\nWrite me a Angle 1: "));
            float A_2 = Convert.ToSingle(inputInt("\nWrite me a Angle 2: "));
            float A_3 = Convert.ToSingle(inputInt("\nWrite me a Angle 3: "));
            TriangleModel model;
            try {
                model = new TriangleModel(A_1, A_2, A_3);
            }catch(Exception ex) { Error(ex.Message); goto again; }
            return model;
        }

        public static TriangleModel CreateTriangle(float a_1, float a_2, float a_3)
        {
            TriangleRepositoryBase.CreateTriangle();
            TriangleModel model;
            try
            {
                model = new TriangleModel(a_1, a_2, a_3);
                return model;
            }
            catch (Exception ex) { Error(ex.Message); return null; }
            
        }

        public static void Triangles(TriangleType type)
        {
            List<TriangleModel> targetList;
            if(type == TriangleType.Acute){targetList = TriangleModel.Acutes;
            }else if(type == TriangleType.Obtuse){
                targetList = TriangleModel.Obtuse;
            }
            else { targetList = TriangleModel.Rights; }
            if(targetList == null)
            {
                Instructs.Instructions.Error("Triangles by type not found");
                return;
            }
            foreach(TriangleModel x in targetList)
            {
                info(x.ToString());

            }
        }
    }
}
