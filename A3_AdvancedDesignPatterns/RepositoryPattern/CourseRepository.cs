using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly List<Course> _courses =
            new List<Course>();

        public List<Course> GetAll()
        {
            return _courses;
        }

        public Course? GetById(int id)
        {
            return _courses.FirstOrDefault(
                course => course.Id == id
            );
        }

        public void Add(Course entity)
        {
            _courses.Add(entity);

            Console.WriteLine(
                $"Course added: {entity.Name}"
            );
        }

        public void Update(Course entity)
        {
            Course? existingCourse =
                GetById(entity.Id);

            if (existingCourse != null)
            {
                existingCourse.Name = entity.Name;

                Console.WriteLine(
                    $"Course updated: {entity.Name}"
                );
            }
        }

        public void Delete(int id)
        {
            Course? course = GetById(id);

            if (course != null)
            {
                _courses.Remove(course);

                Console.WriteLine($"Course deleted: {course.Name}");
            }
        }
    }
}
