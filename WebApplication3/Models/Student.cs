using WebApplication3.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {
        // The primary key - unique identifier
        [Key]
        public int StudentID { get; set; } 

        // The field is marked as required, mandating that this field is filled. A maximum length of 30 is configured for the student's first name.
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only, please.")]
        [Required(ErrorMessage = "Students first name is required."), StringLength(30, ErrorMessage = "First name cant be longer than 30 characters.")]
        public string FirstName { get; set; }

        // The field is marked as required, mandating that this field is filled. A maximum length of 30 is configured for the student's last name.
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only, please.")]
        [Required(ErrorMessage = "Student's last name is required."), StringLength(30, ErrorMessage = "Last name cant be longer than 30 characters.")]
        public string LastName { get; set; }

        // Avondale College only has years 9-13, and is required for student information
        [Required]
        [Range(9, 13)]
        public int Year { get; set; }

        // Emails are only typically up to 254 characters, and must meet a standard to be a valid input
        [Required]
        [EmailAddress]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [MaxLength(8)]
        public string Email { get; set; }

        public ICollection<Issue>? Issues { get; set; }
    }
}
