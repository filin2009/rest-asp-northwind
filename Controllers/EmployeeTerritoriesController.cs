using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTerritoriesController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public EmployeeTerritoriesController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTerritory>>> GetEmployeeTerritories()
        {
            return await _context.EmployeeTerritories.ToListAsync();
        }

        [HttpGet("{employeeId}/{territoryId}")]
        public async Task<ActionResult<EmployeeTerritory>> GetEmployeeTerritory(short employeeId, string territoryId)
        {
            var et = await _context.EmployeeTerritories.FindAsync(new object[] { employeeId, territoryId });
            if (et == null) return NotFound();
            return et;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeTerritory>> PostEmployeeTerritory(EmployeeTerritory et)
        {
            _context.EmployeeTerritories.Add(et);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeTerritory), new { employeeId = et.EmployeeId, territoryId = et.TerritoryId }, et);
        }

        [HttpDelete("{employeeId}/{territoryId}")]
        public async Task<IActionResult> DeleteEmployeeTerritory(short employeeId, string territoryId)
        {
            var et = await _context.EmployeeTerritories.FindAsync(new object[] { employeeId, territoryId });
            if (et == null) return NotFound();
            _context.EmployeeTerritories.Remove(et);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}