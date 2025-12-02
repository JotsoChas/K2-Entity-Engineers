using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;

namespace CourseAdministrationSystem.Services
{
    public class ScheduleService
    {
        public int AddSchedule(K2DbContext db, int courseId, int classroomId)
        {
            var schedule = new Schedule
            {
                CourseId = courseId,
                ClassroomId = classroomId
            };

            db.Schedules.Add(schedule);
            db.SaveChanges();

            Console.WriteLine($"Schedule created with ID: {schedule.ScheduleId}");

            return schedule.ScheduleId;
        }
    }
}
