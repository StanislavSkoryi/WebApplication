using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApplication.Data.Entities
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new WebApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplicationContext>>());

            if (!context.Course.Any())
            {
                context.Course.AddRange(
                new Course
                {
                    Name = "First Course"
                },
                new Course
                {
                    Name = "Second Course",
                },
                new Course
                {
                    Name = "Third Course",
                }
                );
            }

            if (!context.Group.Any())
            {
                context.Group.AddRange(
                new Group
                {
                    Name = "M-07-1",
                    CourseId = 3
                },
                new Group
                {
                    Name = "M-07-2",
                    CourseId = 3
                },
                new Group
                {
                    Name = "M-07-3",
                    CourseId = 3
                },
                new Group
                {
                    Name = "F-08-1",
                    CourseId = 2
                },
                new Group
                {
                    Name = "F-08-2",
                    CourseId = 2
                },
                new Group
                {
                    Name = "F-08-3",
                    CourseId = 2
                },
                new Group
                {
                    Name = "T-09-1",
                    CourseId = 1
                },
                new Group
                {
                    Name = "T-09-2",
                    CourseId = 1
                },
                new Group
                {
                    Name = "T-09-3",
                    CourseId = 1
                }
                );
            }

            if (context.Student.Any())
            {
                return;
            }

            context.Student.AddRange(
                new Student
                {
                    FirstName = "Yuval",
                    LastName = "Harari",
                    GroupId = 1
                },
                new Student
                {
                    FirstName = "Daniel",
                    LastName = "Kahneman,",
                    GroupId = 2
                },
                new Student
                {
                    FirstName = "Nikolai",
                    LastName = "Kukushkin",
                    GroupId = 3
                },
                new Student
                {
                    FirstName = "Alexandr",
                    LastName = "Markov",
                    GroupId = 4
                },
                new Student
                {
                    FirstName = "Asya",
                    LastName = "Kazantseva",
                    GroupId = 5
                },
                new Student
                {
                    FirstName = "Alexandr",
                    LastName = "Panchin",
                    GroupId = 6
                },
                new Student
                {
                    FirstName = "Vladimir",
                    LastName = "Surdin",
                    GroupId = 7
                },
                new Student
                {
                    FirstName = "Stanislav",
                    LastName = "Drobyshevsky",
                    GroupId = 8
                },
                new Student
                {
                    FirstName = "Jared",
                    LastName = "Diamond",
                    GroupId = 9
                },
                new Student
                {
                    FirstName = "Peter",
                    LastName = "Talantov",
                    GroupId = 1
                },
                new Student
                {
                    FirstName = "Alexey",
                    LastName = "Savvateev",
                    GroupId = 2
                },
                new Student
                {
                    FirstName = "Irina",
                    LastName = "Yakutenko",
                    GroupId = 3
                },
                new Student
                {
                    FirstName = "Alexandr",
                    LastName = "Sokolov",
                    GroupId = 4
                },
                new Student
                {
                    FirstName = "Vyacheslav",
                    LastName = "Dubynin",
                    GroupId = 5
                },
                new Student
                {
                    FirstName = "Ilya",
                    LastName = "Kolmanovsky",
                    GroupId = 6
                },
                new Student
                {
                    FirstName = "Mikhail",
                    LastName = "Gelfand",
                    GroupId = 7
                },
                new Student
                {
                    FirstName = "Konstantin",
                    LastName = "Severinov",
                    GroupId = 8
                },
                new Student
                {
                    FirstName = "Andrey",
                    LastName = "Konyaev",
                    GroupId = 9
                },
                new Student
                {
                    FirstName = "Andrey",
                    LastName = "Sazonov",
                    GroupId = 1
                },
                new Student
                {
                    FirstName = "Richard",
                    LastName = "Dawkins",
                    GroupId = 2
                },
                new Student
                {
                    FirstName = "Stephen",
                    LastName = "Hawking",
                    GroupId = 3
                },
                new Student
                {
                    FirstName = "Carl",
                    LastName = "Sagan",
                    GroupId = 4
                },
                new Student
                {
                    FirstName = "Neil",
                    LastName = "Tyson",
                    GroupId = 5
                },
                new Student
                {
                    FirstName = "Michio",
                    LastName = "Kaku",
                    GroupId = 6
                },
                new Student
                {
                    FirstName = "Lawrence",
                    LastName = "Krauss",
                    GroupId = 7
                }
            );
            context.SaveChanges();
        }
    }
}
