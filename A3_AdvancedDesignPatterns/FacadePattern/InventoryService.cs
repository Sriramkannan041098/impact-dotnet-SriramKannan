using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.FacadePattern
{
    public class InventoryService
    {
        public bool CheckStock(int productId)
        {
            Console.WriteLine( $"Inventory checked for Product {productId}." );

            return true;
        }

        public void ReduceStock(int productId)
        {
            Console.WriteLine( $"Stock reduced for Product {productId}." );
        }
    }
}
