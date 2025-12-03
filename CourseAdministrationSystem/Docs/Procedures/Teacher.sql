SELECT * 
FROM Teacher;

INSERT INTO Teacher (TeacherFirstName, TeacherLastName)
VALUES ('FIRSTNAME', 'LASTNAME');

UPDATE Teacher
SET TeacherFirstName = 'NEW_FIRSTNAME',
    TeacherLastName  = 'NEW_LASTNAME'
WHERE TeacherId = ID_HERE;

DELETE FROM Teacher
WHERE TeacherId = ID_HERE;
