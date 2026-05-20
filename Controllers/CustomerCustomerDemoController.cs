using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCustomerDemoController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public CustomerCustomerDemoController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCustomerDemo>>> GetItems()
        {
            return await _context.CustomerCustomerDemo.ToListAsync();
        }

        [HttpGet("{customerId}/{typeId}")]
        public async Task<ActionResult<CustomerCustomerDemo>> GetItem(string customerId, string typeId)
        {
            var item = await _context.CustomerCustomerDemo.FindAsync(new object[] { customerId, typeId });
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCustomerDemo>> PostItem(CustomerCustomerDemo item)
        {
            _context.CustomerCustomerDemo.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { customerId = item.CustomerId, typeId = item.CustomerTypeId }, item);
        }

        [HttpDelete("{customerId}/{typeId}")]
        public async Task<IActionResult> DeleteItem(string customerId, string typeId)
        {
            var item = await _context.CustomerCustomerDemo.FindAsync(new object[] { customerId, typeId });
            if (item == null) return NotFound();
            _context.CustomerCustomerDemo.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}