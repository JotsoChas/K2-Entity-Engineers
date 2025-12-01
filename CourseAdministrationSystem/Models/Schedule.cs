using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Models;

[Table("Schedule")]
public partial class Schedule
{
    [Key]
    public int ScheduleId { get; set; }

    // Foreign key to Course
    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }

    // Foreign key to Classroom
    public int ClassroomId { get; set; }

    [ForeignKey("ClassroomId")]
    public Classroom Classroom { get; set; }
}
