using Demo.Application.Features.Inventory.Commands;
using Demo.Domain.Entities;
using Demo.Infrastructure.Data.Migrations;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductAddCommand,Product>();
        }
    }
}
