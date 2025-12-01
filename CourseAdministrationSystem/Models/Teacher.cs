using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Models;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    public int TeacherId { get; set; }

    [Required]
    [StringLength(50)]
    public string TeacherFirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string TeacherLastName { get; set; }
}
