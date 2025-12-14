SELECT * 
FROM Student;

INSERT INTO Student (StudentFirstName, StudentLastName)
VALUES ('FIRSTNAME', 'LASTNAME');

UPDATE Student
SET StudentFirstName = 'NEW_FIRSTNAME',
    StudentLastName  = 'NEW_LASTNAME'
WHERE StudentId = ID_HERE;

DELETE FROM Student
WHERE StudentId = ID_HERE;

