using after.Queries;
using after.Queries.Orders;
using before.Data;
using before.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace after.Handlers.Orders
{
    public class GetByOrderIdHandler : IRequestHandler<GetByOrderIdQuery, Order>
    {
        private readonly DatabaseContext _context;

        public GetByOrderIdHandler(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Order> Handle(GetByOrderIdQuery request, CancellationToken cancellationToken)
        {
            return _context.Orders.SingleOrDefaultAsync(c => c.Id == request.Id);
        }
    }
}
