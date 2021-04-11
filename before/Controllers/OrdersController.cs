using before.Data;
using before.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace before.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetByOrderId(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(c => c.Id == id);
            return order == null ? NotFound() : Ok(order);
        }

        // PATCH: api/Orders/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchOrder(int id, Order body)
        {
            if (body.CustomerId == 0 || body.Cost <= 0)
            {
                return BadRequest();
            }

            var order = await _context.Orders.FindAsync(id);
            order.Cost = body.Cost;
            order.CustomerId = body.CustomerId;
            order.ShippedDate = body.ShippedDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (order.CustomerId == 0 || order.Cost <= 0)
            {
                return BadRequest();
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetByOrderId", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}
