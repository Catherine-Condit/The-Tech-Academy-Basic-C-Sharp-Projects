using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstStudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                var student = new Student
                {
                    FirstName = "Alice",
                    LastName = "Caldwell",
                    Email = "alice.caldwell@example.com"
                };

                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("Student added successfully!");

                // Query the database for the added student
                var addedStudent = context.Students
                                          .Where(s => s.Email == student.Email)
                                          .FirstOrDefault();

                if (addedStudent != null)
                {
                    // Display the full name and email of the added student
                    Console.WriteLine($"\nStudent Info: \n{addedStudent.FirstName} {addedStudent.LastName}");
                    Console.WriteLine($"{addedStudent.Email}");
                }
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
