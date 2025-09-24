using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
