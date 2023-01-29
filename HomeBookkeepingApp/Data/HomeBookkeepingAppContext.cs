using HomeBookkeepingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeBookkeepingApp.Data
{
    public class HomeBookkeepingAppContext : DbContext
    {
        public HomeBookkeepingAppContext(DbContextOptions<HomeBookkeepingAppContext> options)
                : base(options) { }
        public DbSet<Consumption> Consumptions => Set<Consumption>();
        public DbSet<Category> Categories => Set<Category>();
        
    }
}
