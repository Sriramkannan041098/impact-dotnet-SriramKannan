using System;
using System.Collections.Generic;
using System.Text;

namespace A3_CoreConceptsAndSorting.Sorting
{
    public class EmployeeHandler
    {
        public EmployeeHandler()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "Suresh", 65000),
                new Employee(2, "Arun", 85000),
                new Employee(3, "Priya", 55000),
                new Employee(4, "Karthik", 75000),
                new Employee(5, "Divya", 95000),
                new Employee(6, "Rahul", 60000),
                new Employee(7, "Anitha", 80000),
                new Employee(8, "Vijay", 50000),
                new Employee(9, "Meena", 70000),
                new Employee(10, "Bala", 90000)
            };


            // Default Sort()
            // IComparable<Employee>
            Console.WriteLine("Sorted by Salary:");

            employees.Sort();

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }


            // Custom Sort
            // IComparer<Employee>
            Console.WriteLine( "\nSorted by Name:"  );

            EmployeeNameComparer nameComparer =   new EmployeeNameComparer();

            employees.Sort(nameComparer);

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }


}
