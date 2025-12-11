using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using System.Linq.Expressions;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class CourseService
    {
        // Add course
        public int AddCourse(
            K2DbContext db,
            string courseName,
            DateTime startDate,
            DateTime endDate,
            int teacherId,
            int classroomId)
        {
            try
            {
                var course = new Course
                {
                    CourseName = courseName,
                    CourseStart = startDate,
                    CourseEnd = endDate,
                    TeacherId = teacherId,
                    ClassroomId = classroomId
                };

                db.Courses.Add(course);
                db.SaveChanges();

                Console.WriteLine($"Course added with ID: {course.CourseId}");
                return course.CourseId;
            }
            catch
            {
                ConsoleHelper.WriteError("Failed in creating new course... Returning to menu");
                return 0;
            }
        }

        // Edit course
        public void EditCourse(K2DbContext db, int courseId)
        {
            try
            {
                var course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                Console.Write($"New course name ({course.CourseName}): ");
                var name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                    course.CourseName = name;

                db.SaveChanges();
                Console.WriteLine("Course updated successfully.");
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong when editing course. Returning to menu");
            }
           
        }

        // Delete course
        public void DeleteCourse(K2DbContext db, int courseId)
        {
            try
            {
                var course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                db.Courses.Remove(course);
                db.SaveChanges();

                Console.WriteLine("Course deleted successfully.");
            }
            catch
            {
                ConsoleHelper.WriteError("Could not delete course! Returning to menu");
            }
           
        }

        // List courses
        public void ListCourses(K2DbContext db)
        {
            try
            {
                var courses = db.Courses.ToList();

                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses found.");
                    return;
                }

                foreach (var c in courses)
                {
                    Console.WriteLine($"{c.CourseId}: {c.CourseName} ({c.CourseStart:d} - {c.CourseEnd:d})");
                }
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to load courses! Returning to menu");
            }
        

        }

        // Show active courses with students
        public void ShowActiveCourses(K2DbContext db)
        {
            try
            {
                var today = DateTime.Today;

                var activeCourses =
                    db.Courses
                    .Where(c => c.CourseStart <= today && c.CourseEnd >= today)
                    .ToList();

                if (activeCourses.Count == 0)
                {
                    Console.WriteLine("No active courses found.");                 
                    return;
                }

                foreach (var course in activeCourses)
                {
                    Console.WriteLine($"{course.CourseName}:");

                    var students =
                        from sc in db.StudentCourses
                        join s in db.Students on sc.StudentId equals s.StudentId
                        where sc.CourseId == course.CourseId
                        select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($" - {s.StudentFirstName} {s.StudentLastName}");
                    }

                    Console.WriteLine();
                    
                }

            }
            catch
            {
                ConsoleHelper.WriteError("Could not find active courses");
            }
            
        }

        // Menu methods
        public void AddCourseMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Course name: ");
                var name = Console.ReadLine();

                Console.Write("Start date (yyyy-mm-dd): ");
                var start = DateTime.Parse(Console.ReadLine()!);

                Console.Write("End date (yyyy-mm-dd): ");
                var end = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Teacher ID: ");
                int teacherId = int.Parse(Console.ReadLine()!);

                Console.Write("Classroom ID: ");
                int classroomId = int.Parse(Console.ReadLine()!);

                AddCourse(db, name!, start, end, teacherId, classroomId);
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong. Failed to add new course!");
            }
           
        }

        public void EditCourseMenu(K2DbContext db)
        {
            Console.Write("Course ID: ");
            int id = int.Parse(Console.ReadLine()!);

            EditCourse(db, id);
        }

        public void DeleteCourseMenu(K2DbContext db)
        {
            Console.Write("Course ID: ");
            int id = int.Parse(Console.ReadLine()!);

            DeleteCourse(db, id);
        }

        public void ListCoursesMenu(K2DbContext db)
        {
            try
            {
                ListCourses(db);
                ConsoleHelper.WaitForContinue();  // ★ denna fixar allt
            }
            catch
            {
                ConsoleHelper.WriteError("Could not list courses");
                ConsoleHelper.WaitForContinue();
            }
        }


        public void ShowActiveCoursesMenu(K2DbContext db)
        {
            try
            {
                ShowActiveCourses(db);
                Console.ReadKey();
            }
            catch
            {
                ConsoleHelper.WriteError("Could not find any active courses");
            }
            
        }
    }
}
