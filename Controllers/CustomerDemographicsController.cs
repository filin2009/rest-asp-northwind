using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDemographicsController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public CustomerDemographicsController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDemographic>>> GetCustomerDemographics()
        {
            return await _context.CustomerDemographics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDemographic>> GetCustomerDemographic(string id)
        {
            var cd = await _context.CustomerDemographics.FindAsync(id);
            if (cd == null) return NotFound();
            return cd;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDemographic>> PostCustomerDemographic(CustomerDemographic cd)
        {
            _context.CustomerDemographics.Add(cd);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerDemographic), new { id = cd.CustomerTypeId }, cd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDemographic(string id, CustomerDemographic cd)
        {
            if (id != cd.CustomerTypeId) return BadRequest();
            _context.Entry(cd).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CustomerDemographics.Any(e => e.CustomerTypeId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDemographic(string id)
        {
            var cd = await _context.CustomerDemographics.FindAsync(id);
            if (cd == null) return NotFound();
            _context.CustomerDemographics.Remove(cd);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}