using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseAdministrationSystem.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [StringLength(100)]
    public string CourseName { get; set; }

    [Required]
    public DateTime CourseStart { get; set; }

    [Required]
    public DateTime CourseEnd { get; set; }

    // Foreign key to Classroom
    public int ClassroomId { get; set; }

    [ForeignKey("ClassroomId")]
    public Classroom Classroom { get; set; }

    // Foreign key to Teacher
    public int TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public Teacher Teacher { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
    public ICollection<Grades> Grades { get; set; }
    public ICollection<StudentCourses> StudentCourses { get; set; }

}
