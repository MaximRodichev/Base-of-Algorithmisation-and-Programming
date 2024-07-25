using App.Persistanse.IEntity.EntityContext;
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
            Triangle triangle = new Triangle();
            triangle.Angle_1 = Angle_1;
            triangle.Angle_2 = Angle_2;
            triangle.Angle_3 = Angle_3;

            if (triangle.Angle_1 > 90 || triangle.Angle_2 > 90 || triangle.Angle_3 > 90)
            {
                triangle.Type = "Obtuse";
            }
            else if (triangle.Angle_1 == 90 || triangle.Angle_2 == 90 || triangle.Angle_3 == 90)
            {
                triangle.Type = "Right";
            }
            else
            {
                triangle.Type = "Acute";
            }

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
        public static async Task<Triangle> GetTriangle(int id)
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.FirstOrDefault(x => x.id == id);
            }
        }
        public static async Task<List<Triangle>> AllTriangles()
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.ToList();
            }
        }
        public static async Task<List<Triangle>> TrianglesByType(String type)
        {
            using (EntityContext.TriangleContext db = new EntityContext.TriangleContext())
            {
                return db.Triangles.Where(x => x.Type == type).ToList();
            }
        }
    }
}
