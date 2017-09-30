//provides all the data for the database

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchedularApp.Models;using SchedularApp.Data;

namespace SchedularApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Jacob",   LastName = "Burton",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Ryan", LastName = "Zamora",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Cody",   LastName = "Roberts",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Nick",    LastName = "Lockwood",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Akira",      LastName = "Abdheraman",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Ben",    LastName = "Beck",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Zack",    LastName = "Merz",
                    EnrollmentDate = DateTime.Parse("2014-09-12") },
                new Student { FirstName = "Conner",     LastName = "Eggs",
                    EnrollmentDate = DateTime.Parse("2014-09-12") },
                new Student { FirstName = "Conner",     LastName = "Sick",
                    EnrollmentDate = DateTime.Parse("2014-09-12") },
                new Student { FirstName = "Drake",   LastName = "Gilly",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Dylan", LastName = "Camel",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Kiki",   LastName = "Cornell",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Izz",    LastName = "DaWiz",
                    EnrollmentDate = DateTime.Parse("2013-09-12") },
                new Student { FirstName = "Tiana",      LastName = "Rosario",
                    EnrollmentDate = DateTime.Parse("2015-09-12") },
                new Student { FirstName = "Tommy",    LastName = "Massari",
                    EnrollmentDate = DateTime.Parse("2015-09-12") },
                new Student { FirstName = "Ashely",    LastName = "Bolick",
                    EnrollmentDate = DateTime.Parse("2015-09-12") },
                new Student { FirstName = "Megan",     LastName = "Ratfield",
                    EnrollmentDate = DateTime.Parse("2015-09-12") },
                new Student { FirstName = "Chiara",     LastName = "Hammers",
                    EnrollmentDate = DateTime.Parse("2015-09-12") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Tom",     LastName = "Flynn",
                    HireDate = DateTime.Parse("1990-06-18") },
                new Instructor { FirstName = "Nate",    LastName = "Traceman",
                    HireDate = DateTime.Parse("2010-07-06") },
                new Instructor { FirstName = "Chiggity",   LastName = "Chad",
                    HireDate = DateTime.Parse("1990-07-01") },
                new Instructor { FirstName = "Mueler", LastName = "Moyle",
                    HireDate = DateTime.Parse("2001-11-15") },
                new Instructor { FirstName = "Mike",   LastName = "Kink",
                    HireDate = DateTime.Parse("2004-12-12") },
                new Instructor { FirstName = "Margretta",   LastName = "Hanson",
                    HireDate = DateTime.Parse("2004-07-01") },
                new Instructor { FirstName = "Jens", LastName = "Jensy",
                    HireDate = DateTime.Parse("2004-03-15") },
                new Instructor { FirstName = "Pat",   LastName = "Theman",
                    HireDate = DateTime.Parse("2000-04-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",    
                    StartDate = DateTime.Parse("2010-01-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Flynn").ID },
                new Department { Name = "Mathematics",
                    StartDate = DateTime.Parse("2010-01-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Hanson").ID },
                new Department { Name = "Engineering", 
                    StartDate = DateTime.Parse("2010-01-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Jensy").ID },
                new Department { Name = "Economics",
                    StartDate = DateTime.Parse("2010-01-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Theman").ID },
                new Department { Name = "ComputerScience", 
                    StartDate = DateTime.Parse("2010-01-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kink").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 100, Title = "Stuff", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 101, Title = "Security", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ComputerScience").DepartmentID
                },
                new Course {CourseID = 102, Title = "Numbers", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 103, Title = "Read", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 104, Title = "Add", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 105, Title = "Data", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ComputerScience").DepartmentID
                },
                new Course {CourseID = 106, Title = "OOP", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ComputerScience").DepartmentID
                },
                new Course {CourseID = 107, Title = "MVC", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ComputerScience").DepartmentID
                },
                new Course {CourseID = 108, Title = "ORM", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ComputerScience").DepartmentID
                },
                new Course {CourseID = 109, Title = "Subtract", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 200, Title = "Divide", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 201, Title = "Multiply", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 202, Title = "Tools",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 203, Title = "Create", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 204, Title = "Blah", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 205, Title = "Micro", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 206, Title = "Macro", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 207, Title = "Stock", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 208, Title = "Book", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 209, Title = "Scripture", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 300, Title = "Plato", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                }
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Stuff" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Flynn").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Security" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Traceman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Numbers" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Chad").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Read" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Moyle").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Add" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kink").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Data" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Traceman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "OOP" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Traceman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "MVC" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Traceman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "ORM" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Traceman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Subtract" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kink").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Divide" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kink").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Multiply" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kink").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Tools" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Flynn").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Create" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Flynn").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Blah" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Flynn").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Micro" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Chad").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macro" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Chad").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Stock" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Chad").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Book" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Moyle").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Scripture" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Moyle").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Plato" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Moyle").ID
                    }
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();


            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Beck").ID,
                    CourseID = courses.Single(c => c.Title == "Stuff" ).CourseID
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Lockwood").ID,
                    CourseID = courses.Single(c => c.Title == "Micro" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Cornell").ID,
                    CourseID = courses.Single(c => c.Title == "Macro" ).CourseID
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Merz").ID,
                    CourseID = courses.Single(c => c.Title == "Read" ).CourseID
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Eggs").ID,
                    CourseID = courses.Single(c => c.Title == "Data" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Hammers").ID,
                    CourseID = courses.Single(c => c.Title == "Security" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Gilly").ID,
                    CourseID = courses.Single(c => c.Title == "Blah" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Zamora").ID,
                    CourseID = courses.Single(c => c.Title == "Add").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Roberts").ID,
                    CourseID = courses.Single(c => c.Title == "Tools").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Sick").ID,
                    CourseID = courses.Single(c => c.Title == "MVC").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Massari").ID,
                    CourseID = courses.Single(c => c.Title == "OOP").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Burton").ID,
                    CourseID = courses.Single(c => c.Title == "Numbers").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Abdheraman").ID,
                    CourseID = courses.Single(c => c.Title == "ORM").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Camel").ID,
                    CourseID = courses.Single(c => c.Title == "Stock").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "DaWiz").ID,
                    CourseID = courses.Single(c => c.Title == "Subtract").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Rosario").ID,
                    CourseID = courses.Single(c => c.Title == "Book").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Ratfield").ID,
                    CourseID = courses.Single(c => c.Title == "Scripture").CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bolick").ID,
                    CourseID = courses.Single(c => c.Title == "Plato").CourseID
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null) //checks to see if that course has already been enrolled by the same student
                {
                    context.Enrollments.Add(e); //so if null, add that enrollment
                }
            }
            context.SaveChanges();
        }
    }
}