using before.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace after.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
