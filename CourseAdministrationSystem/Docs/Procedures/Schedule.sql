SELECT * FROM Schedule;

INSERT INTO Schedule (CourseId, TeacherId, ClassroomId, ScheduleDate)
VALUES (COURSE_ID, TEACHER_ID, CLASSROOM_ID, 'YYYY-MM-DD');

UPDATE Schedule
SET CourseId     = NEW_COURSE_ID,
    TeacherId    = NEW_TEACHER_ID,
    ClassroomId  = NEW_CLASSROOM_ID,
    ScheduleDate = 'NEW_DATE_YYYY-MM-DD'
WHERE ScheduleId = ID_HERE;

DELETE FROM Schedule
WHERE ScheduleId = ID_HERE;
