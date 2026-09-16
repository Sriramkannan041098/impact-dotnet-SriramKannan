namespace CSharpMiniProjects.ExtensionMethods
{
    public class Employee
    {
        public string Name { get; set; }

        public decimal MonthlySalary { get; set; }

        // Constructor
        public Employee(string name, decimal monthlySalary)
        {
            Name = name;
            MonthlySalary = monthlySalary;
        }
    }
}
