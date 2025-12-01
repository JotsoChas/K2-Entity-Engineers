using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Models;

[Table("Classroom")]
public partial class Classroom
{
    [Key]
    public int ClassroomId { get; set; }
}
