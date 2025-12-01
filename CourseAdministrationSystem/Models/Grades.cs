using System;

public class Grades
{
    [Key]
    public int GradeId { get; set; }

    [Required]
    public int Grade { get; set; }

    [Required]
    public DateTime GradesDate { get; set; }

    //Foreign key to Student
    public int StudentId { get; set; }
    [ForeignKey("FkStudentId")]
    public Student Student { get; set; }

    //Foreign key to Course
    public int CourseId { get; set; }
    [ForeignKey("FkCourseId")]
    public Course Course { get; set; }

    //Foreign key to Teacher
    public int TeacherId { get; set; }
    [ForeignKey("FkTeacherId")]
    public Teacher Teacher { get; set; }


}
