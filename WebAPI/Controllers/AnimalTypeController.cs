using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public AnimalTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalType>>> Get()
        {
            try
            {
                var animals = await _context.AnimalType.ToListAsync();
                return Ok(animals);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> Get(int id)
        {
            var animalType = await _context.AnimalType.FindAsync(id);
            if (animalType == null)
                return BadRequest("Animal Type not found.");
            return Ok(animalType);
        }

        [HttpPost]
        public async Task<ActionResult<List<AnimalType>>> AddAnimalType([FromBody]AnimalType animalType)
        {
            _context.AnimalType.Add(animalType);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<AnimalType>>> UpdateAnimalType(AnimalType request)
        {
            var dbAnimalType = await _context.AnimalType.FindAsync(request.Id);
            if (dbAnimalType == null)
                return BadRequest("Animal Type not found.");

            dbAnimalType.race = request.race;

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AnimalType>>> DeleteAnimalType(int id)
        {
            var dbAnimalType = await _context.AnimalType.FindAsync(id);
            if (dbAnimalType == null)
                return BadRequest("Animal Type not found.");

            _context.AnimalType.Remove(dbAnimalType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
