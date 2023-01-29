using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBookkeepingApp.Models
{
    public class Consumption
    {
        /// <summary>
        /// Id of Consumption
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Date of Consumption
        /// </summary>

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateConsumption { get; set; } = DateTime.Now;
        /// <summary>
        /// Id of Category
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// Navigation property of Category
        /// </summary>
        public Category? Category { get; set; }
        /// <summary>
        /// Sum of Consumption
        /// </summary>

        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Please enter a Sum")]
        [Range(1, 999999, ErrorMessage = "Please enter a positive Sum")]
        public decimal Sum { get; set; }
        /// <summary>
        /// Comment of Consumption
        /// </summary>
        public string Comment { get; set; } = string.Empty;
    }
}
