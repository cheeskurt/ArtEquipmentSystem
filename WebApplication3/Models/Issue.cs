
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models.Attributes;

namespace WebApplication3.Models
{

    public class Issue
    {
        [Key]
        public int IssueID { get; set; } 

        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        [Required]
        [Range(1, 5)]
        public int Period { get; set; }

        [MaxLength(25)]
        public string? Reason { get; set; }

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
