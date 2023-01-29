using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeBookkeepingApp.Pages
{
    public class CreateModel : EditorPageModel
    {
        public CreateModel(HomeBookkeepingAppContext dbContext) : base(dbContext) { }
        public void OnGet()
        {
            ViewModel = ViewModelFactory.Create(new Consumption(), Categories);
        }
        public async Task<IActionResult> OnPostAsync([FromForm] Consumption consumption)
        {
            await CheckNewCategory(consumption);
            if (ModelState.IsValid)
            {
                consumption.Id = default;
                consumption.Category = default;
                Context.Consumptions.Add(consumption);
                await Context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
            ViewModel = ViewModelFactory.Create(consumption, Categories);
            return Page();
        }
    }
}
