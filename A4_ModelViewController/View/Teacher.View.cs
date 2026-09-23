using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.View
{
    public class TeacherView
    {
        public void ShowMenu()
        {
            Console.WriteLine(
                "\n===== Teacher Management ====="
            );

            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. View Teachers");
            Console.WriteLine("3. Find Teacher");
            Console.WriteLine("4. Update Teacher");
            Console.WriteLine("5. Delete Teacher");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");
        }

        public void PrintTeachers(List<Teacher> teachers)
        {
            Console.WriteLine(
                "\nID   Name           Email              Designation"
            );

            Console.WriteLine(
                "----------------------------------------------------------"
            );

            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(
                    $"{teacher.Id,-4}" +
                    $"{teacher.TeacherName, -15}" +
                    $"{teacher.Email,-20}" +
                    $"{teacher.Designation}"
                );
            }
        }

        public Teacher PromptForTeacher()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Name: ");
            string name =  Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Designation: ");
            string designation = Console.ReadLine()!;

            return new Teacher(
                id,
                name,
                designation,
                email                
            );
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
