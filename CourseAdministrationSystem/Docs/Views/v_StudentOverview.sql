CREATE VIEW v_StudentOverview AS
SELECT 
    s.StudentId,
    s.StudentFirstName,
    s.StudentLastName,
    c.CourseId,
    c.CourseName,
    g.Grade,
    g.GradesDate,
    t.TeacherFirstName,
    t.TeacherLastName
FROM StudentCourses sc
JOIN Student s ON sc.StudentId = s.StudentId
JOIN Courses c ON sc.CourseId = c.CourseId
LEFT JOIN Grades g ON g.StudentId = s.StudentId AND g.CourseId = c.CourseId
LEFT JOIN Teacher t ON c.TeacherId = t.TeacherId;
