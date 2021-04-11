using before.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace after.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<List<Order>>
    {

    }
}
