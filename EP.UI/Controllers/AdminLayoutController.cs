using Microsoft.AspNetCore.Mvc;

namespace EP.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
