CREATE OR ALTER VIEW v_CoursesActive AS
SELECT
    c.CourseId,
    c.CourseName,
    c.CourseStart,
    c.CourseEnd
FROM Courses c
WHERE 
    GETDATE() >= c.CourseStart
    AND GETDATE() <= c.CourseEnd;
