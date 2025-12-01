using CourseAdministrationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAdministrationSystem.Data;

public class K2DbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // ALTERNATIV 1 – LocalDB
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=K2DB;Trusted_Connection=True;TrustServerCertificate=True"
            );


            // ALTERNATIV 2 – localhost
            //optionsBuilder.UseSqlServer(
            //    "Server=localhost;Database=K2DB;Trusted_Connection=True;TrustServerCertificate=True;"
            //);
        }
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

        // No cascade on Grade → Teacher
        modelBuilder.Entity<Grades>()
            .HasOne(g => g.Teacher)
            .WithMany(t => t.Grades)
            .HasForeignKey(g => g.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        // No cascade on Schedule → Course
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // No cascade on Course → Teacher
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
