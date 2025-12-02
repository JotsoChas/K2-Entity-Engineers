SELECT 
    s.StudentId,
    s.StudentFirstName,
    s.StudentLastName,

    sc.StudentCourseId,

    c.CourseId,
    c.CourseName,
    c.CourseStart,
    c.CourseEnd,

    t.TeacherId,
    t.TeacherFirstName,
    t.TeacherLastName,

    cl.ClassroomId,

    g.Grade,
    g.GradesDate
FROM Student s
LEFT JOIN StudentCourses sc ON sc.StudentId = s.StudentId
LEFT JOIN Courses c ON c.CourseId = sc.CourseId
LEFT JOIN Teacher t ON t.TeacherId = c.TeacherId
LEFT JOIN Classroom cl ON cl.ClassroomId = c.ClassroomId
LEFT JOIN Grades g ON g.StudentId = s.StudentId AND g.CourseId = c.CourseId
ORDER BY s.StudentId, c.CourseId;
