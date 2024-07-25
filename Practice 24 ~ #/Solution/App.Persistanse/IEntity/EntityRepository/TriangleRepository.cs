using App.Persistanse.IEntity.EntityContext;
using App.Persistanse.IEntity.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistanse.IEntity.EntityRepository
{
    public class TriangleRepository
    {
        public static async Task CreateTriangle(float Angle_1, float Angle_2, float Angle_3)
        {
            TriangleModel triangle = new TriangleModel();
            triangle.Angle_1 = Angle_1;
            triangle.Angle_2 = Angle_2;
            triangle.Angle_3 = Angle_3;

            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                db.Triangles.Add(triangle);
                await db.SaveChangesAsync();
            }
        }
        public static async void DeleteTriangle(int id)
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                var removeItem = db.Triangles.FirstOrDefault(x => x.id == id);
                if (removeItem != null)
                {
                    db.Triangles.Remove(removeItem);
                }
                else
                {
                    throw new Exception("Can't found a item");
                }
                await db.SaveChangesAsync();
            }
        }
        public static async Task<TriangleModel> GetTriangle(int id)
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.FirstOrDefault(x => x.id == id);
            }
        }
        public static async Task<List<TriangleModel>> AllTriangles()
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.ToList();
            }
        }
        public static async Task<List<TriangleModel>> TrianglesByType(TriangleType a)
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.Where(x => x.Type == a).ToList();
            }
        }
    }
}
