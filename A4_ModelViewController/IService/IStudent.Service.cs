using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.IService
{
    public interface IStudentService
    {
        bool AddStudent(Student student);

        List<Student> GetAll();

        Student? GetById(int id);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);
    }
}
