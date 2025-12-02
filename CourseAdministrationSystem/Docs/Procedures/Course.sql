SELECT * 
FROM Courses;

INSERT INTO Courses (CourseName, CourseStart, CourseEnd, TeacherId, ClassroomId)
VALUES ('COURSE_NAME', '2025-01-01', '2025-06-01', TEACHER_ID, CLASSROOM_ID);

UPDATE Courses
SET CourseName  = 'NEW_COURSE_NAME',
    CourseStart = 'NEW_STARTDATE',
    CourseEnd   = 'NEW_ENDDATE',
    TeacherId   = NEW_TEACHER_ID,
    ClassroomId = NEW_CLASSROOM_ID
WHERE CourseId = ID_HERE;

DELETE FROM Courses
WHERE CourseId = ID_HERE;
