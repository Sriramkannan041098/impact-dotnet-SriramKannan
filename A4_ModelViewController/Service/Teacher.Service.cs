using A4_ModelViewController.IRepository;
using A4_ModelViewController.IService;
using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(
            IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public bool AddTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.TeacherName))
            {
                return false;
            }

            _repository.Add(teacher);

            return true;
        }

        public List<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Teacher? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            Teacher? existingTeacher =  _repository.GetById(teacher.Id);

            if (existingTeacher == null)
            {
                return false;
            }

            _repository.Update(teacher);

            return true;
        }

        public bool DeleteTeacher(int id)
        {
            Teacher? teacher =
                _repository.GetById(id);

            if (teacher == null)
            {
                return false;
            }

            _repository.Delete(id);

            return true;
        }
    }
}
