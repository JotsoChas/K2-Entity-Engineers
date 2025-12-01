using CourseAdministrationSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CourseAdministrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = builder.GetConnectionString("K2DB");

            var options = new DbContextOptionsBuilder<K2DbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new K2DbContext(options);

            Console.WriteLine("Connection successful!");
        }
    }
}
