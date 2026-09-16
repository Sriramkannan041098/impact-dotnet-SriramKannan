namespace CSharp_GenericCol_LINQ.BooksManagement
{
    public class NumberGenerator
    {
        // Constructor
        public NumberGenerator()
        {
        }

        // Iterator method
        public IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }
}
