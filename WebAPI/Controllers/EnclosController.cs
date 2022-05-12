using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EnclosController : Controller
    {
        private readonly DataContext _context;

        public EnclosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Enclos>>> Get()
        {
            var enclos = await _context.Enclos.ToListAsync();
            return Ok(enclos);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Enclos>> Get(int id)
        {
            var enclos = await _context.Enclos.FindAsync(id);
            if (enclos == null)
                return BadRequest("Enclos not found ");
            return Ok(enclos);
        }

        [HttpGet("{id}/truncate")]

        public async Task<ActionResult<Enclos>> GetTruncate(int id)
        {
            var enclos = await _context.Enclos.FindAsync(id);
            if (enclos == null)
                return BadRequest("Enclos not found ");

            enclos.Type = enclos.Type.Substring(0, 1);
            return Ok(enclos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Enclos>>> Delete(int id)
        {
            var enclos = await _context.Enclos.FindAsync(id);
            if (enclos == null)
                return BadRequest("Enclos not found");
            _context.Enclos.Remove(enclos);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]

        public async Task<ActionResult<List<Enclos>>> AddEnclos([FromBody] Enclos enclos)
        {
            _context.Enclos.Add(enclos);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]

        public async Task<ActionResult<List<Enclos>>> UpdateEnclos(Enclos request)
        {
            var enclos = await _context.Enclos.FindAsync(request.Id);
            if (enclos == null)
            {
                return BadRequest("Animal not found.");
            }
            enclos.Type = request.Type;

            await _context.SaveChangesAsync();

            return Ok(enclos);
        }
    }
}

