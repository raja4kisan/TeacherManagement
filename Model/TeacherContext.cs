using Microsoft.EntityFrameworkCore;

namespace TeacherManagement.Model
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options)
        {
            
        }
        public DbSet<Class>Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherDto> TeacherDtos { get; set; }
    }
}
