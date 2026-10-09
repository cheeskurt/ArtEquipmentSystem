using WebApplication3.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {

        [Key]
        public int StudentID { get; set; } 

        // The field is marked as required, mandating that this field is filled. A maximum length of 30 is configured for the student's first name.
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Students first name is required."), StringLength(30, ErrorMessage = "First name cant be longer than 30 characters.")]
        public string FirstName { get; set; }

        // The field is marked as required, mandating that this field is filled. A maximum length of 30 is configured for the student's last name.
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Student's last name is required."), StringLength(30, ErrorMessage = "Last name cant be longer than 30 characters.")]
        public string LastName { get; set; }

        [Required]
        [Range(9, 13)]
        public int Year { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")] 
        public string Email { get; set; }

        public ICollection<Issue>? Issues { get; set; }
    }
}
