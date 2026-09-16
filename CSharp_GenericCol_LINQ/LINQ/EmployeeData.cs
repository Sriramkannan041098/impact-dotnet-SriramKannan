using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_GenericCol_LINQ.LINQ
{
    public class EmployeeData
    {
        // Constructor
        public EmployeeData()
        {
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee("Mark Antony", "IT", 75000, new DateTime(2020, 5, 10)),

                new Employee("Elizabeth", "HR", 55000,  new DateTime(2021, 3, 15)),

                new Employee("Rohit Sharma",  "IT", 90000, new DateTime(2019, 7, 20)),

                new Employee("Kenisha", "Finance",   65000, new DateTime(2022, 1, 10)),

                new Employee("Stephan Zachariah",  "IT", 48000,  new DateTime(2023, 6, 5)),

                new Employee( "Preethika",  "HR",  72000, new DateTime(2018, 11, 12) ),

                new Employee( "Sriram",  "SDE",  85000, new DateTime(2018, 11, 12) ),

                new Employee( "Vishnu",  "SDE",  68500, new DateTime(2018, 11, 12) ),

                new Employee( "Prame",  "SDE",  88000, new DateTime(2018, 11, 12) ),

                new Employee("Senathipathi",  "Finance", 85000, new DateTime(2017, 9, 25))                
            };
        }
    }
}
