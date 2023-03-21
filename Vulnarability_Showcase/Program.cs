using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vulnarability_Showcase.Models;
using Vulnarability_Showcase.Services;
using Vulnarability_Showcase.Services.Interfaces;
#pragma warning disable ASP0014 // Suggest using top level route registrations

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Issue: Do not keep sensitive data in the source code
    options.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Vulnarability;Trusted_Connection=True;");
});
// Add services to the container.
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

//app.MapRazorPages();
app.UseEndpoints( 
    endPoints =>
    {
        //endPoints.MapRazorPages();
        endPoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });

app.Run();
