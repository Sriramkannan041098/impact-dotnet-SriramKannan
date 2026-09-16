using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_GenericCol_LINQ.BooksManagement
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        // Constructor
        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title} - {Author} ({Year})";
        }
    }
}
