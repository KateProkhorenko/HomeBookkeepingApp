using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeBookkeepingApp.Models;
using HomeBookkeepingApp.Data;

namespace HomeBookkeepingApp.Pages
{
    public class EditorPageModel : PageModel
    {
        public EditorPageModel(HomeBookkeepingAppContext dbContext)
        {
            Context = dbContext;
        }
        public HomeBookkeepingAppContext Context { get; set; }
        public IEnumerable<Category> Categories => Context.Categories;
        public HomeBookkeepingViewModel? ViewModel { get; set; }

        protected async Task CheckNewCategory(Consumption consumption)
        {
            if (consumption.CategoryId == -1
                    && !string.IsNullOrEmpty(consumption.Category?.CategoryName))
            {
                Context.Categories.Add(consumption.Category);
                await Context.SaveChangesAsync();
                consumption.CategoryId = consumption.Category.CategoryId;
                ModelState.Clear();
                TryValidateModel(consumption);
            }
        }
    }
}
