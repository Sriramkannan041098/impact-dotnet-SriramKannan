using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string? StudentName { get; set; }

        public string? RollNumber { get; set; }

        public string? Email { get; set; }

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 5 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Age),
                        "Age must be between 5 and 100."
                    );
                }

                _age = value;
            }
        }      
        
        

        public Student( int id, string studentname, int age,  string rollNumber, string email)
        {
            Id = id;
            StudentName = studentname;
            Age = age;
            RollNumber = rollNumber;
            Email = email;
        }
    }
}
