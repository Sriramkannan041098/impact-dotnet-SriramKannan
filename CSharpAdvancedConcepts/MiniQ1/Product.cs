namespace CSharpAdvancedConcepts.MiniQ1
{
    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }



        public Product(string name, decimal price, ProductCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

    }
}
