namespace CSharpMiniProjects.MiniQ4
{
    public class PartTimeEmployee : EmployeeStatus
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        // Constructor
        public PartTimeEmployee( int id,string name, string department, decimal hourlyRate, int hoursWorked) : base(id, name, department)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Override
        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

}
