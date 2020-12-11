using Currency.Models;
using Currency.Services;
using CurrencyConverterApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Currency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly GetCurrentAmoundAsync getCurrent;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,GetCurrentAmoundAsync getCurrent,ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.configuration = configuration;
            this.getCurrent = getCurrent;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(dbContext);
        }

        [HttpGet]
        public IActionResult ReturnResult()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentAmound()
        {
           await getCurrent.GetResponseAsync(dbContext);
            
            return Redirect("/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
