using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherManagement.Model;

namespace TeacherManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherContext context;

        public TeacherController(TeacherContext context)
        {
            this.context = context;
        }

        [HttpGet("Show-Teacher's-Property")]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var result = context.Teachers.ToList();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return (StatusCode(500, ex.Message));
            }
        }

        [HttpPost("Add-Teacher")]
        public IActionResult AddTeacher(Teacher teacher)
        {
            try
            {
                var subjectExists = context.Teachers
            .Any(t => t.ClassId == teacher.ClassId && t.Subject == teacher.Subject);

                if (subjectExists)
                {
                    return Conflict("A teacher for this subject already exists in this class.");
                }
                teacher.Id = Guid.NewGuid();
                context.Teachers.Add(teacher);
                context.SaveChanges();
                var addedTeacher = context.Teachers
                    .Join(context.Classes,
                          t => t.ClassId,
                          c => c.ClassId,
                          (t, c) => new
                          {
                              t.Id,
                              t.Name,
                              t.Subject,
                              t.ClassId,
                              t.Age,
                              t.Salary,
                              t.Gender,
                              t.Address,
                              ClassName = c.ClassName
                          })
                    .FirstOrDefault(t => t.Id == teacher.Id);

                return CreatedAtAction(nameof(GetAllTeachers), new { classId = teacher.ClassId }, addedTeacher);
            }
            catch (Exception ex)
            {

                return (StatusCode(400, ex.Message));
            }


        }

        [HttpPut("Update-With-ClassId")]
        public IActionResult UpdateTeacher(int classId, Teacher updatedTeacher)
        {
            try
            {
                var existingTeachers = context.Teachers
                    .Where(t => t.ClassId == classId)
                    .ToList();

                if (!existingTeachers.Any())
                    return NotFound(new { message = "No teachers found for the given class." });

                foreach (var teacher in existingTeachers)
                {
                    teacher.Name = updatedTeacher.Name ?? teacher.Name;
                    teacher.Subject = updatedTeacher.Subject ?? teacher.Subject;
                    teacher.Age = updatedTeacher.Age > 0 ? updatedTeacher.Age : teacher.Age;
                    teacher.Salary = updatedTeacher.Salary > 0 ? updatedTeacher.Salary : teacher.Salary;
                    teacher.Gender = updatedTeacher.Gender ?? teacher.Gender;
                    teacher.Address = updatedTeacher.Address ?? teacher.Address;
                }

                context.SaveChangesAsync();
                return Ok(existingTeachers);
            }
            catch (Exception ex)
            {
                return (StatusCode(400, ex.Message));
            }
        }

        [HttpDelete("Delete-with-ClassId")]
        public IActionResult DeleteTeachersByClassId(int classId)
        {
            try
            {
                var teachersToDelete = context.Teachers
                    .Where(t => t.ClassId == classId)
                    .ToList();

                if (!teachersToDelete.Any())
                    return NotFound(new { message = "No teachers found for the given class." });

                context.Teachers.RemoveRange(teachersToDelete);
                context.SaveChanges();

                return Ok(new { message = "Teachers deleted successfully." });
            }
            catch (Exception ex)
            {
                return (StatusCode(400, ex.Message));
            }

        }


        [HttpGet("Get-Teacher-Detail-By-ClassId")]
        public IActionResult GetTeachersById(int classId)
        {
            try
            {
                var teachers = context.Teachers
                    .Where(t => t.ClassId == classId)
                    .Join(context.Classes,
                          teacher => teacher.ClassId,
                          classObj => classObj.ClassId,
                          (teacher, classObj) => new
                          {
                              teacher.Id,
                              teacher.Name,
                              teacher.Subject,
                              teacher.ClassId,
                              teacher.Age,
                              teacher.Salary,
                              teacher.Gender,
                              teacher.Address,
                              ClassName = classObj.ClassName
                          })
                    .ToList();

                if (!teachers.Any())
                    return NotFound(new { message = "No teachers found for the given class." });

                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return (StatusCode(500, ex.Message));
            }

        }


        [HttpGet("Get-Teacher-Detail-With-ClassName")]
        public IActionResult GetTeachers()
        {
            try
            {
                var teachers = context.Teachers
                    .Join(context.Classes,
                          teacher => teacher.ClassId,
                          classObj => classObj.ClassId,
                          (teacher, classObj) => new
                          {
                              teacher.Id,
                              teacher.Name,
                              teacher.Subject,
                              teacher.ClassId,
                              teacher.Age,
                              teacher.Salary,
                              teacher.Gender,
                              teacher.Address,
                              ClassName = classObj.ClassName
                          })
                    .ToList();

                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return (StatusCode(500, ex.Message));
            }
        }

    }
}
