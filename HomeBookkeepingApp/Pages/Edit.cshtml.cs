using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeBookkeepingApp.Pages
{
    public class EditModel : EditorPageModel
    {
        public EditModel(HomeBookkeepingAppContext dbContext) : base(dbContext) { }
        public async Task OnGetAsync(long id)
        {
            Consumption p = await this.Context.Consumptions.FindAsync(id)
            ?? new Consumption();
            ViewModel = ViewModelFactory.Edit(p, Categories);
        }
        public async Task<IActionResult> OnPostAsync([FromForm] Consumption consumption)
        {
            await CheckNewCategory(consumption);
            if (ModelState.IsValid)
            {
                consumption.Category = default;
                Context.Consumptions.Update(consumption);
                await Context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
            ViewModel = ViewModelFactory.Edit(consumption, Categories);
            return Page();
        }
    }
}
