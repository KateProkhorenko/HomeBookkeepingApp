using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HomeBookkeepingApp.Pages
{
    public class DetailsModel : EditorPageModel
    {
        public DetailsModel(HomeBookkeepingAppContext dbContext) : base(dbContext) { }
        public async Task OnGetAsync(long id)
        {
            Consumption? c = await Context.Consumptions
                .Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            ViewModel = ViewModelFactory.Details(c ?? new Consumption());
        }
    }
}
