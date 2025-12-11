using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using Utils;

namespace CourseAdministrationSystem.Services
{
    public class ScheduleService
    {
        // Add schedule
        public int AddSchedule(K2DbContext db, int courseId, int classroomId)
        {
            try
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
            catch
            {
                ConsoleHelper.WriteError("Could not add Schedule - returning to menu");
                return 0;
            }
           
        }

        // Menu method
        public void AddScheduleMenu(K2DbContext db)
        {
            try
            {
                Console.Write("Course ID: ");
                int courseId = int.Parse(Console.ReadLine()!);

                if (!db.Courses.Any(c => c.CourseId == courseId))
                {
                    Console.WriteLine("Error: Course does not exist.");
                    return;
                }

                Console.Write("Classroom ID: ");
                int classroomId = int.Parse(Console.ReadLine()!);

                if (!db.Classrooms.Any(c => c.ClassroomId == classroomId))
                {
                    Console.WriteLine("Error: Classroom does not exist.");
                    return;
                }
                AddSchedule(db, courseId, classroomId);
            }
            catch
            {
                ConsoleHelper.WriteError("Oooops! Something went wrong here");
            }


           
        }

    }
}
