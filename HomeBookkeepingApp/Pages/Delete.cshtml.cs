using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeBookkeepingApp.Pages
{
    public class DeleteModel : EditorPageModel
    {
        public DeleteModel(HomeBookkeepingAppContext dbContext) : base(dbContext) { }
        public async Task OnGetAsync(long id)
        {
            ViewModel = ViewModelFactory.Delete(
            await Context.Consumptions.FindAsync(id) ?? new Consumption(), Categories);
        }
        public async Task<IActionResult> OnPostAsync([FromForm] Consumption consumption)
        {
            Context.Consumptions.Remove(consumption);
            await Context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
