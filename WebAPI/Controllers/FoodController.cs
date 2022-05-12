using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class FoodController : Controller
    {
        private readonly DataContext _context;

        public FoodController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<FavoriteFood>>> Get()
        {
            var food = await _context.FavoriteFood.ToListAsync();
            return Ok(food);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<FavoriteFood>> Get(int id)
        {
            var food = await _context.FavoriteFood.FindAsync(id);
            if (food == null)
            {
                return BadRequest("Food not found");
            }
            return Ok(food);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<FavoriteFood>> Delete(int id)
        {
            var food = await _context.FavoriteFood.FindAsync(id);
            if (food == null)
            {
                return BadRequest("Food not found");
            }

            _context.FavoriteFood.Remove(food);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]

        public async Task<ActionResult<List<FavoriteFood>>> AddFavoriteFood([FromBody] FavoriteFood food)
        {
            _context.FavoriteFood.Add(food);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult<List<FavoriteFood>>> UpdateFavoriteFood(FavoriteFood request)
        {
            var food = await _context.FavoriteFood.FindAsync(request.Id);
            if(food == null)
            {
                return BadRequest("Food not found.");
            }
            food.Food = request.Food;

            await _context.SaveChangesAsync();
            
            return Ok(food);
        }


    }
}
