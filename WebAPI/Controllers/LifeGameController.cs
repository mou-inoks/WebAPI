using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class LifeGameController : Controller
    {
        [HttpPost("{id}")]

        public async Task<ActionResult<List<List<int>>>> Post(int id)
        {
            
            var lifeGameManager = new LifeGameManager();
            List<List<int>> current = new List<List<int>>() { };
            List<List<int>> next = new List<List<int>>() { };
            lifeGameManager.TableInitialisation(current, next);
            lifeGameManager.GenerateNextState(current, next, id);
            
            return next;
        }



    }
}
