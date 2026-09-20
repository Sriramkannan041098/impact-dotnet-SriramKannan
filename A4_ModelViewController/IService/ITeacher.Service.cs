using A4_ModelViewController.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.IService
{
    public interface ITeacherService
    {
        bool AddTeacher(Teacher teacher);

        List<Teacher> GetAll();

        Teacher? GetById(int id);

        bool UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(int id);
    }
}
