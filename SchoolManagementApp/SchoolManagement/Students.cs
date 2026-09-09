using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class Students
    {
        public string Name { get; set; }
        public string ID { get; set; }


        public Students(string name, string id)
        { 
            Name = name;
            ID = id;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"\nStudent Details: {ID} - {Name}");
        }   

        public void NamingConvensions()
        {
            // Local variable - PascalCase
            string DeptName = "SoftwareEngineering";         

            // Local variable - camelCase
            string courseName = ".Net Full Stack Development";

            Console.WriteLine($"Department: {DeptName}");
            Console.WriteLine($"Course: {courseName}");
        }
    }
}
