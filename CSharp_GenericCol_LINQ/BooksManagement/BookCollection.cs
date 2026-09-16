using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharp_GenericCol_LINQ.BooksManagement
{
    public class BookCollection : IEnumerable<Book>
    {
        private List<Book> books;

        // Constructor
        public BookCollection()
        {
            books = new List<Book>();
        }

        // Add book
        public void Add(Book book)
        {
            books.Add(book);
        }

        // Iterator
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in books
                .OrderBy(book => book.Title))
            {
                yield return book;
            }
        }

        // Non-generic IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
