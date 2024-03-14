using SiteStore;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using SiteStore.Areas.Admin.Controllers;
using SiteStore.Areas.Site.Controllers;
using SiteStore.Models;

var Prov = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(Prov);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

Data.InitData(builder.Configuration);


var app = builder.Build();

Configure(app);



static void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();
    app.UseSession();


    app.MapWhen(
    context => Settings.AdminHostNameConstraint.Match(context),
    branch =>
    {

        branch.UseRouting();



        branch.UseEndpoints(endpoints =>
        {

            endpoints.MapControllerRoute(
                name: "Default",
                pattern: "Blog/{action}/{id?}",
                defaults: new { area = "Admin", controller = nameof(BlogController)[..^10], action = "Index" }
            ).WithDisplayName("Blog");

            endpoints.MapControllerRoute(
                name: "Default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { area = "Admin", controller = nameof(AdminController)[..^10], action = "Index" }
            ).WithDisplayName("AdminDefault");

        });
    }
);

    app.MapWhen(
        context => Settings.SiteHostNameConstraint.Match(context),
        branch =>
        {

            branch.UseRouting();

            branch.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "Product",
                //    pattern: "Product/{id?}",
                //    defaults: new { area = "Site", controller = nameof(ProductController)[..^10], action = "Index" }
                //).WithDisplayName("SiteProduct");

                //endpoints.MapControllerRoute(
                //    name: "Catalog",
                //    pattern: "Catalog/{id?}",
                //    defaults: new { area = "Site", controller = nameof(CatalogController)[..^10], action = "Index" }
                //).WithDisplayName("SiteCatalog");


                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{action}/{id?}",
                    defaults: new { area = "Site", controller = nameof(HomeController)[..^10], action = "Index" }
                ).WithDisplayName("SiteDefault");

            });
        }
    );

    //app.UseEndpoints(endpoints => {

    //    endpoints.MapControllerRoute("Product",
    //       "Product/{id?}",
    //       new { controller = "Product", action = "Index" });

    //    endpoints.MapControllerRoute("Catalog",
    //        "Catalog/{id?}",
    //        new { controller = "Catalog", action = "Index" });

    //    endpoints.MapControllerRoute("Default",
    //       "{controller}/{action}/{id?}",
    //       new { controller = "Home", action = "Index" });

    //    endpoints.MapDefaultControllerRoute();
    //});

}

app.MapRazorPages();

app.Run();
