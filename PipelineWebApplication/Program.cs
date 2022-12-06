global using PipelineWebApplication.Models;
global using PipelineWebApplication.Data;
global using PipelineWebApplication.Models.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace PipelineWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PipelineAccountingContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("PipelineContext") ?? throw new InvalidOperationException("Connection string 'WebApplication1TestContext' not found.")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

           


          //  builder.Services.AddDbContext<Models.PipelineAccountingContext>(options =>
           //     options.UseNpgsql("Host=localhost;Port=5432;Database=PipelineAccounting;Username=postgres;Password=123"));
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}