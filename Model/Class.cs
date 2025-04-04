using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherManagement.Model
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }
    }
}
