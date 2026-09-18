using A4_ModelViewController.IRepository;
using A4_ModelViewController.IService;
using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public bool AddStudent(Student student)
        {
            // Business rule 1: Name cannot be empty.
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                return false;
            }

            // Business rule 2:
            // Student.Age property already validates 5-100.
            if (student.Age < 5 || student.Age > 100)
            {
                return false;
            }

            // Business rule 3:
            // Roll number must be unique.
            bool duplicateRollNumber =
                _repository
                    .GetAll()
                    .Any(s => s.RollNumber.Equals(
                            student.RollNumber,
                            StringComparison.OrdinalIgnoreCase
                        )
                    );

            if (duplicateRollNumber)
            {
                return false;
            }

            _repository.Add(student);

            return true;
        }

        public List<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Student? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool UpdateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                return false;
            }

            if (student.Age < 5 || student.Age > 100)
            {
                return false;
            }

            Student? existingStudent = _repository.GetById(student.Id);

            if (existingStudent == null)
            {
                return false;
            }

            _repository.Update(student);

            return true;
        }

        public bool DeleteStudent(int id)
        {
            Student? student = _repository.GetById(id);

            if (student == null)
            {
                return false;
            }

            _repository.Delete(id);

            return true;
        }
    }
}
