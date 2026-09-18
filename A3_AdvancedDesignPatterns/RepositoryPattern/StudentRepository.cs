using System;
using System.Collections.Generic;
using System.Linq;


namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly List<Student> _students = new List<Student>();

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(int id)
        {
            return _students.FirstOrDefault( student => student.Id == id );
        }

        public void Add(Student entity)
        {
            _students.Add(entity);

            Console.WriteLine($"Student added: {entity.Name}");
        }

        public void Update(Student entity)
        {
            Student? existingStudent =   GetById(entity.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = entity.Name;

                Console.WriteLine($"Student updated: {entity.Name}");
            }
        }

        public void Delete(int id)
        {
            Student? student = GetById(id);

            if (student != null)
            {
                _students.Remove(student);

                Console.WriteLine($"Student deleted: {student.Name}");
            }
        }
    }
}
