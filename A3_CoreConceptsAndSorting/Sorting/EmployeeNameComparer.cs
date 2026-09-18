namespace A3_CoreConceptsAndSorting.Sorting
{
    public class EmployeeNameComparer : IComparer<Employee>
    {
        // Custom sorting: Name ascending
        public int Compare( Employee? first,  Employee? second)
        {
            if (first == null && second == null)
            {
                return 0;
            }

            if (first == null)
            {
                return -1;
            }

            if (second == null)
            {
                return 1;
            }

            return string.Compare(
                first.Name,
                second.Name,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }


}
