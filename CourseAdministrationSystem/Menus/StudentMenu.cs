using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Services;

namespace CourseAdministrationSystem.Menus
{
    public class StudentMenu
    {
        private readonly K2DbContext _db;
        private readonly StudentService _studentService;

        public StudentMenu(K2DbContext db, StudentService studentService)
        {
            _db = db;
            _studentService = studentService;
        }

        public void Run()
        {
            bool runningStudentMenu = true;

            while (runningStudentMenu)
            {
                Console.Clear();
                Console.WriteLine("---- Student Menu ----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Edit Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. List Students");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        _studentService.AddStudent(_db, firstName, lastName);
                        break;
                    case "2":
                        // Implement Edit Student functionality
                        Console.WriteLine("Not added.");
                        break;
                    case "3":
                        Console.Write("Enter Student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            _studentService.DeleteStudent(_db, deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        break;
                    case "4":
                        _studentService.ListStudents(_db);
                        break;
                    case "5":
                        runningStudentMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}