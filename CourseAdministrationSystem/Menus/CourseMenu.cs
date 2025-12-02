using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAdministrationSystem.Menus
{
    public class CourseMenu
    {
        private readonly K2DbContext _db;
        private readonly CourseService _service;

        public CourseMenu(K2DbContext db, CourseService service)
        {
            _db = db;
            _service = service;
        }

        public void Run()
        {
            bool runningCourseMenu = true;
            while (runningCourseMenu)
            {
                Console.Clear();
                Console.WriteLine("---- Course Menu ----");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Edit Course");
                Console.WriteLine("3. Delete Course");
                Console.WriteLine("4. List Courses");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Implement Add Course functionality?
                        Console.WriteLine("Not added.");
                        break;
                    case "2":
                        // Implement Edit Course functionality?
                        Console.WriteLine("Not added.");
                        break;
                    case "3":
                        // Implement Delete Course functionality?
                        Console.WriteLine("Not added.");
                        break;
                    case "4":
                        // Implement List Courses functionality?
                        Console.WriteLine("Not added.");
                        break;
                    case "5":
                        runningCourseMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
