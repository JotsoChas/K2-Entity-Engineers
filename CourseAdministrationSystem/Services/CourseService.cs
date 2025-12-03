using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class CourseService
    {
        public int AddCourse(
        K2DbContext db,
        string courseName,
        DateTime startDate,
        DateTime endDate,
        int teacherId,
         int classroomId)
        {
            var course = new Course
            {
                CourseName = courseName,
                CourseStart = startDate,
                CourseEnd = endDate,
                TeacherId = teacherId,
                ClassroomId = classroomId
            };

            db.Courses.Add(course);
            db.SaveChanges();

            Console.WriteLine($"Course added with ID: {course.CourseId}");

            return course.CourseId;
        }

    }
}
