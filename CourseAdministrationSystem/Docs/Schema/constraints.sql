ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Teacher
FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId);
