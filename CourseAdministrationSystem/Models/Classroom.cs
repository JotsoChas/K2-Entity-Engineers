using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseAdministrationSystem.Models;

[Table("Classroom")]
public class Classroom
{
    [Key]
    public int ClassroomId { get; set; }

    // Navigation properties
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
