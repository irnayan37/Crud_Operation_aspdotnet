using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Data;

namespace Demo.Infrastructure
{
    public abstract class ApplicationUnitOfWork : UnitOfWork,IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get;private set; }
        public ApplicationUnitOfWork(ApplicationDbContext context,IProductRepository productRepository)
            : base(context)
        {
            ProductRepository = productRepository;
        }

    }
}
