using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_GenericCol_LINQ.LINQ
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }



        // Constructor
        public Employee(string name, string department, decimal salary, DateTime joiningDate)
        {
            Name = name;
            Department = department;
            Salary = salary;
            JoiningDate = joiningDate;
        }
    }
}
