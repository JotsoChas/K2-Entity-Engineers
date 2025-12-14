using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Models;

[Table("StudentCourses")]
public partial class StudentCourses
{
    [Key]
    public int StudentCourseId { get; set; }

    // Foreign key to Student
    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; }

    // Foreign key to Course
    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }
}
