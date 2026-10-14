using System.ComponentModel.DataAnnotations;
using WebApplication3.Areas.Identity.Data;

namespace WebApplication3.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        // Name of each individual subject - not modifiable by user
        public string SubjectName { get; set; }

        public ICollection<Issue>? Issues { get; set; }
    }
}
