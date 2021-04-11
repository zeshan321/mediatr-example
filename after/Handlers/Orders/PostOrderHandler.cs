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
    public class PostOrderHandler : IRequestHandler<PostOrderCommand, Order>
    {
        private readonly DatabaseContext _context;

        public PostOrderHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(PostOrderCommand request, CancellationToken cancellationToken)
        {
            _context.Orders.Add(request.Order);
            await _context.SaveChangesAsync();
            return request.Order;
        }
    }
}
