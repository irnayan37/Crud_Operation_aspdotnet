using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cortex.Mediator.Queries;
using Demo.Domain.Entities;

namespace Demo.Application.Features.Inventory.Queries
{
    public class ProductGetQuery : IQuery<Product>
    {
        public Guid Id { get; set; }
    }
}
