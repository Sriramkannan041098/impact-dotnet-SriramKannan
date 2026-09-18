using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class Students
    {
        public string Name { get; set; }
        public string ID { get; set; }


        public Students(string q1, string q2)
        {            
            Name = q1;
            ID = q2;
        }



        public void DisplayStudentInfo()
        {
            try 
            {
               Console.WriteLine($"Student Details: {ID} - {Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }   

        public void NamingConvensions()
        {
            try
            {
                
                string DeptName = "Mechanical Engineering";   // Local variable - PascalCase                
                string courseName = ".Net Full Stack Development";  // Local variable - camelCase
                int studentCount = 25;
                double courseDuration = 6.5;
                bool isCourseActive = true;

                Console.WriteLine($"Department: {DeptName}");
                Console.WriteLine($"Course: {courseName}");
                Console.WriteLine($"Student Count: {studentCount}");
                Console.WriteLine($"Course Duration: {courseDuration} months");
                Console.WriteLine($"Course Active: {isCourseActive}");

                Console.WriteLine("\nTry a variable named class, observe the error and fix ");
                string @class = "C#"; 
                Console.WriteLine($"Class: {@class}");
                // Error: 'class' is a keyword and cannot be used as an identifier.
                // to fix this '@' used to treat the reserved keyword as an identifier

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }
}
