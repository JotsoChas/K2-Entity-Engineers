using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;

namespace CourseAdministrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new K2DbContext();

            var classroomService = new ClassroomService();
            var teacherService = new TeacherService();
            var courseService = new CourseService();

            //Create classroom and teacher
            var classroomId = classroomService.AddClassroom(db);
            var teacherId = teacherService.AddTeacher(db, "Joco", "Borghol");

            courseService.AddCourse(
                db,
                "Math 2",
                new DateTime(2025, 1, 10),
                new DateTime(2025, 2, 22),
                teacherId,
                classroomId
            );

            Console.WriteLine("All test data added!");
        }
    }
}
