using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public string? TeacherName { get; set; }

        public string? Designation { get; set; }

        public string? Email { get; set; }



        public Teacher(int id, string teacherName, string designation, string email)
        {
            Id = id;
            TeacherName = teacherName;
            Designation = designation;
            Email = email;
        }
    }
}
