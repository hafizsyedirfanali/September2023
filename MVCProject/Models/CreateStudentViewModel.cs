using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class CreateStudentViewModel
    {
       // [Required]//Data Annotations
        public required int Id { get; set; }
        [MaxLength(20)]
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
