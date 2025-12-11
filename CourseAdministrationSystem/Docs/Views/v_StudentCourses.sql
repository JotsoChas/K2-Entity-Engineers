CREATE OR ALTER VIEW View_StudentCourses AS
SELECT 
s.StudentId,
s.StudentFirstName,
s.StudentLastName,
c.CourseName
FROM Student s
LEFT JOIN StudentCourses sc ON s.StudentId = sc.StudentId
LEFT JOIN Courses c ON sc.CourseId = c.CourseId;
