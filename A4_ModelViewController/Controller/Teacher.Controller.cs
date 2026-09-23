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

            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
                        GetTeacher();
                        break;

                    case "4":
                        UpdateTeacher();
                        break;

                    case "5":
                        DeleteTeacher();
                        break;

                    case "6":
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
                    ? "Teacher added successfully..! ✔️"
                    : "Teacher could not be added..! ❌"
            );
        }

        private void ShowTeachers()
        {
            var teachers = _teacherService.GetAll();

            _teacherView.PrintTeachers(teachers);
        }


        private void GetTeacher()
        {
            Console.WriteLine("Enter Teacher's Id : ");

            int id = int.Parse(Console.ReadLine()!);

            Teacher? teacher = _teacherService.GetById(id);

            if(teacher != null)
            {
                _teacherView.PrintTeachers(new[] { teacher }.ToList());
            }
            else
            {
                Console.WriteLine("Teacher Not Found..!");
            }


        }

        private void UpdateTeacher()
        {
            Teacher teacher = _teacherView.PromptForTeacher();

            bool resultant = _teacherService.UpdateTeacher(teacher);

            _teacherView.ShowMessage( resultant ? "Teacher Updated Successfully..!" : "👎 Updation Failed..!");

        }


        private void DeleteTeacher()
        {
            Console.Write("Enter Tecaher's Id : ");

            int id = int.Parse(Console.ReadLine()!);

            bool resultant = _teacherService.DeleteTeacher(id);

            _teacherView.ShowMessage(resultant ? "Tecaher Deleted Successfully..!" : "👎 Failed to Delete Teacher");

        }
    }
}
