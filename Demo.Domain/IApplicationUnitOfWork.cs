using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Repositories;

namespace Demo.Domain
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
    }
}
