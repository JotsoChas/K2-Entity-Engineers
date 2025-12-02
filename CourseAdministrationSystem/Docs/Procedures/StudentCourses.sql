SELECT *
FROM StudentCourses;

INSERT INTO StudentCourses (StudentId, CourseId)
VALUES (STUDENT_ID, COURSE_ID);

UPDATE StudentCourses
SET StudentId = NEW_STUDENT_ID,
    CourseId  = NEW_COURSE_ID
WHERE StudentCourseId = ID_HERE;

DELETE FROM StudentCourses
WHERE StudentCourseId = ID_HERE;
