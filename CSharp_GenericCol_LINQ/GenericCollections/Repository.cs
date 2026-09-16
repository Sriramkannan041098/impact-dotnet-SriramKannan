using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharp_GenericCol_LINQ.GenericCollections
{
    public class Repository<T>
    where T : class, new()
    {
        private List<T> items;

        // Constructor
        public Repository()
        {
            items = new List<T>();
        }

        // Add
        public void Add(T item)
        {
            items.Add(item);
        }

        // Update
        public void Update(
            int index,
            T item)
        {
            if (index < 0 || index >= items.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            items[index] = item;
        }

        // Delete
        public void Delete(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            items.RemoveAt(index);
        }

        // Get all
        public List<T> GetAll()
        {
            return items;
        }
    }
}
