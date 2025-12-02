using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class StudentCoursesService
    {
        public void AddStudentCourse(K2DbContext db, int studentId, int courseId)
        {
            var sc = new StudentCourses
            {
                StudentId = studentId,
                CourseId = courseId
            };

            db.StudentCourses.Add(sc);
            db.SaveChanges();

            Console.WriteLine($"StudentCourse created with ID: {sc.StudentCourseId}");
        }
    }
}
