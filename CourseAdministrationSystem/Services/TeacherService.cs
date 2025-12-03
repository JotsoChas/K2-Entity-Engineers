using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class TeacherService
    {
        // Add teacher
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

        // Edit teacher
        public void EditTeacher(K2DbContext db, int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.Write($"New first name ({teacher.TeacherFirstName}): ");
            var first = Console.ReadLine();

            Console.Write($"New last name ({teacher.TeacherLastName}): ");
            var last = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(first))
                teacher.TeacherFirstName = first;

            if (!string.IsNullOrWhiteSpace(last))
                teacher.TeacherLastName = last;

            db.SaveChanges();
            Console.WriteLine("Teacher updated successfully.");
        }

        // Delete teacher
        public void DeleteTeacher(K2DbContext db, int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            Console.WriteLine("Teacher deleted successfully.");
        }

        // List teachers
        public void ListTeachers(K2DbContext db)
        {
            var list = db.Teachers.ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("No teachers found.");
                return;
            }

            foreach (var t in list)
            {
                Console.WriteLine($"{t.TeacherId}: {t.TeacherFirstName} {t.TeacherLastName}");
            }
        }

        // Menu methods
        public void AddTeacherMenu(K2DbContext db)
        {
            Console.Write("First name: ");
            var first = Console.ReadLine();

            Console.Write("Last name: ");
            var last = Console.ReadLine();

            AddTeacher(db, first!, last!);
        }

        public void EditTeacherMenu(K2DbContext db)
        {
            Console.Write("Teacher ID: ");
            int id = int.Parse(Console.ReadLine()!);

            EditTeacher(db, id);
        }

        public void DeleteTeacherMenu(K2DbContext db)
        {
            Console.Write("Teacher ID: ");
            int id = int.Parse(Console.ReadLine()!);

            DeleteTeacher(db, id);
        }

        public void ListTeachersMenu(K2DbContext db)
        {
            ListTeachers(db);
        }
    }
}
