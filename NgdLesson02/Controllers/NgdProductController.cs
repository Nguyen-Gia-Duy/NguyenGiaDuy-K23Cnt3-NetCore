using Microsoft.AspNetCore.Mvc;

namespace NgdLesson02.Controllers
{
    public class NgdProductController : Controller
    {
        public IActionResult NgdIndex()
        {
            ViewData["messageData"] = "Du lieu tu viewData";
            ViewBag.messageViewBag = "Du lieu tu viewBag";
            TempData["messageTempData"]="Du lieu tu TempData";
            return View();
        }

    }
}
