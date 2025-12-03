using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class GradesService
    {
        // Add grade
        public void AddGrade(K2DbContext db, int studentId, int courseId, int teacherId, int grade)
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

        // Show student grade overview
        public void ShowGradeOverview(K2DbContext db, int studentId)
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

        // Report per year
        public void ReportYear(K2DbContext db, int year)
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
        }

        // Report per half year
        public void ReportHalfYear(K2DbContext db, int year, int half)
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
        }

        // Report per quarter
        public void ReportQuarter(K2DbContext db, int year, int quarter)
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
        }

        // Shared report renderer
        private void ShowReport<T>(List<T> result)
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

        // Menu: Add grade
        public void AddGradeMenu(K2DbContext db)
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
        }

        // Menu: grade overview
        public void ShowGradeOverviewMenu(K2DbContext db)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine()!);

            ShowGradeOverview(db, id);
        }

        // Menu: report yearly
        public void ReportYearMenu(K2DbContext db)
        {
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine()!);

            ReportYear(db, year);
        }

        // Menu: report half year
        public void ReportHalfYearMenu(K2DbContext db)
        {
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine()!);

            Console.Write("Half (1 or 2): ");
            int half = int.Parse(Console.ReadLine()!);

            ReportHalfYear(db, year, half);
        }

        // Menu: report quarter
        public void ReportQuarterMenu(K2DbContext db)
        {
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine()!);

            Console.Write("Quarter (1-4): ");
            int quarter = int.Parse(Console.ReadLine()!);

            ReportQuarter(db, year, quarter);
        }
    }
}
