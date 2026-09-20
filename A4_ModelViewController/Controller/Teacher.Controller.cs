using A4_ModelViewController.IService;
using A4_ModelViewController.Model;
using A4_ModelViewController.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Controller
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;
        private readonly TeacherView _teacherView;



        public TeacherController( ITeacherService teacherService, TeacherView teacherView)
        {
            _teacherService = teacherService;
            _teacherView = teacherView;
        }



        public void Run()
        {
            bool running = true;

            while (running)
            {
                _teacherView.ShowMenu();

                string choice =  Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        AddTeacher();
                        break;

                    case "2":
                        ShowTeachers();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        _teacherView.ShowMessage(
                            "Invalid choice."
                        );
                        break;
                }
            }
        }

        private void AddTeacher()
        {
            Teacher teacher = _teacherView.PromptForTeacher();

            bool result = _teacherService.AddTeacher(teacher);

            _teacherView.ShowMessage(
                result
                    ? "Teacher added successfully."
                    : "Teacher could not be added."
            );
        }

        private void ShowTeachers()
        {
            var teachers = _teacherService.GetAll();

            _teacherView.PrintTeachers(teachers);
        }
    }
}
