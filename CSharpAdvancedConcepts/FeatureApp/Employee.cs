namespace CSharpAdvancedConcepts.FeatureApp
{
    public partial class Employee
    {
        public string Name { get; set; }
        public string Designation { get; set; }

        public Employee(string name, string designation)
        {
            Name = name;
            Designation = designation;

            CreateEmployee(); // Call the partial method to create the employee
        }

        public void DisplayEmpInfo()
        {
            Console.WriteLine($"Employee Name : {Name}");
            Console.WriteLine($"Designation   : {Designation}");
        }

        partial void CreateEmployee();

        /*
         * If a class is defined as Partial, then it can be split and accessed across multiple files. 
         * Here partially defined methods can be implemented in one part of the class and called from another part.
         * Eg :- CreateEmployee() is defined fully in Employee.Partial.cs and invoked and initialized in Employee.cs.
         */
    }
}
