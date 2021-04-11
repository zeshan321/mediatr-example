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
    public class PatchOrderHandler : IRequestHandler<PatchOrderCommand, Order>
    {
        private readonly DatabaseContext _context;

        public PatchOrderHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(PatchOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            order.Cost = request.Order.Cost;
            order.CustomerId = request.Order.CustomerId;
            order.ShippedDate = request.Order.ShippedDate;

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
