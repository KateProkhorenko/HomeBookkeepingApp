using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeBookkeepingApp.Pages
{
    public class StatisticsModel : PageModel
    {
        private HomeBookkeepingAppContext context;
        public StatisticsModel(HomeBookkeepingAppContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Consumption> Consumptions { get; set; } 
            = Enumerable.Empty<Consumption>();
        public IEnumerable<string> Categories { get; set; } 
            = Enumerable.Empty<string>();

        [FromQuery]
        public string SelectedCategory { get; set; } = String.Empty;

        public void OnGetAsync()
        {
            Consumptions = context.Consumptions.Include(c => c.Category);
            Categories = context.Categories.Select(l => l.CategoryName).ToList();
        }
        public string GetClass(string? category) =>
            SelectedCategory == category ? "bg-info text-white" : "";
    }
}
