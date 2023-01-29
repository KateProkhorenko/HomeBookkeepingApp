using HomeBookkeepingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeBookkeepingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HomeBookkeepingAppContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:HBConnection"]);
            });
            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapRazorPages();

            var context = app.Services.CreateScope().ServiceProvider
                             .GetRequiredService<HomeBookkeepingAppContext>();
            SeedHB.SeedDatabase(context);

            app.Run();
        }
    }
}