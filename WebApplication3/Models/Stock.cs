using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Stock
    {
        [Key]
        public int StockID {  get; set; } 

        [Required]
        [ForeignKey("Item")]
        public int ItemID { get; set; }

        [Display(Name = "Stock #")]
        [Range(1, 3)]
        public string? StockTag {  get; set; }

        public Item? Item { get; set; }
        public ICollection<ItemIssue>? ItemIssues { get; set; }
    }
}
