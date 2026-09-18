using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
