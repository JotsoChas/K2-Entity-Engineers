using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class CourseService
    {
        public void AddCourse(
            K2DbContext db,
            string name,
            DateTime start,
            DateTime end,
            int teacherId,
            int classroomId)
        {
            var course = new Course
            {
                CourseName = name,
                CourseStart = start,
                CourseEnd = end,
                TeacherId = teacherId,
                ClassroomId = classroomId
            };

            db.Courses.Add(course);
            db.SaveChanges();

            Console.WriteLine($"Course added with ID: {course.CourseId}");
        }
    }
}
