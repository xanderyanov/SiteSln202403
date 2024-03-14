using Microsoft.AspNetCore.Mvc;

namespace SiteStore.Areas.Site.Controllers
{
    [Area("Site")]
    public class HomeController : Controller
    {
        Domain domain = Data.MainDomain;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            var posts = domain.ExistingPosts.OrderByDescending(x => x.CreatedDate).ToList();

            return View("Blog", posts);
        }
    }
}
