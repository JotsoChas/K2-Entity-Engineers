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

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== ADMIN MENU ======");
            Console.WriteLine("1. Students");
            Console.WriteLine("2. Courses");
            Console.WriteLine("3. Teachers");
            Console.WriteLine("4. Schedule");
            Console.WriteLine("5. Grades");
            Console.WriteLine("0. Exit");
            Console.Write("Select: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": StudentMenu(db, studentService); break;
                case "2": CourseMenu(db, courseService); break;
                case "3": TeacherMenu(db, teacherService); break;
                case "4": ScheduleMenu(db, scheduleService); break;
                case "5": GradesMenu(db, gradesService); break;
                case "0": return;
            }
        }
    }

    // ----------------- STUDENT MENU -----------------

    static void StudentMenu(K2DbContext db, StudentService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== STUDENTS ======");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Edit Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. List Students");
            Console.WriteLine("0. Back");
            Console.Write("Select: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("First name: ");
                    var f = Console.ReadLine();
                    Console.Write("Last name: ");
                    var l = Console.ReadLine();
                    service.AddStudent(db, f, l);
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Student ID: ");
                    service.EditStudent(db, int.Parse(Console.ReadLine()));
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Student ID: ");
                    service.DeleteStudent(db, int.Parse(Console.ReadLine()));
                    Console.ReadKey();
                    break;

                case "4":
                    service.ListStudents(db);
                    Console.ReadKey();
                    break;

                case "0":
                    return;
            }
        }
    }

    // ----------------- COURSES -----------------
    static void CourseMenu(K2DbContext db, CourseService service)
    {
        Console.Clear();
        Console.WriteLine("Course menu (add/edit/delete/list will go here)");
        Console.ReadKey();
    }

    // ----------------- TEACHERS -----------------
    static void TeacherMenu(K2DbContext db, TeacherService service)
    {
        Console.Clear();
        Console.WriteLine("Teacher menu (add/edit/delete/list will go here)");
        Console.ReadKey();
    }

    // ----------------- SCHEDULE -----------------
    static void ScheduleMenu(K2DbContext db, ScheduleService service)
    {
        Console.Clear();
        Console.WriteLine("Schedule menu (add schedule rows)");
        Console.ReadKey();
    }

    // ----------------- GRADES -----------------
    static void GradesMenu(K2DbContext db, GradesService service)
    {
        Console.Clear();
        Console.WriteLine("Grades menu (register or edit grades)");
        Console.ReadKey();
    }
}
