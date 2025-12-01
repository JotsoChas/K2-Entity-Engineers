using System;

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

    //Foreign key to Classroom
    public int ClassroomId { get; set; }
	[ForeignKey("FkClassroomId")]
	public Classroom Classroom { get; set; }

    //Foreign key to Teacher
	public int TeacherId { get; set; }
	[ForeignKey("FkTeacherId")]
	public Teacher Teacher { get; set; }

}
