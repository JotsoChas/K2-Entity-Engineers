using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;
using Utils;

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
            ConsoleHelper.Clear();
            Console.WriteLine("====== ADMIN MENU ======");
            Console.WriteLine("1. Students");
            Console.WriteLine("2. Courses");
            Console.WriteLine("3. Teachers");
            Console.WriteLine("4. Schedule");
            Console.WriteLine("5. Grades");
            Console.WriteLine("6. Classrooms");
            Console.WriteLine("0. Exit");
            Console.WriteLine("\nSelect:");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: StudentMenu(db, studentService, studentCourseService); break;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: CourseMenu(db, courseService); break;
                case ConsoleKey.D3: case ConsoleKey.NumPad3: TeacherMenu(db, teacherService); break;
                case ConsoleKey.D4: case ConsoleKey.NumPad4: ScheduleMenu(db, scheduleService); break;
                case ConsoleKey.D5: case ConsoleKey.NumPad5: GradesMenu(db, gradesService); break;
                case ConsoleKey.D6: case ConsoleKey.NumPad6: ClassroomMenu(db, classroomService); break;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }

    static void StudentMenu(K2DbContext db, StudentService service, StudentCoursesService scService)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== STUDENTS ======");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Edit Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. Register Student to Course");
            Console.WriteLine("6. Show Student Overview");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddStudentMenu(db); return;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: service.EditStudentMenu(db); return;
                case ConsoleKey.D3: case ConsoleKey.NumPad3: service.DeleteStudentMenu(db); return;
                case ConsoleKey.D4: case ConsoleKey.NumPad4: service.ListStudentsMenu(db); return;
                case ConsoleKey.D5: case ConsoleKey.NumPad5: scService.RegisterStudentToCourseMenu(db); return;
                case ConsoleKey.D6: case ConsoleKey.NumPad6: service.ShowStudentOverviewMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }

    static void CourseMenu(K2DbContext db, CourseService service)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== COURSES ======");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. List Courses");
            Console.WriteLine("3. Show Active Courses With Students");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");


            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddCourseMenu(db); return;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: service.ListCoursesMenu(db); return;
                case ConsoleKey.D3: case ConsoleKey.NumPad3: service.ShowActiveCoursesMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }
    static void TeacherMenu(K2DbContext db, TeacherService service)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== TEACHERS ======");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Edit Teacher");
            Console.WriteLine("3. Delete Teacher");
            Console.WriteLine("4. List Teachers");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");


            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddTeacherMenu(db); return;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: service.EditTeacherMenu(db); return;
                case ConsoleKey.D3: case ConsoleKey.NumPad3: service.DeleteTeacherMenu(db); return;
                case ConsoleKey.D4: case ConsoleKey.NumPad4: service.ListTeachersMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }

    static void ScheduleMenu(K2DbContext db, ScheduleService service)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== SCHEDULE ======");
            Console.WriteLine("1. Add Schedule Entry");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");


            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddScheduleMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }

    static void GradesMenu(K2DbContext db, GradesService service)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== GRADES ======");
            Console.WriteLine("1. Register Grade");
            Console.WriteLine("2. Show Grade Overview");
            Console.WriteLine("3. Report - Year");
            Console.WriteLine("4. Report - Half-year");
            Console.WriteLine("5. Report - Quarter");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddGradeMenu(db); return;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: service.ShowGradeOverviewMenu(db); return;
                case ConsoleKey.D3: case ConsoleKey.NumPad3: service.ReportYearMenu(db); return;
                case ConsoleKey.D4: case ConsoleKey.NumPad4: service.ReportHalfYearMenu(db); return;
                case ConsoleKey.D5: case ConsoleKey.NumPad5: service.ReportQuarterMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }

    static void ClassroomMenu(K2DbContext db, ClassroomService service)
    {
        while (true)
        {
            ConsoleHelper.Clear();
            Console.WriteLine("====== CLASSROOMS ======");
            Console.WriteLine("1. Add Classroom");
            Console.WriteLine("2. List Classrooms");
            Console.WriteLine("0. Back");
            Console.WriteLine("\nSelect:");


            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: service.AddClassroomMenu(db); return;
                case ConsoleKey.D2: case ConsoleKey.NumPad2: service.ListClassroomsMenu(db); return;
                case ConsoleKey.D0: case ConsoleKey.NumPad0: return;
            }
        }
    }
}
