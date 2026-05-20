using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public RegionController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Region.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(short id)
        {
            var region = await _context.Region.FindAsync(id);
            if (region == null) return NotFound();
            return region;
        }

        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Region.Add(region);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRegion), new { id = region.RegionId }, region);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(short id, Region region)
        {
            if (id != region.RegionId) return BadRequest();
            _context.Entry(region).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Region.Any(e => e.RegionId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(short id)
        {
            var region = await _context.Region.FindAsync(id);
            if (region == null) return NotFound();
            _context.Region.Remove(region);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}