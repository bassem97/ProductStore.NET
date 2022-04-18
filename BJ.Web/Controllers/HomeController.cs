using BJ.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BJ.Web.Models;

namespace BJ.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> lp = new List<Product>()
            {
                new Product()
                {
                     //ProductId = 2,
                     Description = "description1",
                     Label = "prod1",
                     Quantity = 12,
                     Price = 10,
                },
                new Product()
                {
                     //ProductId = 2,
                     Description = "description2",
                     Label = "prod2",
                     Quantity = 15,
                     Price = 10,
                }
            };
            ViewBag.Number = 10;
            ViewData["Numero"] = 15;
            return View(lp);

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
