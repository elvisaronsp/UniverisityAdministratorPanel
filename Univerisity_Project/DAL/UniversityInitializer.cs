using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Univerisity_Project.Models;

namespace Univerisity_Project.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var users = new List<User>
            {
                new User{ UserName = "User1", Password = "User111"},
                new User{ UserName = "User2", Password = "User222"},
                new User{ UserName = "User3", Password = "User333"},
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var userdetails = new List<UserDetail>
            {
                new UserDetail{ User = users[0], UserName = users[0].UserName},
                new UserDetail{ User = users[1], UserName = users[1].UserName},
                new UserDetail{ User = users[2], UserName = users[2].UserName},
            };
            userdetails.ForEach(s => context.UserDetails.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
            new Student{FirstName="Giorgi",LastName="Kiknadze",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Giorgi",LastName="Xubutia",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Tornike",LastName="Tordia",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Nino",LastName="Sasania",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Lazare",LastName="Chumburidze",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Soso",LastName="Davadze",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Shmagi",LastName="Kalandadze",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Irakli",LastName="Arevadze",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Nino",LastName="Arevadze",EnrollmentDate=DateTime.Parse("2009-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "instructor1",     LastName = "lastname1", 
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "instructor2",    LastName = "lastname2",    
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "instructor3",   LastName = "lastname3",       
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "instructor4", LastName = "lastname4",      
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "instructor5",   LastName = "lastname5",      
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "ComputerSciences",     Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "lastname1").ID },
                new Department { Name = "Mathematics", Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "lastname2").ID },
                new Department { Name = "Engineering", Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "lastname3").ID },
                new Department { Name = "Economics",   Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "lastname4").ID }
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();
            
            var CourseCounters = new List<DepartmentCourseCounter>
            {
                new DepartmentCourseCounter { Department = 1, CourseNumber = 2 },
                new DepartmentCourseCounter { Department = 2, CourseNumber = 3 },
                new DepartmentCourseCounter { Department = 3, CourseNumber = 0 },
                new DepartmentCourseCounter { Department = 4, CourseNumber = 2 },
            };
            CourseCounters.ForEach(s => context.Deps.Add(s));
            context.SaveChanges();
            
            var courses = new List<Course>
            {
                new Course {CourseID = 10, Title = "C#",      Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "ComputerSciences").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 12, Title = "Microeconomics", Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 15, Title = "Macroeconomics", Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 17, Title = "Calculus",       Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 25, Title = "Trigonometry",   Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 18, Title = "Algebra",    Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 21, Title = "Java",     Credits = 5,
                  DepartmentID = departments.Single( s => s.Name == "ComputerSciences").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "lastname2").ID, 
                    Location = "Lab 418" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "lastname3").ID, 
                    Location = "Lab 420" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "lastname4").ID, 
                    Location = "Lab 407" },
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "lastname1").ID,
                    Location = "Lab 410" },
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "lastname5").ID,
                    Location = "Lan 419" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.Add(s));
            context.SaveChanges();
          
            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=10,Grade=Grade.A},
                new Enrollment{StudentID=8,CourseID=15,Grade=Grade.C},
                new Enrollment{StudentID=8,CourseID=18,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=21,Grade=Grade.B},
                new Enrollment{StudentID=9,CourseID=12,Grade=Grade.F},
                new Enrollment{StudentID=9,CourseID=17,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=17,Grade=Grade.B},
                new Enrollment{StudentID=4,CourseID=17,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=15,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=18,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=21,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=18,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges(); 
        }
    }
}