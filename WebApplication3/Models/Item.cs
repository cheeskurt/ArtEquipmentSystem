using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    // An enum declaring the categories of an item.
    public enum Category
    { 
        Storage, Tablets, Paints, Cameras
    }
    public class Item 
    {
        // The primary key - unique identifier
        [Key]
        public int ItemID { get; set; }

        // The item name is required, and must bee a minimum of 10 characters or a maximum of 30 characters.
        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        // This is a dropdown that represents different categories an item falls under.
        public Category Category { get; set; }

        public ICollection<Stock>? Stocks { get; set; }
    }
}
