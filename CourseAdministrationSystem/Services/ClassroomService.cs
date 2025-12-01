using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class ClassroomService
    {
        // Add a new classroom and return its id
        public int AddClassroom(K2DbContext db)
        {
            var classroom = new Classroom();

            db.Classrooms.Add(classroom);
            db.SaveChanges();

            Console.WriteLine($"Classroom created with ID: {classroom.ClassroomId}");

            return classroom.ClassroomId;
        }
    }
}
