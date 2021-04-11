using after.Commands;
using after.Commands.Orders;
using before.Data;
using before.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace after.Handlers.Orders
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private readonly DatabaseContext _context;

        public DeleteOrderHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null)
            {
                return null;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
