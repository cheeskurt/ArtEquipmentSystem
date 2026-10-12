using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Stock
    {
        // The primary key - unique identifier
        [Key]
        public int StockID {  get; set; }

        // Foreign key field that is converted into a dropdown via LINQ - Pulls item name
        [Required]
        [ForeignKey("Item")]
        public int ItemID { get; set; }

        // Stock tag that teachers have marked supplies with in the art department (varies and doesn't follow standard conventions because of art teachers but remains around 7 characters
        [Display(Name = "Stock #")]
        [MaxLength(7)]
        public string StockTag {  get; set; }

        public Item? Item { get; set; }
        public ICollection<ItemIssue>? ItemIssues { get; set; }
    }
}
