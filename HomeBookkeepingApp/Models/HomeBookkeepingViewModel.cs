namespace HomeBookkeepingApp.Models
{
    public class HomeBookkeepingViewModel
    {
        public Consumption Consumption { get; set; } = new Consumption();
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public IEnumerable<Category> Categories { get; set; }
            = Enumerable.Empty<Category>();
    }
}
