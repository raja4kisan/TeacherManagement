namespace TeacherManagement.Model
{
    public class TeacherDto
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Subject { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }
    }
}
