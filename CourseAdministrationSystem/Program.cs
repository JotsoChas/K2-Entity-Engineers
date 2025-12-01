using CourseAdministrationSystem.Data;

namespace CourseAdministrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new K2DbContext();

            Console.WriteLine("K2 connected");
        }
    }
}
