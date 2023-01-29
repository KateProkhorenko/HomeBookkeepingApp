namespace HomeBookkeepingApp.Models
{
    public class Category
    {
        /// <summary>
        /// Id of Category
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// Name of Category
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;
        /// <summary>
        /// Navigation property of Consumptions
        /// </summary>
        public IEnumerable<Consumption>? Consumptions { get; set; }
    }
}
