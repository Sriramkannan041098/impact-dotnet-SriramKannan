using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpModernSyntax.StudentClass
{
    public static class StudentClassDemo
    {
       
        public static void DemonstrateStudentClass()
        {
            try
            {
                // Parameterized constructor
                Student student1 = new Student("Sriram", 25);

                Console.WriteLine("Student 1:");
                Console.WriteLine($"Name: {student1.Name}");
                Console.WriteLine($"Age: {student1.Age}");

                // Constructor chaining
                Student student2 = new Student();

                Console.WriteLine("\nStudent 2:");
                Console.WriteLine($"Name: {student2.Name}");
                Console.WriteLine($"Age: {student2.Age}");

                // CalculateGrade() without parameter
                Console.WriteLine(
                    $"Student 1 Grade: {student1.CalculateGrade()}"
                );

                // CalculateGrade() overloaded method
                Console.WriteLine(
                    $"Student 1 Grade for Score 85: {student1.CalculateGrade(85)}"
                );

                // Valid age
                Console.WriteLine("\nUpdating age to 30...");
                student1.Age = 30;

                Console.WriteLine($"Updated Age: {student1.Age}");

                // Invalid age
                Console.WriteLine("\nUpdating age to 120...");

                try
                {
                    student1.Age = 120;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Validation Error: {ex.Message}");
                }

                // const vs readonly
                Console.WriteLine("\nConst vs Readonly:");

                Console.WriteLine($"College Name (const): {Student.CollegeName}");
                Console.WriteLine($"Student ID (readonly): {student1.StudentId}");

                Console.WriteLine(
                    "const value cannot be changed after compilation."
                );

                Console.WriteLine(
                    "readonly value can only be assigned during declaration or constructor."
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class Student
    {
        // const field
        public const string CollegeName = "SRM TRP Engineering College";

        // readonly field
        public readonly int StudentId;

        private static int nextStudentId = 1001;

        private int age;

        public string Name { get; set; }

        // Validated Age property
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 5 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Age must be between 5 and 100."
                    );
                }

                age = value;
            }
        }

        // Default constructor chained to parameterized constructor
        public Student()
            : this("Unknown", 18)
        {
            Console.WriteLine("Default constructor called through constructor chaining.");
        }

        // Parameterized constructor
        public Student(string name, int age)
        {
            Name = name;
            Age = age;

            StudentId = nextStudentId++;

            Console.WriteLine("Parameterized constructor called.");
        }

        // Method overloading
        public string CalculateGrade()
        {
            return "Grade calculation requires a score.";
        }

        public string CalculateGrade(int score)
        {
            return score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
        }
    }
}
