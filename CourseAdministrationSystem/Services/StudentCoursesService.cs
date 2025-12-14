using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class StudentCoursesService
    {
        // Register student to course
        public void RegisterStudentToCourse(K2DbContext db, int studentId, int courseId)
        {
            // check if student exists
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                ConsoleHelper.WriteWarning("Student not found");
                ConsoleHelper.WaitForContinue();
                return;
            }

            // check if course exists
            var course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
            {
                ConsoleHelper.WriteWarning("Course not found");
                ConsoleHelper.WaitForContinue();
                return;
            }

            // check duplicate
            var exists = db.StudentCourses
                .Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (exists)
            {
                ConsoleHelper.WriteWarning("Student already registered in this course");
                ConsoleHelper.WaitForContinue();
                return;
            }

            var sc = new StudentCourses
            {
                StudentId = studentId,
                CourseId = courseId
            };

            db.StudentCourses.Add(sc);
            db.SaveChanges();

            ConsoleHelper.WriteSuccess(
                $"{student.StudentFirstName} {student.StudentLastName} registered to {course.CourseName} (ID: {sc.StudentCourseId})");

            ConsoleHelper.WaitForContinue();
        }

        // Menu
        public void RegisterStudentToCourseMenu(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var st = ConsoleHelper.SafePrompt("Student ID");
            if (st == "<ESC>") return;

            var co = ConsoleHelper.SafePrompt("Course ID");
            if (co == "<ESC>") return;

            if (!int.TryParse(st, out int studentId) || !int.TryParse(co, out int courseId))
            {
                ConsoleHelper.WriteWarning("Invalid input");
                ConsoleHelper.WaitForContinue();
                return;
            }

            RegisterStudentToCourse(db, studentId, courseId);
            return;
        }
    }
}
