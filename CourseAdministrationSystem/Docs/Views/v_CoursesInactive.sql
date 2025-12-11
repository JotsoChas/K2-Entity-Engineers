CREATE OR ALTER VIEW v_CoursesInactive AS
SELECT
c.CourseId,
c.CourseName,
c.CourseStart,
c.CourseEnd
FROM Courses c
WHERE 
GETDATE() < c.CourseStart  
OR GETDATE() > c.CourseEnd;
