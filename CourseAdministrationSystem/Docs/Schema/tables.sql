CREATE TABLE Classroom (
    ClassroomId INT IDENTITY(1,1) PRIMARY KEY
);

CREATE TABLE Teacher (
    TeacherId INT IDENTITY(1,1) PRIMARY KEY,
    TeacherFirstName NVARCHAR(50),
    TeacherLastName NVARCHAR(50)
);

CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100),
    CourseStart DATETIME2 NOT NULL,
    CourseEnd DATETIME2 NOT NULL,
    ClassroomId INT NOT NULL,
    TeacherId INT NOT NULL
);

CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentFirstName NVARCHAR(50),
    StudentLastName NVARCHAR(50)
);

CREATE TABLE StudentCourses (
    StudentCourseId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL
);

CREATE TABLE Schedule (
    ScheduleId INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    ClassroomId INT NOT NULL
);

CREATE TABLE Grades (
    GradeId INT IDENTITY(1,1) PRIMARY KEY,
    Grade INT NOT NULL,
    GradesDate DATETIME2 NOT NULL,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    TeacherId INT NOT NULL
);
