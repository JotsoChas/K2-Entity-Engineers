using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(50)]
    public string? StudentFirstName { get; set; }

    [StringLength(50)]
    public string? StudentLastName { get; set; }
}
