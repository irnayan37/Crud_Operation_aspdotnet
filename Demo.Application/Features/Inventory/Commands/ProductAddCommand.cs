using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cortex.Mediator.Commands;
using Demo.Domain.Entities;

namespace Demo.Application.Features.Inventory.Commands
{
    public class ProductAddCommand : ICommand<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
