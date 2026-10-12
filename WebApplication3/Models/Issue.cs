
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models.Attributes;

namespace WebApplication3.Models
{

    public class Issue
    {
        // The primary key - unique identifier
        [Key]
        public int IssueID { get; set; } 

        // Foreign key field that is converted into a dropdown via LINQ - Pulls student AC
        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        // Foreign key field that is converted into a dropdown via LINQ - Pulls student subject
        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        // Periods 1-5 only
        [Required]
        [Range(1, 5)]
        public int Period { get; set; }

        // Reasoning must be within 25 characters.
        [MaxLength(25)]
        public string? Reason { get; set; }

        // Custom data annotation that requires that the date must be set to present.
        [Required]
        [PastDate]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date Issued")]
        public DateTime DateIssued { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
        public ICollection<ItemIssue>? ItemIssues { get; set; }
    }
}
