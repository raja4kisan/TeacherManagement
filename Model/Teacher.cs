using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherManagement.Model
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
