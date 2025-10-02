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
            service.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

            //builder.Services.AddSingleton<IEmailUtililty, HtmlEmailUtility>();
            //builder.Services.AddTransient<IEmailUtililty,HtmlEmailUtility>();
            //builder.Services.AddScoped<IEmailUtililty, HtmlEmailUtility>();
            //builder.Services.AddKeyedScoped<IEmailUtililty, HtmlEmailUtility>("Setup1");//2 ta controller er alada alada setup constructor a dite hbe
            //builder.Services.AddKeyedScoped<IEmailUtililty, EmailUtility>("Setup2");
            //builder.Services.AddScoped(s =>
            // new ApplicationDbContext(connectionString, migrationAssembly?.FullName));
        }
    }
}