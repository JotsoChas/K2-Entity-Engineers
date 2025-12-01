using CourseAdministrationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Data;

public class K2DbContext : DbContext
{
    public K2DbContext(DbContextOptions<K2DbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Grades> Grades { get; set; }
    public DbSet<StudentCourses> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
