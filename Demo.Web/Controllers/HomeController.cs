using System.Diagnostics;
using Cortex.Mediator;
using Demo.Application.Features.Inventory.Commands;
using Demo.Application.Features.Inventory.Queries;
using Demo.Domain;
using Demo.Domain.Entities;
using Demo.Infrastructure;
using Demo.Infrastructure.Data;
using Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var command = new ProductAddCommand { Name = "Monitor", Price = 20000 };
            var product = await _mediator.SendCommandAsync<ProductAddCommand, Product>(command);

            //var query = new ProductGetQuery { Id = new Guid ("F24E7D8A-EE8A-4414-BE15-BDF01249D720") };
            //var result = await _mediator.SendQueryAsync<ProductGetQuery, Product>(query);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
