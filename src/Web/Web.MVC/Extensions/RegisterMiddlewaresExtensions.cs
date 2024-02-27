using Web.MVC.ViewModels;

namespace Web.MVC.Extensions;

public static class RegisterMiddlewaresExtensions
{
    public static WebApplication ConfigureMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //app.UseStatusCodePages();
        app.UseStatusCodePagesWithReExecute("/{0}");
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        //app.MapControllerRoute(name: "detail", pattern: "catalog/p/{name}",  new { Controller = "Catalog", action = "ProductDetails"});
        //app.MapControllerRoute(name: "pagination", pattern: "catalog", new { Controller = "Catalog", action = "Index"});
        //app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapDefaultControllerRoute();

        return app;
    }
}