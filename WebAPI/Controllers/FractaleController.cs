using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class FractaleController : Controller
    {
        public Manager manager;
        
        [HttpPost]

        public async Task<ActionResult<List<Point>>> Post([FromBody] Fractale fractale)
        {
            var manager = new Manager();
            return manager.GeneratePoints(fractale);
      
        }

        
    }

}
