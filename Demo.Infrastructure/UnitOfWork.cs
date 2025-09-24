using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
         public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public void save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAync()
        {
            await _dbContext.SaveChangesAsync();    
        }
    }
}
