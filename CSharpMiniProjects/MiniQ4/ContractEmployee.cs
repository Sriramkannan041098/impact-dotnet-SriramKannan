namespace CSharpMiniProjects.MiniQ4
{
    public class ContractEmployee : EmployeeStatus
    {
        public decimal ContractAmount { get; set; }

        // Constructor
        public ContractEmployee(int id, string name, string department, decimal contractAmount) : base(id, name, department)
        {
            ContractAmount = contractAmount;
        }

        // Override
        public override decimal CalculateSalary()
        {
            return ContractAmount;
        }
    }

}
