using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class LifeGameController : Controller
    {
        [HttpPost]

        public async Task<ActionResult<List<List<int>>>> Post()
        {
            var lifeGameManager = new LifeGameManager();

            var tableau = lifeGameManager.TableInitialisation();
            tableau = lifeGameManager.GenerateNextState(tableau);
            return tableau;
        }



    }
}
