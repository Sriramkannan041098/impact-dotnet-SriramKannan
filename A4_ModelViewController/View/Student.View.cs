using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.View
{
    public class StudentView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n===== Student Management =====");

            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Find Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");
        }

        public void PrintStudents(List<Student> students)
        {
            Console.WriteLine(
                "\nID   Name          Age   Roll No     Email"
            );

            Console.WriteLine(
                "------------------------------------------------------"
            );

            foreach (Student student in students)
            {
                Console.WriteLine(
                    $"{student.Id,-4}" +
                    $"{student.StudentName,-15}" +
                    $"{student.Age,-6}" +
                    $"{student.RollNumber,-12}" +
                    $"{student.Email}"
                );
            }
        }

        public Student PromptForStudent()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Name: ");
            string stdname = Console.ReadLine()!;

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Roll Number: ");
            string rollNumber = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;

            return new Student(
                id,
                stdname,
                age,
                rollNumber,
                email
            );

            //try
            //{

            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"Unknown Error : ${ex.Message}");
            //}

        }



        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
