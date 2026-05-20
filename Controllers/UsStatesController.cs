using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsStatesController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public UsStatesController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsState>>> GetUsStates()
        {
            return await _context.UsStates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsState>> GetUsState(short id)
        {
            var s = await _context.UsStates.FindAsync(id);
            if (s == null) return NotFound();
            return s;
        }

        [HttpPost]
        public async Task<ActionResult<UsState>> PostUsState(UsState s)
        {
            _context.UsStates.Add(s);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsState), new { id = s.StateId }, s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsState(short id, UsState s)
        {
            if (id != s.StateId) return BadRequest();
            _context.Entry(s).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UsStates.Any(e => e.StateId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsState(short id)
        {
            var s = await _context.UsStates.FindAsync(id);
            if (s == null) return NotFound();
            _context.UsStates.Remove(s);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}