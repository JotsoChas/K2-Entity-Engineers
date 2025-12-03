DECLARE @Classroom1 INT, @Classroom2 INT, @Classroom3 INT;

INSERT INTO Classroom DEFAULT VALUES;
SET @Classroom1 = SCOPE_IDENTITY();

INSERT INTO Classroom DEFAULT VALUES;
SET @Classroom2 = SCOPE_IDENTITY();

INSERT INTO Classroom DEFAULT VALUES;
SET @Classroom3 = SCOPE_IDENTITY();

DECLARE @Teacher1 INT, @Teacher2 INT, @Teacher3 INT;

INSERT INTO Teacher (TeacherFirstName, TeacherLastName) VALUES ('Bill', 'Belichick');
SET @Teacher1 = SCOPE_IDENTITY();

INSERT INTO Teacher (TeacherFirstName, TeacherLastName) VALUES ('Andy', 'Reid');
SET @Teacher2 = SCOPE_IDENTITY();

INSERT INTO Teacher (TeacherFirstName, TeacherLastName) VALUES ('Mike', 'Tomlin');
SET @Teacher3 = SCOPE_IDENTITY();

DECLARE @Course1 INT, @Course2 INT, @Course3 INT;

INSERT INTO Courses (CourseName, CourseStart, CourseEnd, ClassroomId, TeacherId)
VALUES ('Offensive Strategy', '2025-01-01', '2025-03-01', @Classroom1, @Teacher1);
SET @Course1 = SCOPE_IDENTITY();

INSERT INTO Courses (CourseName, CourseStart, CourseEnd, ClassroomId, TeacherId)
VALUES ('Defensive Analysis', '2025-02-01', '2025-04-01', @Classroom2, @Teacher2);
SET @Course2 = SCOPE_IDENTITY();

INSERT INTO Courses (CourseName, CourseStart, CourseEnd, ClassroomId, TeacherId)
VALUES ('Leadership in Teams', '2025-03-01', '2025-05-01', @Classroom3, @Teacher3);
SET @Course3 = SCOPE_IDENTITY();

DECLARE @Student1 INT, @Student2 INT, @Student3 INT;

INSERT INTO Student (StudentFirstName, StudentLastName)
VALUES ('Tom', 'Brady');
SET @Student1 = SCOPE_IDENTITY();

INSERT INTO Student (StudentFirstName, StudentLastName)
VALUES ('Patrick', 'Mahomes');
SET @Student2 = SCOPE_IDENTITY();

INSERT INTO Student (StudentFirstName, StudentLastName)
VALUES ('Ray', 'Lewis');
SET @Student3 = SCOPE_IDENTITY();

DECLARE @SC1 INT, @SC2 INT, @SC3 INT, @SC4 INT, @SC5 INT;

INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@Student1, @Course1);
SET @SC1 = SCOPE_IDENTITY();

INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@Student1, @Course2);
SET @SC2 = SCOPE_IDENTITY();

INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@Student2, @Course1);
SET @SC3 = SCOPE_IDENTITY();

INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@Student2, @Course3);
SET @SC4 = SCOPE_IDENTITY();

INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@Student3, @Course2);
SET @SC5 = SCOPE_IDENTITY();

DECLARE @Schedule1 INT, @Schedule2 INT, @Schedule3 INT;

INSERT INTO Schedule (CourseId, ClassroomId) VALUES (@Course1, @Classroom1);
SET @Schedule1 = SCOPE_IDENTITY();

INSERT INTO Schedule (CourseId, ClassroomId) VALUES (@Course2, @Classroom2);
SET @Schedule2 = SCOPE_IDENTITY();

INSERT INTO Schedule (CourseId, ClassroomId) VALUES (@Course3, @Classroom3);
SET @Schedule3 = SCOPE_IDENTITY();

DECLARE @G1 INT, @G2 INT, @G3 INT, @G4 INT;

INSERT INTO Grades (Grade, GradesDate, StudentId, CourseId, TeacherId)
VALUES (5, '2025-02-10', @Student1, @Course1, @Teacher1);
SET @G1 = SCOPE_IDENTITY();

INSERT INTO Grades (Grade, GradesDate, StudentId, CourseId, TeacherId)
VALUES (4, '2025-02-18', @Student1, @Course2, @Teacher2);
SET @G2 = SCOPE_IDENTITY();

INSERT INTO Grades (Grade, GradesDate, StudentId, CourseId, TeacherId)
VALUES (5, '2025-02-11', @Student2, @Course1, @Teacher1);
SET @G3 = SCOPE_IDENTITY();

INSERT INTO Grades (Grade, GradesDate, StudentId, CourseId, TeacherId)
VALUES (5, '2025-02-20', @Student3, @Course2, @Teacher2);
SET @G4 = SCOPE_IDENTITY();

DECLARE @Course4 INT, @SC6 INT, @Schedule4 INT, @G5 INT;

INSERT INTO Courses (CourseName, CourseStart, CourseEnd, ClassroomId, TeacherId)
VALUES ('Advanced Strategy', '2025-06-01', '2025-12-31', @Classroom1, @Teacher1);
SET @Course4 = SCOPE_IDENTITY();

INSERT INTO StudentCourses (StudentId, CourseId)
VALUES (@Student1, @Course4);
SET @SC6 = SCOPE_IDENTITY();

INSERT INTO Schedule (CourseId, ClassroomId)
VALUES (@Course4, @Classroom1);
SET @Schedule4 = SCOPE_IDENTITY();

INSERT INTO Grades (Grade, GradesDate, StudentId, CourseId, TeacherId)
VALUES (5, '2025-06-15', @Student1, @Course4, @Teacher1);
SET @G5 = SCOPE_IDENTITY();



