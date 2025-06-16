using Microsoft.AspNetCore.Mvc;
using NgdLesson05.Models;
using NgdLesson05.Models.DataModel;
using System.Diagnostics;

namespace NgdLesson05.Controllers
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
            NgdMember ngdMember = new NgdMember();
            ngdMember.NgdMemberId=Guid.NewGuid().ToString();
            ngdMember.NgdUserName = "Nguyen Duy";
            ngdMember.NgdPassword = "123456@";
            ngdMember.NgdFullName = "Nguyen Gia Huy";
            ngdMember.NgdEmail = "duy@gmail.com";
            return View(ngdMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
