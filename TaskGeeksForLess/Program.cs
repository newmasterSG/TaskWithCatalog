using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System;
using TaskGeeksForLess.Data;
using TaskGeeksForLess.IServices;
using TaskGeeksForLess.Services;

namespace TaskGeeksForLess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICatalogService, CatalogService>();
            builder.Services.AddDbContext<TaskGeeksForLessContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TaskGeeksForLessContext") ?? throw new InvalidOperationException("Connection string 'TaskGeeksForLessContext' not found.")));


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            Seeds.Seed(app);

            app.Run();
        }
    }
}