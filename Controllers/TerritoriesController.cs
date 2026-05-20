using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public TerritoriesController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Territory>>> GetTerritories()
        {
            return await _context.Territories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Territory>> GetTerritory(string id)
        {
            var territory = await _context.Territories.FindAsync(id);
            if (territory == null) return NotFound();
            return territory;
        }

        [HttpPost]
        public async Task<ActionResult<Territory>> PostTerritory(Territory territory)
        {
            _context.Territories.Add(territory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTerritory), new { id = territory.TerritoryId }, territory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerritory(string id, Territory territory)
        {
            if (id != territory.TerritoryId) return BadRequest();
            _context.Entry(territory).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Territories.Any(e => e.TerritoryId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerritory(string id)
        {
            var territory = await _context.Territories.FindAsync(id);
            if (territory == null) return NotFound();
            _context.Territories.Remove(territory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}