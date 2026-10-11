using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models.Attributes;

namespace WebApplication3.Models
{
    public class ItemIssue
    {
        [Key]
        public int ItemIssueID { get; set; }

        [Required]
        [ForeignKey("Issue")]
        public int IssueID { get; set; }

        [Required]
        [ForeignKey("Stock")]
        public int StockID { get; set; }

        [MaxLength(50)]
        public string? Note { get; set; }

        [PastDate]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        public Issue? Issue { get; set; }
        public Stock? Stock { get; set; }
    }
}
