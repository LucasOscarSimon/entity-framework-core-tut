using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext()) {

                var std = new Student()
                {
                    Name = "Bill"
                };

                context.Students.Add(std);
                context.SaveChanges();

                Console.WriteLine(context.Students.FirstOrDefault()?.Name);
                Console.ReadLine();
            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
