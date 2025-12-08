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

        // Student overview (LINQ, no DB view needed)
        public void ShowStudentOverview(K2DbContext db, int studentId)
        {
            var result =
                from sc in db.StudentCourses
                join c in db.Courses on sc.CourseId equals c.CourseId
                join g in db.Grades on new { sc.StudentId, sc.CourseId }
                    equals new { g.StudentId, g.CourseId } into gj
                from grade in gj.DefaultIfEmpty()
                join t in db.Teachers on c.TeacherId equals t.TeacherId
                join s in db.Students on sc.StudentId equals s.StudentId
                where sc.StudentId == studentId
                select new
                {
                    s.StudentFirstName,
                    s.StudentLastName,
                    c.CourseName,
                    Grade = grade != null ? grade.Grade : 0,
                    GradesDate = grade != null ? (DateTime?)grade.GradesDate : null,
                    t.TeacherFirstName,
                    t.TeacherLastName
                };


            var list = result.ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            foreach (var row in list)
            {
                Console.WriteLine(
                    $"{row.StudentFirstName} {row.StudentLastName} - " +
                    $"{row.CourseName} - " +
                    $"Grade: {row.Grade} - " +
                    $"{row.TeacherFirstName} {row.TeacherLastName} " +
                    $"({row.GradesDate})"
                );
            }
        }

        // Menu methods
        public void AddStudentMenu(K2DbContext db)
        {
            Console.Write("First name: ");
            var first = Console.ReadLine();

            Console.Write("Last name: ");
            var last = Console.ReadLine();

            AddStudent(db, first!, last!);
        }

        public void EditStudentMenu(K2DbContext db)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine()!);

            EditStudent(db, id);
        }

        public void DeleteStudentMenu(K2DbContext db)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine()!);

            DeleteStudent(db, id);
        }

        public void ListStudentsMenu(K2DbContext db)
        {
            ListStudents(db);
        }

        public void ShowStudentOverviewMenu(K2DbContext db)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine()!);

            ShowStudentOverview(db, id);
        }
    }
}
