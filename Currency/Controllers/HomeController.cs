using Currency.Models;
using Currency.Services;
using CurrencyConverterApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Currency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly GetCurrentAmound getCurrent;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,GetCurrentAmound getCurrent,ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.configuration = configuration;
            this.getCurrent = getCurrent;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCurrentAmound()
        {
            getCurrent.GetResponse(dbContext);
            
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
