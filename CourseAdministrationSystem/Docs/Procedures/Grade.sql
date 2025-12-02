SELECT *
FROM Grades;

INSERT INTO Grades (StudentId, CourseId, Grade, GradesDate)
VALUES (STUDENT_ID, COURSE_ID, 'GRADE_HERE', 'YYYY-MM-DD');

UPDATE Grades
SET Grade      = 'NEW_GRADE_HERE',
    GradesDate = 'NEW_DATE_YYYY-MM-DD'
WHERE GradeId = ID_HERE;

DELETE FROM Grades
WHERE GradeId = ID_HERE;
