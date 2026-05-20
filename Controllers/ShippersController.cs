using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public ShippersController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> GetShipper(short id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper == null) return NotFound();
            return shipper;
        }

        [HttpPost]
        public async Task<ActionResult<Shipper>> PostShipper(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShipper), new { id = shipper.ShipperId }, shipper);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipper(short id, Shipper shipper)
        {
            if (id != shipper.ShipperId) return BadRequest();
            _context.Entry(shipper).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Shippers.Any(e => e.ShipperId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(short id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper == null) return NotFound();
            _context.Shippers.Remove(shipper);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}