using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HomeBookkeepingApp.Pages
{
    public class IndexModel : PageModel
    {
        private HomeBookkeepingAppContext context;
        public IndexModel(HomeBookkeepingAppContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Consumption> Consumptions { get; set; } 
                = Enumerable.Empty<Consumption>();
        public void OnGetAsync(long id = 1)
        {
            Consumptions = context.Consumptions.Include(c => c.Category);
        }

    }
}
