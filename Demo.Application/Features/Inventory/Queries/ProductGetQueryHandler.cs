using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cortex.Mediator.Queries;
using Demo.Domain;
using Demo.Domain.Entities;

namespace Demo.Application.Features.Inventory.Queries
{
    public class ProductGetQueryHandler : IQueryHandler<ProductGetQuery, Product>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductGetQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductGetQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(query.Id); 
        }
    }
}
