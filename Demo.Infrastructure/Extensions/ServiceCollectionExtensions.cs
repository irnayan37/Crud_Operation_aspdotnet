using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}