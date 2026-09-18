namespace A3_CoreConceptsAndSorting.Sorting
{
    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        // Default sorting: Salary ascending
        public int CompareTo(Employee? other)
        {
            if (other == null)
            {
                return 1;
            }

            return Salary.CompareTo(
                other.Salary
            );
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Salary:C}";
        }
    }


}
