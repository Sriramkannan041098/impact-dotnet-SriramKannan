namespace CSharp_GenericCol_LINQ.GenericCollections
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public Product() { }
        public Product( int id, string name,  decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }
}
