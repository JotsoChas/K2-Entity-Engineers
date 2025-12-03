using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class StudentService
    {
        // Add new student
        public int AddStudent(K2DbContext db, string firstName, string lastName)
        {
            var student = new Student
            {
                StudentFirstName = firstName,
                StudentLastName = lastName
            };

            db.Students.Add(student);
            db.SaveChanges();

            Console.WriteLine($"Student added with ID: {student.StudentId}");
            return student.StudentId;
        }

        // Edit student
        public void EditStudent(K2DbContext db, int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write($"New first name ({student.StudentFirstName}): ");
            var newFirst = Console.ReadLine();
            Console.Write($"New last name ({student.StudentLastName}): ");
            var newLast = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newFirst))
                student.StudentFirstName = newFirst;

            if (!string.IsNullOrWhiteSpace(newLast))
                student.StudentLastName = newLast;

            db.SaveChanges();
            Console.WriteLine("Student updated successfully.");
        }

        // Delete student
        public void DeleteStudent(K2DbContext db, int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            db.Students.Remove(student);
            db.SaveChanges();

            Console.WriteLine("Student deleted successfully.");
        }

        // List all students
        public void ListStudents(K2DbContext db)
        {
            var list = db.Students.ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var s in list)
            {
                Console.WriteLine($"{s.StudentId}: {s.StudentFirstName} {s.StudentLastName}");
            }
        }
    }
}
