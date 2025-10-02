using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cortex.Mediator.Commands;
using Demo.Domain;
using Demo.Domain.Entities;

namespace Demo.Application.Features.Inventory.Commands
{
    public class ProductAddCommandHandler : ICommandHandler<ProductAddCommand, Product>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductAddCommandHandler(IApplicationUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductAddCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
            };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAync();
            return product;

        }
    }
}
