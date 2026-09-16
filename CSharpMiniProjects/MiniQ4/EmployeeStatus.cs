using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMiniProjects.MiniQ4
{
    public abstract class EmployeeStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        // Constructor
        protected EmployeeStatus(
            int id,
            string name,
            string department)
        {
            Id = id;
            Name = name;
            Department = department;
        }

        // Abstract method
        public abstract decimal CalculateSalary();
    }

}
