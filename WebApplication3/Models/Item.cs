using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    // An enum declaring the category of an item.
    public enum Category
    { 
        Storage, Tablets, Paints, Cameras
    }
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [NotMapped]
        [Display(Name = "Attach File")]
        public IFormFile? Attachment { get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<Stock>? Stocks { get; set; }
    }
}
