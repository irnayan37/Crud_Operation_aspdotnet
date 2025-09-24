using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product,Guid>
    {
    }
}
