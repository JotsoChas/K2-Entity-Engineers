-- FK: StudentCourses -> Student
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_StudentCourses_Student')
ALTER TABLE dbo.StudentCourses
ADD CONSTRAINT FK_StudentCourses_Student
FOREIGN KEY (StudentId) REFERENCES dbo.Student(StudentId);

-- FK: StudentCourses -> Courses
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_StudentCourses_Courses')
ALTER TABLE dbo.StudentCourses
ADD CONSTRAINT FK_StudentCourses_Courses
FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId);

-- FK: Grades -> Student
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Student')
ALTER TABLE dbo.Grades
ADD CONSTRAINT FK_Grades_Student
FOREIGN KEY (StudentId) REFERENCES dbo.Student(StudentId);

-- FK: Grades -> Courses
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Courses')
ALTER TABLE dbo.Grades
ADD CONSTRAINT FK_Grades_Courses
FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId);

-- FK: Grades -> Teacher
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Grades_Teacher')
ALTER TABLE dbo.Grades
ADD CONSTRAINT FK_Grades_Teacher
FOREIGN KEY (TeacherId) REFERENCES dbo.Teacher(TeacherId);

-- FK: Courses -> Teacher
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Courses_Teacher')
ALTER TABLE dbo.Courses
ADD CONSTRAINT FK_Courses_Teacher
FOREIGN KEY (TeacherId) REFERENCES dbo.Teacher(TeacherId);

-- FK: Schedule -> Courses
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Schedule_Courses')
ALTER TABLE dbo.Schedule
ADD CONSTRAINT FK_Schedule_Courses
FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId);

-- FK: Schedule -> Classroom
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Schedule_Classroom')
ALTER TABLE dbo.Schedule
ADD CONSTRAINT FK_Schedule_Classroom
FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(ClassroomId);

-- Check: grade must be between 1 and 5
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Grades_ValidRange')
ALTER TABLE dbo.Grades
ADD CONSTRAINT CHK_Grades_ValidRange CHECK (Grade BETWEEN 1 AND 5);

-- Check: CourseStart must be earlier than CourseEnd
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Courses_ValidDates')
ALTER TABLE dbo.Courses
ADD CONSTRAINT CHK_Courses_ValidDates CHECK (CourseStart < CourseEnd);
