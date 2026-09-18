using A4_ModelViewController.IService;
using A4_ModelViewController.Model;
using A4_ModelViewController.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Controller
{
    public class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly StudentView _studentView;


        public StudentController(IStudentService studentService, StudentView studentView)
        {
            _studentService = studentService;
            _studentView = studentView;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                _studentView.ShowMenu();

                string choice =  Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ShowStudents();
                        break;

                    case "3":
                        GetStudent();
                        break;

                    case "4":
                        UpdateStudent();
                        break;

                    case "5":
                        DeleteStudent();
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        _studentView.ShowMessage(
                            "Invalid choice."
                        );
                        break;
                }
            }
        }

        private void AddStudent()
        {
            Student student = _studentView.PromptForStudent();

            bool result =  _studentService.AddStudent(student);

            if (result)
            {
                _studentView.ShowMessage( "Student added successfully." );
            }
            else
            {
                _studentView.ShowMessage("Failed to add student." );
            }
        }

        private void ShowStudents()
        {
            var students = _studentService.GetAll();

            _studentView.PrintStudents(students);
        }

        private void GetStudent()
        {
            Console.Write("Enter Student Id: ");

            int id = int.Parse(Console.ReadLine()!);

            Student? student = _studentService.GetById(id);

            if (student != null)
            {
                _studentView.PrintStudents( new[] { student }.ToList() );
            }
            else
            {
                _studentView.ShowMessage( "Student not found." );
            }
        }

        private void UpdateStudent()
        {
            Student student = _studentView.PromptForStudent();

            bool result = _studentService.UpdateStudent(student);

            _studentView.ShowMessage(
                result
                    ? "Student updated successfully."
                    : "Student update failed."
            );
        }

        private void DeleteStudent()
        {
            Console.Write("Enter Student Id: ");

            int id = int.Parse(Console.ReadLine()!);

            bool result = _studentService.DeleteStudent(id);

            _studentView.ShowMessage(
                result
                    ? "Student deleted successfully."
                    : "Student deletion failed."
            );
        }
    }
}
