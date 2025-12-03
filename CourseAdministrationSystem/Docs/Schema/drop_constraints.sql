-- Drop FK: StudentCourses -> Student
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_StudentCourses_Student')
ALTER TABLE dbo.StudentCourses
DROP CONSTRAINT FK_StudentCourses_Student;

-- Drop FK: StudentCourses -> Courses
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_StudentCourses_Courses')
ALTER TABLE dbo.StudentCourses
DROP CONSTRAINT FK_StudentCourses_Courses;

-- Drop FK: Grades -> Student
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Student')
ALTER TABLE dbo.Grades
DROP CONSTRAINT FK_Grades_Student;

-- Drop FK: Grades -> Courses
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Courses')
ALTER TABLE dbo.Grades
DROP CONSTRAINT FK_Grades_Courses;

-- Drop FK: Grades -> Teacher
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Teacher')
ALTER TABLE dbo.Grades
DROP CONSTRAINT FK_Grades_Teacher;

-- Drop FK: Courses -> Teacher
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Courses_Teacher')
ALTER TABLE dbo.Courses
DROP CONSTRAINT FK_Courses_Teacher;

-- Drop FK: Schedule -> Courses
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Schedule_Courses')
ALTER TABLE dbo.Schedule
DROP CONSTRAINT FK_Schedule_Courses;

-- Drop FK: Schedule -> Classroom
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Schedule_Classroom')
ALTER TABLE dbo.Schedule
DROP CONSTRAINT FK_Schedule_Classroom;

-- Drop check: grades valid range
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Grades_ValidRange')
ALTER TABLE dbo.Grades
DROP CONSTRAINT CHK_Grades_ValidRange;

-- Drop check: course valid dates
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Courses_ValidDates')
ALTER TABLE dbo.Courses
DROP CONSTRAINT CHK_Courses_ValidDates;
