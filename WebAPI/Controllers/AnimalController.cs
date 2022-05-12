using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly DataContext _context;

        public AnimalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Animal>>> Get()
        {
            var animals = await _context.Animals.ToListAsync();

            return Ok(animals);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Animal>>> Delete(int id)
        {
            var animals = await _context.Animals.FindAsync(id);
            if (animals == null)
                return BadRequest("Animal not found");
            _context.Animals.Remove(animals);
            
           await _context.SaveChangesAsync();  

            return NoContent();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Animal>>> Get(int id)
        {
            var animals = await _context.Animals.FindAsync(id);
            if(animals == null)
                return BadRequest("Animal not found");
            return Ok(animals);
        }

        [HttpPost]

        public async Task<ActionResult<List<Animal>>> AddAnimal([FromBody] Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]

        public async Task<ActionResult<List<Animal>>> UpdateAnimal(Animal request)
        {
            var animal = await _context.Animals.FindAsync(request.Id);
            if (animal == null)
            {
                return BadRequest("Animal not found.");
            }
            animal.Nom = request.Nom;
            animal.Age = request.Age;

            await _context.SaveChangesAsync();

            return Ok(animal);
        }
    }
}
