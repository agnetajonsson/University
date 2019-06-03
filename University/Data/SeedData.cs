using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Data
{
    public static class SeedData
    {
        internal static void Initialize(IServiceProvider services)
        {
            var options = services.GetRequiredService<DbContextOptions<UniversityContext>>();
            using(var context = new UniversityContext(options))
            {
                if (context.Student.Any())
                {
                    context.Student.RemoveRange(context.Student);
                    context.Course.RemoveRange(context.Course);
                    context.Enrollment.RemoveRange(context.Enrollment);
                }

                var students = new List<Student>();
                for (int i = 0; i < 100; i++)
                {
                    var name = Faker.Name.FullName();
                    var student = new Student
                    {
                        Name = name,
                        Email = Faker.Internet.Email(name),
                        Address = new Address
                        {
                            Street = Faker.Address.StreetAddress(),
                            City = Faker.Address.City()
                        }
                    };
                    students.Add(student);
                }
                context.Student.AddRange(students);

                var textInfo = new CultureInfo("en-us", false).TextInfo;
                var courses = new List<Course>();
                for (int i = 0; i < 10; i++)
                {
                    var course = new Course
                    {
                        Title = textInfo.ToTitleCase(Faker.Company.CatchPhrase())
                    };
                    courses.Add(course);
                }
                context.Course.AddRange(courses);
                context.SaveChanges();

                var enrollments = new List<Enrollment>();
                foreach (var student in students)
                {
                    foreach (var course in courses)
                    {
                        if(Faker.RandomNumber.Next(5) == 0)
                        {
                            var enrollment = new Enrollment
                            {
                                Course = course,
                                Student = student,
                                Grade = Faker.RandomNumber.Next(1,6)
                            };
                            enrollments.Add(enrollment);
                        }
                    }
                }
                context.Enrollment.AddRange(enrollments);
                context.SaveChanges();

            }
        }
    }
}
