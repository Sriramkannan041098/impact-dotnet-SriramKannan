using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMiniProjects.MiniQ4
{
    public class FullTimeEmployee : EmployeeStatus, ITaxable
    {
        public decimal MonthlySalary { get; set; }

        // Constructor
        public FullTimeEmployee(int id, string name, string department, decimal monthlySalary) : base(id, name, department)
        {
            MonthlySalary = monthlySalary;
        }

        // Override
        public override decimal CalculateSalary()
        {
            return MonthlySalary;
        }

        // ITaxable implementation
        public decimal CalculateTax()
        {
            return MonthlySalary * 0.10m;
        }
    }
}
