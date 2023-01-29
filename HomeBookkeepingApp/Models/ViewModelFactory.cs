namespace HomeBookkeepingApp.Models
{
    public class ViewModelFactory
    {
        public static HomeBookkeepingViewModel Details(Consumption c)
        {
            return new HomeBookkeepingViewModel
            {
                Consumption = c,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Categories = c == null || c.Category == null
                    ? Enumerable.Empty<Category>()
                    : new List<Category> { c.Category },
            };
        }

        public static HomeBookkeepingViewModel Create(Consumption consumption,
            IEnumerable<Category> categories)
        {
            return new HomeBookkeepingViewModel
            {
                Consumption = consumption,
                Categories = categories,
              
            };
        }

        public static HomeBookkeepingViewModel Edit(Consumption consumption,
                IEnumerable<Category> categories)
        {
            return new HomeBookkeepingViewModel
            {
                Consumption = consumption,
                Categories = categories,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static HomeBookkeepingViewModel Delete(Consumption c,
                IEnumerable<Category> categories)
        {
            return new HomeBookkeepingViewModel
            {
                Consumption = c,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger",
                Categories = categories
            };
        }
    }
}
