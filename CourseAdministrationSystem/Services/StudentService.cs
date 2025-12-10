using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class StudentService
    {
        // Add student
        public int AddStudent(K2DbContext db, string firstName, string lastName)
        {
            try
            {
                // Duplicate check
                var exists = db.Students.Any(s =>
                    s.StudentFirstName.ToLower() == firstName.ToLower() &&
                    s.StudentLastName.ToLower() == lastName.ToLower());

                if (exists)
                {
                    if (!ConsoleHelper.Confirm("Student already exists. Add anyway?"))
                    {
                        ConsoleHelper.WriteWarning("Canceled");
                        return 0;
                    }
                }

                var student = new Student
                {
                    StudentFirstName = firstName,
                    StudentLastName = lastName
                };

                db.Students.Add(student);
                db.SaveChanges();

                ConsoleHelper.WriteSuccess($"Student added with ID: {student.StudentId}");
                return student.StudentId;
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to add student");
                return 0;
            }
        }

        // Edit student
        public void EditStudent(K2DbContext db, int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                ConsoleHelper.WriteWarning("Student not found");
                ConsoleHelper.WaitForContinue(); return;
            }

            var newFirst = ConsoleHelper.SafePrompt($"New first name ({student.StudentFirstName})");
            if (newFirst == "<ESC>") return;
            newFirst = ConsoleHelper.CleanName(newFirst);

            var newLast = ConsoleHelper.SafePrompt($"New last name ({student.StudentLastName})");
            if (newLast == "<ESC>") return;
            newLast = ConsoleHelper.CleanName(newLast);

            if (!string.IsNullOrWhiteSpace(newFirst)) student.StudentFirstName = newFirst;
            if (!string.IsNullOrWhiteSpace(newLast)) student.StudentLastName = newLast;

            db.SaveChanges();
            ConsoleHelper.WriteSuccess("Student updated");
            ConsoleHelper.WaitForContinue(); return;
        }

        // Delete student
        public void DeleteStudent(K2DbContext db, int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                ConsoleHelper.WriteWarning("Student not found");
                ConsoleHelper.WaitForContinue(); return;
            }

            db.Students.Remove(student);
            db.SaveChanges();

            ConsoleHelper.WriteSuccess("Student deleted");
            ConsoleHelper.WaitForContinue(); return;
        }

        // List students
        public void ListStudents(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var list = db.Students.ToList();
            if (list.Count == 0)
            {
                ConsoleHelper.WriteWarning("No students found");
                ConsoleHelper.WaitForContinue(); return;
            }

            foreach (var s in list)
                Console.WriteLine($"{s.StudentId}: {s.StudentFirstName} {s.StudentLastName}");

            ConsoleHelper.WaitForContinue(); return;
        }

        // Student overview (SQL-style)
        public void ShowStudentOverview(K2DbContext db, int studentId)
        {
            ConsoleHelper.Clear();

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
                ConsoleHelper.WriteWarning("No data found");
                ConsoleHelper.WaitForContinue(); return;
            }

            foreach (var row in list)
                Console.WriteLine($"{row.StudentFirstName} {row.StudentLastName} - {row.CourseName} - Grade: {row.Grade} - {row.TeacherFirstName} {row.TeacherLastName} ({row.GradesDate})");

            ConsoleHelper.WaitForContinue(); return;
        }

        // Menus
        public void AddStudentMenu(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var first = ConsoleHelper.SafePrompt("First name");
            if (first == "<ESC>") return;
            first = ConsoleHelper.CleanName(first);

            var last = ConsoleHelper.SafePrompt("Last name");
            if (last == "<ESC>") return;
            last = ConsoleHelper.CleanName(last);

            if (first == "" || last == "")
            {
                ConsoleHelper.WriteWarning("Invalid input");
                ConsoleHelper.WaitForContinue(); return;
            }

            AddStudent(db, first, last);
            ConsoleHelper.WaitForContinue(); return;
        }

        public void EditStudentMenu(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var input = ConsoleHelper.SafePrompt("Student ID");
            if (input == "<ESC>") return;

            if (!int.TryParse(input, out int id))
            {
                ConsoleHelper.WriteWarning("Invalid ID");
                ConsoleHelper.WaitForContinue(); return;
            }

            EditStudent(db, id);
        }

        public void DeleteStudentMenu(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var input = ConsoleHelper.SafePrompt("Student ID");
            if (input == "<ESC>") return;

            if (!int.TryParse(input, out int id))
            {
                ConsoleHelper.WriteWarning("Invalid ID");
                ConsoleHelper.WaitForContinue(); return;
            }

            DeleteStudent(db, id);
        }

        public void ListStudentsMenu(K2DbContext db)
        {
            ListStudents(db); return;
        }

        public void ShowStudentOverviewMenu(K2DbContext db)
        {
            ConsoleHelper.Clear();

            var input = ConsoleHelper.SafePrompt("Student ID");
            if (input == "<ESC>") return;

            if (!int.TryParse(input, out int id))
            {
                ConsoleHelper.WriteWarning("Invalid ID");
                ConsoleHelper.WaitForContinue(); return;
            }

            ShowStudentOverview(db, id); return;
        }
    }
}
