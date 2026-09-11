namespace CSharpAdvancedConcepts.FeatureApp
{
    public partial class Employee
    {
        partial void CreateEmployee()
        {
            Console.WriteLine("Creating Employee...");
            
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Employee Created Successfully!"); 
        }
    }
}
