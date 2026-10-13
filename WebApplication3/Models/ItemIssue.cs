using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models.Attributes;

namespace WebApplication3.Models
{
    public class ItemIssue
    {
        // The primary key - unique identifier
        [Key]
        public int ItemIssueID { get; set; }

        // Foreign key field that is converted into a dropdown via LINQ - Pulls an issue number ticket
        [Required]
        [ForeignKey("Issue Ticket")]
        public int IssueID { get; set; }

        // Foreign key field that is converted into a dropdown via LINQ - Pulls a stock tag
        [Required]
        [ForeignKey("Stock")]
        public int StockID { get; set; }

        // Max length of notes upon return must be 50 characters
        [MaxLength(50)]
        public string? Note { get; set; }

        // Custom data annotation that requires that the date must be set to present.
        [PastDate]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        public Issue? Issue { get; set; }
        public Stock? Stock { get; set; }
    }
}
