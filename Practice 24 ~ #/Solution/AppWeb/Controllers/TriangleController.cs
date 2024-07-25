

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using static App.Persistanse.IEntity.EntityRepository.TriangleRepository;

namespace AppWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrianglesController : ControllerBase
    {
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            DeleteTriangle(id);
        }
        [HttpGet("Get/{id:int}")]
        public async Task<Triangle> Get(int id)
        {
            return await GetTriangle(id);
        }
        [HttpGet("Gets/{type}")]
        public async Task<List<Triangle>> GetTriangles(string type)
        {
            List<Triangle> a = await TrianglesByType(type);
            return a;
        }
        [HttpGet]
        public async Task<List<Triangle>> GetAll()
        {
            List<Triangle> a = await AllTriangles();
            return a;
        }
        [HttpPost("Create")]
        public async void CreateOne([FromBody] Triangle triangle) {
           await CreateTriangle(triangle.Angle_1, triangle.Angle_2, triangle.Angle_3);
        }
    }
}
