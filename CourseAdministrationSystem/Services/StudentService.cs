using CourseAdministrationSystem.Data;
using CourseAdministrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAdministrationSystem.Services
{
    public class StudentService
    {
        public void AddStudent(K2DbContext db, string FirstName, string LastName)
        {
            var newStudent = new Student
            {
                StudentFirstName = FirstName,
                StudentLastName = LastName
            };

            db.Students.Add(newStudent);
            db.SaveChanges();
            Console.WriteLine($"Student {FirstName} {LastName} added with ID: {newStudent.StudentId}");
        }

        public void EditStudent (K2DbContext db, int studentId, string newFirstName, string newLastName)
        {
            // Dicuss what fields can be edited
        }

        public void DeleteStudent(K2DbContext db, int id)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                string deletedName = $"{student.StudentFirstName} {student.StudentLastName}";
                db.Students.Remove(student);
                db.SaveChanges();
                Console.WriteLine($"Student {deletedName} with ID: {id} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Student with ID: {id} not found.");
            }
        }

        public void ListStudents(K2DbContext db)
        {
            var students = db.Students.ToList();
            Console.WriteLine("List of students:");
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId} | Name: {s.StudentFirstName} {s.StudentLastName}");
            }
        }
    }
}
