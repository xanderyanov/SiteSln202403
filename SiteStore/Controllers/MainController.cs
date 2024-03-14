using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SiteStore
{
    public class BaseBucket
    {
        //internal string SelectedCategory;

        public string Title { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        //public TUser User { get; set; }
        //public string UserName { get; set; }

    }

    public class MainController : Controller
    {
        public BaseBucket Bucket;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Bucket = new BaseBucket();
            
            ViewData["Bucket"] = Bucket;

            base.OnActionExecuting(context);
        }

        //public class ViewSettingsClass
        //{
        //    public bool NewOnly { get; set; } = false;
        //    public bool SaleLeaderOnly { get; set; } = false;
        //    public string InexpensivePrice { get; set; }

        //}
    }
}
