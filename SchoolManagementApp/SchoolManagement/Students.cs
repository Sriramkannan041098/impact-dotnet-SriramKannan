using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementApp.SchoolManagement
{
    public class Students
    {
        public string Name { get; set; }

        public Students(string name)
        {
            Name = name;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"\nStudent Name: {Name}");
        }   
    }
}
