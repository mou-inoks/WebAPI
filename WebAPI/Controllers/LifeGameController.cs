using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class LifeGameController : Controller
    {
        [HttpPost]

        public async Task<ActionResult<List<List<int>>>> Post(List<List<int>> current)
        {
            var lifeGameManager = new LifeGameManager();
           
            List<List<int>> next = new List<List<int>>() { };
            lifeGameManager.TableInitialisation(current, next);

            lifeGameManager.GenerateNextState(current, next);
            return next;
        }



    }
}
