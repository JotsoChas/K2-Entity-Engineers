using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class ClassroomService
    {
        // Add classroom
        public int AddClassroom(K2DbContext db)
        {
            try
            {
                var classroom = new Classroom();

                db.Classrooms.Add(classroom);
                db.SaveChanges();

                Console.WriteLine($"Classroom created with ID: {classroom.ClassroomId}");
                return classroom.ClassroomId;
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong creating a new Classroom");
                return 0;
            }

        }

        // List classrooms
        public void ListClassrooms(K2DbContext db)
        {
            try
            {
                var list = db.Classrooms.ToList();
           


            if (list.Count == 0)
            {
                Console.WriteLine("No classrooms found.");
                return;
            }

            foreach (var c in list)
            {
                Console.WriteLine($"Classroom ID: {c.ClassroomId}");
            }
            }
            catch
            {
                ConsoleHelper.WriteError("Could not fetch Classroom list");
            }
        }

        // Menu method (add)
        public void AddClassroomMenu(K2DbContext db)
        {
            Console.WriteLine("Creating new classroom...");
            try
            {
                AddClassroom(db);
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create new Classroom");
            }
         }
            

        // Menu method (list)
        public void ListClassroomsMenu(K2DbContext db)
        {
            ListClassrooms(db);
        }
    }
}
