using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class TeacherService
    {
        // Add teacher
        public int AddTeacher(K2DbContext db, string firstName, string lastName)
        {
            try
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
            catch
            {
                ConsoleHelper.WriteError("Failed to add teacher");
                return 0;
            }

        }

        // Edit teacher
        public void EditTeacher(K2DbContext db, int teacherId)
        {
            try
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
            catch
            {
                ConsoleHelper.WriteError("Something went wrong editing teacher");
                
            }
   
        }

        // Delete teacher
        public void DeleteTeacher(K2DbContext db, int teacherId)
        {
            try
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
            catch
            {
                ConsoleHelper.WriteError("Could not delete teacher for some reason");
            }
         
        }

        // List teachers
        public void ListTeachers(K2DbContext db)
        {
            try
            {
                var list = db.Teachers.ToList();

                if (list.Count == 0)
                {
                    ConsoleHelper.WriteError("No teachers found.");
                    return;
                }

                foreach (var t in list)
                {
                    Console.WriteLine($"{t.TeacherId}: {t.TeacherFirstName} {t.TeacherLastName}");                 
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError(ex.Message);                
            }
 
        }

        // Menu methods
        public void AddTeacherMenu(K2DbContext db)
        {
            try
            {
                Console.Write("First name: ");
                var first = Console.ReadLine();

                Console.Write("Last name: ");
                var last = Console.ReadLine();

                AddTeacher(db, first!, last!);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Could not add teacher - returning to menu");
                ConsoleHelper.WaitForContinue();
            }
           
        }

        public void EditTeacherMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Teacher ID: ");
                int id = int.Parse(Console.ReadLine()!);

                EditTeacher(db, id);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Could not edit teacher - returning to menu");
                ConsoleHelper.WaitForContinue();
            }
    
        }

        public void DeleteTeacherMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Teacher ID: ");
                int id = int.Parse(Console.ReadLine()!);

                DeleteTeacher(db, id);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong trying to delete teacher - returning to menu");
                ConsoleHelper.WaitForContinue();
            }

        }

        public void ListTeachersMenu(K2DbContext db)
        {
            try
            {
                ListTeachers(db);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Could not find teachers");
                ConsoleHelper.WaitForContinue();
            }
            
        }
    }
}
