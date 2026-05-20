using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public OrderDetailsController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(short orderId, short productId)
        {
            var od = await _context.OrderDetails.FindAsync(new object[] { orderId, productId });
            if (od == null) return NotFound();
            return od;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail od)
        {
            _context.OrderDetails.Add(od);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderDetail), new { orderId = od.OrderId, productId = od.ProductId }, od);
        }

        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(short orderId, short productId)
        {
            var od = await _context.OrderDetails.FindAsync(new object[] { orderId, productId });
            if (od == null) return NotFound();
            _context.OrderDetails.Remove(od);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}