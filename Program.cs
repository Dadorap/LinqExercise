using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace LinqExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, Name = "Alice", Age = 20, Grade = 85.5, IsEnrolled = true },
                new Student { StudentId = 2, Name = "Bob", Age = 22, Grade = 78.0, IsEnrolled = false },
                new Student { StudentId = 3, Name = "Charlie", Age = 21, Grade = 92.3, IsEnrolled = true },
                new Student { StudentId = 4, Name = "Diana", Age = 23, Grade = 88.8, IsEnrolled = true },
                new Student { StudentId = 5, Name = "Eve", Age = 20, Grade = 69.4, IsEnrolled = false }
            };

            //1 Find all students who are currently enrolled.
            var enrolledStudents = students.FindAll(s => s.IsEnrolled);
            //enrolledStudents.ForEach(student => Console.WriteLine(student.Name));
            //2 Retrieve the names of students whose grades are above 80.
            var studentGrade = students.Where(s => s.Grade > 80).ToList();
            //studentGrade.ForEach(s => Console.WriteLine(s.Name));
            //3 Find the average grade of all students.
            var averageGrade = students.Sum(s => s.Grade / students.Count);
            //Console.WriteLine(averageGrade );
            var avr = students.Average(s => s.Grade);
            //Console.WriteLine(avr);
            //4 Sort the students by their grades in descending order and display their names and grades.
            var stuGrade = students.OrderByDescending(s => s.Grade).ToList();
            //stuGrade.ForEach(s => Console.WriteLine($"Students name: {s.Name} with grade: {s.Grade}"));
            //5 Group the students by their enrollment status(IsEnrolled) and display the groups.
            var stuIsEn = students.GroupBy(s => s.IsEnrolled);
            //foreach ( var student in stuIsEn)
            //{
            //    Console.WriteLine("Is enrolled; "+student.Key);
            //    foreach (var item in student)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}

            //6 Find the student with the highest grade.
            var smartestStudent = students.OrderByDescending(s => s.Grade).First();
            //Console.WriteLine(smartestStudent.Name);
            //7 Check if all students are above the age of 18.
            var studentsAge = students.All(s => s.Age > 18);
            if (studentsAge)
            {
                //Console.WriteLine("Yes all students are above 18");
            }
            else
            {
                //Console.WriteLine("No not all students are above 18");
            }

            //8 Retrieve a list of student names and their corresponding grades as a new anonymous type.
            var newStudentList = students.Select(s => new {s.Name, s.Grade});
            foreach (var student in newStudentList)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Grade);
            }



        }
    }
}