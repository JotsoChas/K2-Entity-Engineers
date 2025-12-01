using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class TeacherService
    {
        public int AddTeacher(K2DbContext db, string firstName, string lastName)
        {
            var teacher = new Teacher
            {
                TeacherFirstName = firstName,
                TeacherLastName = lastName
            };

            db.Teachers.Add(teacher);
            db.SaveChanges();

            Console.WriteLine($"Teacher added with ID: {teacher.TeacherId}");

            return teacher.TeacherId;
        }
    }
}
