using Microsoft.AspNetCore.Mvc;

namespace SiteStore.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
