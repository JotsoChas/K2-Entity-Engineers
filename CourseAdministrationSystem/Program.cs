using CourseAdministrationSystem.Data;
using System.Text;

namespace CourseAdministrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Console.Title = "Entity Engineers";

            using var db = new K2DbContext();
            Menu.ShowMainMenu(db);
        }
    }
}
