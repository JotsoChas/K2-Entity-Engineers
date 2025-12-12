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

                ConsoleHelper.WriteSuccess($"Course added with ID: {course.CourseId}");
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
                    ConsoleHelper.WriteWarning("Course not found");
                    return;
                }

                var name = ConsoleHelper.SafePrompt($"New course name ({course.CourseName})");
                if (name == "<ESC>") return;


                if (!string.IsNullOrWhiteSpace(name))
                    course.CourseName = name;

                db.SaveChanges();
                ConsoleHelper.WriteSuccess("Course updated successfully.");
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
                    ConsoleHelper.WriteWarning("Course not found.");
                    return;
                }

                db.Courses.Remove(course);
                db.SaveChanges();

                ConsoleHelper.WriteSuccess("Course deleted successfully.");
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
                    ConsoleHelper.WriteWarning("No courses found.");
                    return;
                }

                foreach (var c in courses)
                {
                    ConsoleHelper.WriteInfo($"{c.CourseId}: {c.CourseName} ({c.CourseStart:d} - {c.CourseEnd:d})");
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
                    ConsoleHelper.WriteWarning("No active courses found");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                foreach (var course in activeCourses)
                {
                    ConsoleHelper.WriteInfo($"{course.CourseName}:");

                    var students =
                        from sc in db.StudentCourses
                        join s in db.Students on sc.StudentId equals s.StudentId
                        where sc.CourseId == course.CourseId
                        select s;

                    foreach (var s in students)
                    {
                        ConsoleHelper.WriteInfo($" - {s.StudentFirstName} {s.StudentLastName}");
                    }

                    Console.WriteLine();
                }
                ConsoleHelper.WaitForContinue();
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
                var name = ConsoleHelper.SafePrompt("Course name");
                if (name == "<ESC>") return;

                var startInput = ConsoleHelper.SafePrompt("Start date (yyyy-mm-dd)");
                if (startInput == "<ESC>") return;

                if (!DateTime.TryParse(startInput, out var start))
                {
                    ConsoleHelper.WriteWarning("Invalid start date");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var endInput = ConsoleHelper.SafePrompt("End date (yyyy-mm-dd)");
                if (endInput == "<ESC>") return;

                if (!DateTime.TryParse(endInput, out var end))
                {
                    ConsoleHelper.WriteWarning("Invalid end date");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                Console.Write("Teacher ID: ");
                var teacherInput = ConsoleHelper.SafePrompt("Teacher ID");
                if (teacherInput == "<ESC>") return;

                if (!int.TryParse(teacherInput, out int teacherId))
                {
                    ConsoleHelper.WriteWarning("Invalid teacher ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var classroomInput = ConsoleHelper.SafePrompt("Classroom ID");
                if (classroomInput == "<ESC>") return;

                if (!int.TryParse(classroomInput, out int classroomId))
                {
                    ConsoleHelper.WriteWarning("Invalid classroom ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }


                AddCourse(db, name!, start, end, teacherId, classroomId);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong. Failed to add new course!");
                ConsoleHelper.WaitForContinue();
            }
           
        }

        public void EditCourseMenu(K2DbContext db)
        {
            Console.Write("Course ID: ");
            int id = int.Parse(Console.ReadLine()!);

            EditCourse(db, id);
            ConsoleHelper.WaitForContinue();
        }

        public void DeleteCourseMenu(K2DbContext db)
        {
            Console.Write("Course ID: ");
            int id = int.Parse(Console.ReadLine()!);

            DeleteCourse(db, id);
            ConsoleHelper.WaitForContinue();
        }

        public void ListCoursesMenu(K2DbContext db)
        {
            try
            {
                ListCourses(db);
                ConsoleHelper.WaitForContinue();
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
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Could not find any active courses");
                ConsoleHelper.WaitForContinue();
            }
            
        }
    }
}
