namespace CSharpMiniProjects.MiniQ6
{
    public class BookData
    {
        // Constructor
        public BookData()
        {
        }

        public List<Book> GetBooks()
        {
            return new List<Book>
            {
               new Book("Clean Code", "Robert C. Martin", "Programming", 2008, true),
               new Book("The Pragmatic Programmer", "Andrew Hunt", "Programming", 1999, true),
               new Book("Design Patterns", "Erich Gamma", "Programming", 1994, false),
               new Book("C# in Depth", "Jon Skeet", "Programming", 2019, true),
               new Book("Domain-Driven Design", "Eric Evans", "Programming", 2003, true),
               new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy", 1937, false),
               new Book("The Fellowship of the Ring", "J.R.R. Tolkien", "Fantasy", 1954, true),
               new Book("The Two Towers", "J.R.R. Tolkien", "Fantasy", 1954, true),             
               new Book( "The Alchemist", "Paulo Coelho", "Fiction",  1988, true),
               new Book( "Atomic Habits", "James Clear", "Self Help", 2018, true),
               new Book( "The Psychology of Money", "Morgan Housel", "Finance", 2020, true)
            };
        }
    }
}
