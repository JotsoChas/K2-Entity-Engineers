using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;

public static class Menu
{
    public static void ShowMainMenu(K2DbContext db)
    {
        var studentService = new StudentService();
        var courseService = new CourseService();
        var teacherService = new TeacherService();
        var scheduleService = new ScheduleService();
        var gradesService = new GradesService();
        var studentCourseService = new StudentCoursesService();
        var classroomService = new ClassroomService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== ADMIN MENU ======");
            Console.WriteLine("1. Students");
            Console.WriteLine("2. Courses");
            Console.WriteLine("3. Teachers");
            Console.WriteLine("4. Schedule");
            Console.WriteLine("5. Grades");
            Console.WriteLine("6. Classrooms");
            Console.WriteLine("0. Exit");
            Console.Write("Select: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": StudentMenu(db, studentService, studentCourseService); break;
                case "2": CourseMenu(db, courseService); break;
                case "3": TeacherMenu(db, teacherService); break;
                case "4": ScheduleMenu(db, scheduleService); break;
                case "5": GradesMenu(db, gradesService); break;
                case "6": ClassroomMenu(db, classroomService); break;
                case "0": return;
            }
        }
    }

    // ----------------- STUDENTS -----------------

    static void StudentMenu(K2DbContext db, StudentService service, StudentCoursesService scService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== STUDENTS ======");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Edit Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. Register Student to Course");
            Console.WriteLine("6. Show Student Overview");
            Console.WriteLine("0. Back");
            Console.Write("Select: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddStudentMenu(db); break;
                case "2": service.EditStudentMenu(db); break;
                case "3": service.DeleteStudentMenu(db); break;
                case "4": service.ListStudentsMenu(db); break;
                case "5": scService.RegisterStudentToCourseMenu(db); break;
                case "6": service.ShowStudentOverviewMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }

    // ----------------- COURSES -----------------

    static void CourseMenu(K2DbContext db, CourseService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== COURSES ======");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. List Courses");
            Console.WriteLine("3. Show Active Courses With Students");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddCourseMenu(db); break;
                case "2": service.ListCoursesMenu(db); break;
                case "3": service.ShowActiveCoursesMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }

    // ----------------- TEACHERS -----------------

    static void TeacherMenu(K2DbContext db, TeacherService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== TEACHERS ======");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Edit Teacher");
            Console.WriteLine("3. Delete Teacher");
            Console.WriteLine("4. List Teachers");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddTeacherMenu(db); break;
                case "2": service.EditTeacherMenu(db); break;
                case "3": service.DeleteTeacherMenu(db); break;
                case "4": service.ListTeachersMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }

    // ----------------- SCHEDULE -----------------

    static void ScheduleMenu(K2DbContext db, ScheduleService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== SCHEDULE ======");
            Console.WriteLine("1. Add Schedule Entry");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddScheduleMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }

    // ----------------- GRADES -----------------

    static void GradesMenu(K2DbContext db, GradesService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== GRADES ======");
            Console.WriteLine("1. Register Grade");
            Console.WriteLine("2. Show Grade Overview");
            Console.WriteLine("3. Report - Year");
            Console.WriteLine("4. Report - Half-year");
            Console.WriteLine("5. Report - Quarter");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddGradeMenu(db); break;
                case "2": service.ShowGradeOverviewMenu(db); break;
                case "3": service.ReportYearMenu(db); break;
                case "4": service.ReportHalfYearMenu(db); break;
                case "5": service.ReportQuarterMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }

    // ----------------- CLASSROOMS -----------------

    static void ClassroomMenu(K2DbContext db, ClassroomService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== CLASSROOMS ======");
            Console.WriteLine("1. Add Classroom");
            Console.WriteLine("2. List Classrooms");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": service.AddClassroomMenu(db); break;
                case "2": service.ListClassroomsMenu(db); break;
                case "0": return;
            }

            Console.ReadKey();
        }
    }
}
