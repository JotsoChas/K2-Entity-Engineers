using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class GradesService
    {
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
    }
}
