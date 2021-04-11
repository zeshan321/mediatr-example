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
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private readonly DatabaseContext _context;

        public GetAllOrdersHandler(DatabaseContext context)
        {
            _context = context;
        }

        public Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return _context.Orders.ToListAsync();
        }
    }
}
