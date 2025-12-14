CREATE OR ALTER VIEW View_StudentCourseGradeTeacher AS

SELECT
s.StudentId,
s.StudentFirstName,
s.StudentLastName,
c.CourseId,
c.CourseName,
g.Grade,
g.GradesDate,
t.TeacherId,
t.TeacherFirstName,
t.TeacherLastName
FROM Student s
LEFT JOIN StudentCourses sc
ON sc.StudentId = s.StudentId
LEFT JOIN Courses c
ON sc.CourseId = c.CourseId
LEFT JOIN Grades g
ON g.StudentId = s.StudentId
AND g.CourseId = c.CourseId
LEFT JOIN Teacher t
ON t.TeacherId = c.TeacherId;
