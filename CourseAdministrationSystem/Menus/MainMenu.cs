using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAdministrationSystem.Menus
{
    public class MainMenu
    {
        private readonly K2DbContext _db;
        private readonly CourseService _courseService;
        private readonly StudentService _studentService;

        public MainMenu(K2DbContext db, CourseService courseService, StudentService studentService)
        {
            _db = db;
            _courseService = courseService;
            _studentService = studentService;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Students Menu");
                Console.WriteLine("2. Courses Menu");
                Console.WriteLine("3. Grades Menu");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var StudentMenu = new StudentMenu(_db, _studentService);
                        StudentMenu.Run();
                        break;
                    case "2":
                        var courseMenu = new CourseMenu(_db, _courseService);
                        courseMenu.Run();
                        break;
                    case "3":
                        // add grades menu
                        //gradesMenu.Run();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
