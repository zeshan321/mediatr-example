using after.Commands.Orders;
using after.Queries.Orders;
using before.Data;
using before.Data.Models;
using MediatR;
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
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetByOrderId(int id)
        {
            var query = new GetByOrderIdQuery()
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        // PATCH: api/Orders/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchOrder(int id, Order order)
        {
            var command = new PatchOrderCommand()
            {
                Id = id,
                Order = order
            };

            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var command = new PostOrderCommand()
            {
                Order = order
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction("GetByOrderId", new { id = result.Id }, result);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand()
            {
                Id = id
            };

            var result = await _mediator.Send(command);
            return result == null ? BadRequest() : Ok(result);
        }
    }
}
