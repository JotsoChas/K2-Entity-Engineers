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

                ConsoleHelper.WriteSuccess($"Grade created with ID: {newGrade.GradeId}");
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
                    ConsoleHelper.WriteWarning("No grade data found.");
                    return;
                }

                foreach (var row in list)
                {
                    ConsoleHelper.WriteInfo($"{row.CourseName} - {row.Grade} - {row.TeacherFirstName} {row.TeacherLastName} ({row.GradesDate})");
                }
                ConsoleHelper.WaitForContinue();

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
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
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
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
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
            }
            catch
            {
                ConsoleHelper.WriteError("Failed to create report");
            }


        }

        // Shared report renderer
        private void ShowReport<T>(List<T> result)
        {
            try
            {
                if (result.Count == 0)
                {
                    ConsoleHelper.WriteWarning("No data found.");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                foreach (var r in result)
                {
                    var approved = (bool)(r.GetType().GetProperty("Approved")?.GetValue(r) ?? false);
                    var count = (int)(r.GetType().GetProperty("Count")?.GetValue(r) ?? 0);

                    var status = approved ? "Approved" : "Not approved";
                    ConsoleHelper.WriteInfo($"{status}: {count}");
                }

                ConsoleHelper.WaitForContinue();

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
                var studentInput = ConsoleHelper.SafePrompt("Student ID");
                if (!int.TryParse(studentInput, out int studentId))
                {
                    ConsoleHelper.WriteWarning("Invalid student ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var courseInput = ConsoleHelper.SafePrompt("Course ID");
                if (!int.TryParse(courseInput, out int courseId))
                {
                    ConsoleHelper.WriteWarning("Invalid course ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var teacherInput = ConsoleHelper.SafePrompt("Teacher ID");
                if (!int.TryParse(teacherInput, out int teacherId))
                {
                    ConsoleHelper.WriteWarning("Invalid teacher ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var gradeInput = ConsoleHelper.SafePrompt("Grade (1-5)");
                if (!int.TryParse(gradeInput, out int grade) || grade < 1 || grade > 5)
                {
                    ConsoleHelper.WriteWarning("Grade must be between 1 and 5");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                AddGrade(db, studentId, courseId, teacherId, grade);
                ConsoleHelper.WaitForContinue();


            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong. Returning to menu");
            }

        }

        // Menu: grade overview
        public void ShowGradeOverviewMenu(K2DbContext db)
        {
            try
            {
                var input = ConsoleHelper.SafePrompt("Student ID");
                if (!int.TryParse(input, out int id))
                {
                    ConsoleHelper.WriteWarning("Invalid student ID");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                ShowGradeOverview(db, id);
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
            }
           
        }

        // Menu: report yearly
        public void ReportYearMenu(K2DbContext db)
        {
            try
            {
                var yearInput = ConsoleHelper.SafePrompt("Year");
                if (!int.TryParse(yearInput, out int year))
                {
                    ConsoleHelper.WriteWarning("Invalid year");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                ReportYear(db, year);
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
            }

        }

        // Menu: report half year
        public void ReportHalfYearMenu(K2DbContext db)
        {
            try
            {
                var yearInput = ConsoleHelper.SafePrompt("Year");
                if (!int.TryParse(yearInput, out int year))
                {
                    ConsoleHelper.WriteWarning("Invalid year");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var halfInput = ConsoleHelper.SafePrompt("Half (1 or 2)");
                if (!int.TryParse(halfInput, out int half) || (half != 1 && half != 2))
                {
                    ConsoleHelper.WriteWarning("Half must be 1 or 2");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                ReportHalfYear(db, year, half);
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
            }
 
        }

        // Menu: report quarter
        public void ReportQuarterMenu(K2DbContext db)
        {
            try
            {
                var yearInput = ConsoleHelper.SafePrompt("Year");
                if (!int.TryParse(yearInput, out int year))
                {
                    ConsoleHelper.WriteWarning("Invalid year");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                var quarterInput = ConsoleHelper.SafePrompt("Quarter (1-4)");
                if (!int.TryParse(quarterInput, out int quarter) || quarter < 1 || quarter > 4)
                {
                    ConsoleHelper.WriteWarning("Quarter must be between 1 and 4");
                    ConsoleHelper.WaitForContinue();
                    return;
                }

                ReportQuarter(db, year, quarter);
            }
            catch
            {
                ConsoleHelper.WriteError("Something went wrong...");
            }

        }
    }
}
