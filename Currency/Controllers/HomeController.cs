using Currency.Models;
using Currency.Services;
using Currency.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Currency.Model;

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
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(ResultModel resultModel)
        {
            ValueConverterServices converterServices = new ValueConverterServices(dbContext);
            var result = converterServices.ConvertAndReturnResult(resultModel);
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
