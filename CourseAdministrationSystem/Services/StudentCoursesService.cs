using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class StudentCoursesService
    {
        // Register student to course
        public void RegisterStudentToCourse(K2DbContext db, int studentId, int courseId)
        {
            var exists = db.StudentCourses
                .Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (exists)
            {
                Console.WriteLine("Student is already registered for this course.");
                return;
            }

            var sc = new StudentCourses
            {
                StudentId = studentId,
                CourseId = courseId
            };

            db.StudentCourses.Add(sc);
            db.SaveChanges();

            Console.WriteLine($"StudentCourse created with ID: {sc.StudentCourseId}");
        }

        // Menu method
        public void RegisterStudentToCourseMenu(K2DbContext db)
        {
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine()!);

            Console.Write("Course ID: ");
            int courseId = int.Parse(Console.ReadLine()!);

            RegisterStudentToCourse(db, studentId, courseId);
        }
    }
}
