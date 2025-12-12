using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class GradesService
    {
        // Add grade
        public void AddGrade(K2DbContext db, int studentId, int courseId, int teacherId, int grade)
        {
            try
            {
                var newGrade = new Grades
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    TeacherId = teacherId,
                    Grade = grade,
                    GradesDate = DateTime.Now
                };

                db.Grades.Add(newGrade);
                db.SaveChanges();

                Console.WriteLine($"Grade created with ID: {newGrade.GradeId}");
            }
            catch
            {
                ConsoleHelper.WriteError("Could not add grade");
            }
            
        }

        // Show student grade overview
        public void ShowGradeOverview(K2DbContext db, int studentId)
        {
            try
            {
                var result =
                from sc in db.StudentCourses
                join c in db.Courses on sc.CourseId equals c.CourseId
                join g in db.Grades on
                    new { sc.StudentId, sc.CourseId }
                    equals new { g.StudentId, g.CourseId } into gj
                from grade in gj.DefaultIfEmpty()
                join t in db.Teachers on c.TeacherId equals t.TeacherId
                join s in db.Students on sc.StudentId equals s.StudentId
                where sc.StudentId == studentId
                select new
                {
                    c.CourseName,
                    Grade = grade != null ? (int?)grade.Grade : null,
                    GradesDate = grade != null ? (DateTime?)grade.GradesDate : null,
                    t.TeacherFirstName,
                    t.TeacherLastName
                };

                var list = result.ToList();

                if (list.Count == 0)
                {
                    Console.WriteLine("No grade data found.");
                    return;
                }

                foreach (var row in list)
                {
                    Console.WriteLine($"{row.CourseName} - {row.Grade} - {row.TeacherFirstName} {row.TeacherLastName} ({row.GradesDate})");
                }
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong. Returning to menu...");
            }
            
        }

        // Report per year
        public void ReportYear(K2DbContext db, int year)
        {
        try
            {
                var result = db.Grades
               .Where(g => g.GradesDate.Year == year)
               .GroupBy(g => g.Grade >= 3)
               .Select(g => new
               {
                   Approved = g.Key,
                   Count = g.Count()
               })
               .ToList();

                ShowReport(result);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
                ConsoleHelper.WaitForContinue();
            }
           
        }

        // Report per half year
        public void ReportHalfYear(K2DbContext db, int year, int half)
        {
            try
            {
                int startMonth = half == 1 ? 1 : 7;
                int endMonth = half == 1 ? 6 : 12;

                var result = db.Grades
                    .Where(g => g.GradesDate.Year == year &&
                                g.GradesDate.Month >= startMonth &&
                                g.GradesDate.Month <= endMonth)
                    .GroupBy(g => g.Grade >= 3)
                    .Select(g => new
                    {
                        Approved = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                ShowReport(result);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
                ConsoleHelper.WaitForContinue();
            }

        }

        // Report per quarter
        public void ReportQuarter(K2DbContext db, int year, int quarter)
        {
            try
            {
                int startMonth = (quarter - 1) * 3 + 1;
                int endMonth = startMonth + 2;

                var result = db.Grades
                    .Where(g => g.GradesDate.Year == year &&
                                g.GradesDate.Month >= startMonth &&
                                g.GradesDate.Month <= endMonth)
                    .GroupBy(g => g.Grade >= 3)
                    .Select(g => new
                    {
                        Approved = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                ShowReport(result);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
                ConsoleHelper.WaitForContinue();
            }


        }

        // Shared report renderer
        private void ShowReport<T>(List<T> result)
        {
            try
            {
                if (result.Count == 0)
                {
                    Console.WriteLine("No data found.");
                    return;
                }

                foreach (var r in result)
                {
                    var approved = (bool)(r.GetType().GetProperty("Approved")?.GetValue(r) ?? false);
                    var count = (int)(r.GetType().GetProperty("Count")?.GetValue(r) ?? 0);

                    var status = approved ? "Approved" : "Not approved";
                    Console.WriteLine($"{status}: {count}");
                }
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
            }
            
        }

        // Menu: Add grade
        public void AddGradeMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Student ID: ");
                int studentId = int.Parse(Console.ReadLine()!);

                Console.Write("Course ID: ");
                int courseId = int.Parse(Console.ReadLine()!);

                Console.Write("Teacher ID: ");
                int teacherId = int.Parse(Console.ReadLine()!);

                Console.Write("Grade (1-5): ");
                int grade = int.Parse(Console.ReadLine()!);

                AddGrade(db, studentId, courseId, teacherId, grade);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong. Returning to menu");
                ConsoleHelper.WaitForContinue();
            }

        }

        // Menu: grade overview
        public void ShowGradeOverviewMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Student ID: ");
                int id = int.Parse(Console.ReadLine()!);

                ShowGradeOverview(db, id);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
                ConsoleHelper.WaitForContinue();
            }
           
        }

        // Menu: report yearly
        public void ReportYearMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine()!);

                ReportYear(db, year);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
                ConsoleHelper.WaitForContinue();
            }

        }

        // Menu: report half year
        public void ReportHalfYearMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine()!);

                Console.Write("Half (1 or 2): ");
                int half = int.Parse(Console.ReadLine()!);

                ReportHalfYear(db, year, half);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
                ConsoleHelper.WaitForContinue();
            }
 
        }

        // Menu: report quarter
        public void ReportQuarterMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine()!);

                Console.Write("Quarter (1-4): ");
                int quarter = int.Parse(Console.ReadLine()!);

                ReportQuarter(db, year, quarter);
                ConsoleHelper.WaitForContinue();
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
                ConsoleHelper.WaitForContinue();
            }

        }
    }
}
