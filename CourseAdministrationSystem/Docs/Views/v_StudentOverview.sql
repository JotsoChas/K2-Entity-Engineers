CREATE VIEW v_StudentOverview AS
SELECT 
    s.StudentId,
    CONCAT(s.StudentFirstName, ' ', s.StudentLastName) AS StudentFullName,
    c.CourseId,
    c.CourseName,
    g.Grade,
    g.GradesDate,
    CONCAT(t.TeacherFirstName, ' ', t.TeacherLastName) AS TeacherFullName
FROM StudentCourses sc
JOIN Student s ON sc.StudentId = s.StudentId
JOIN Courses c ON sc.CourseId = c.CourseId
LEFT JOIN Grades g ON g.StudentId = s.StudentId AND g.CourseId = c.CourseId
LEFT JOIN Teacher t ON c.TeacherId = t.TeacherId;
