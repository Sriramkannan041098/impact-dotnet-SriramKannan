using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.MiniQ1
{
    public class ProductCatalogDemo
    {
        public ProductCatalogDemo()
        {            
            DisplayProductInfo();
        }
        public void DisplayProductInfo()
        {
            try
            {
                Product[] item = { 
                   new Product("Laptop", 60000, ProductCategory.Electronics),
                   new Product("How to be Perfect", 1200, ProductCategory.Books),
                   new Product("Shirt", 1500, ProductCategory.Clothing),

                   new Product("Mouse", 550, ProductCategory.Electronics),
                   new Product("Art of Living", 1500, ProductCategory.Books),
                   new Product("Jeans Pant", 999, ProductCategory.Clothing),

                   new Product("Keyboard", 1200, ProductCategory.Electronics),
                   new Product("Power of Manifestation", 825, ProductCategory.Books),
                   new Product("Formal Suit", 20000, ProductCategory.Clothing),
                };


                var groupItems = item.GroupBy(p => p.Category);
                Console.WriteLine($"Product Catalog Grouped by Category:\n " +
                    $"{string.Join("\n", groupItems.Select(g => $"{g.Key}: {string.Join(", ", g.Select(p => p.Name))}"))}");

                foreach (var group in groupItems)
                {
                    Console.WriteLine($"\nCategory: {group.Key}");

                    foreach (Product prod in group)
                    {
                        Console.WriteLine($"Product Name: {prod.Name}, Price: {prod.Price}");
                    }
                    //Console.WriteLine("  ");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
