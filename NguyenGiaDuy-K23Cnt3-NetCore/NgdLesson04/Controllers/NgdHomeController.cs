using Microsoft.AspNetCore.Mvc;
using NgdLesson04.Models;
using System.Diagnostics;

namespace NgdLesson04.Controllers
{
    public class NgdHomeController : Controller
    {
        private readonly ILogger<NgdHomeController> _logger;

        public NgdHomeController(ILogger<NgdHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NgdIndex()
        {
            return View();
        }

        public IActionResult NgdAbout()
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
