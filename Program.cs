using Intex2023.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Intex_Database2023Context>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Intex_Database2023Context>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("everything", "{headdir}/Page{pageNum}/Sex{sex}/Adult{adult}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("headSexPage", "{headdir}/Page{pageNum}/Sex{sex}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("headAdulPage", "{headdir}/Page{pageNum}/Adult{adult}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("sexAdultPage", "Page{pageNum}/Sex{sex}/Adult{adult}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("sexPage", "Sex{sex}/Page{pageNum}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("headDirectionPage", "{headdir}/Page{pageNum}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("adultPage", "{adult}/Page{pageNum}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("Paging", "Page{pageNum}", new { Controller = "Home", action = "Burials" });

    endpoints.MapControllerRoute("headDirection", "{headdir}", new { Controller = "Home", action = "Burials", pageNum = 1 });

    endpoints.MapControllerRoute("sex", "Sex{sex}", new { Controller = "Home", action = "Burials", pageNum = 1 });

    endpoints.MapControllerRoute("adult", "Adult{adult}", new { Controller = "Home", action = "Burials", pageNum = 1 });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();
});

app.Run();
