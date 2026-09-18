using A4_ModelViewController.Controller;
using A4_ModelViewController.IRepository;
using A4_ModelViewController.IService;
using A4_ModelViewController.Model;
using A4_ModelViewController.Repository;
using A4_ModelViewController.Service;
using A4_ModelViewController.View;
using Microsoft.Extensions.DependencyInjection;   //Need to install from Nuget packages



Console.WriteLine("Model View Controller - Archetectural Pattern ");


// Manual Dependency Injection
//IRepository<Student> repository = new MemoryRepository<Student>();

//IStudentService service = new StudentService(repository);

//StudentView view = new StudentView();

//StudentController controller = new StudentController(service, view);


//service.AddStudent(
//    new Student(
//        1,
//        "Arun",
//        20,
//        "ST001",
//        "arun@gmail.com"
//    )
//);

//service.AddStudent(
//    new Student(
//        2,
//        "Priya",
//        21,
//        "ST002",
//        "priya@gmail.com"
//    )
//);

//service.AddStudent(
//    new Student(
//        3,
//        "Rahul",
//        22,
//        "ST003",
//        "rahul@gmail.com"
//    )
//);

//controller.Run();




// Register dependencies
ServiceCollection services = new ServiceCollection();

// Singleton:
// One repository instance is shared for the
// lifetime of this console application.
services.AddSingleton<IRepository<Student>, MemoryRepository<Student>>();
services.AddSingleton<IRepository<Teacher>, MemoryRepository<Teacher>>();

// Transient:
// A new service instance is created whenever
// IStudentService is requested.
services.AddTransient< IStudentService, StudentService>();
services.AddTransient< ITeacherService, TeacherService>();

services.AddTransient<StudentController>();
services.AddTransient <TeacherController>();

// View
services.AddTransient<StudentView>();
services.AddTransient<TeacherView>();

// Build Container
ServiceProvider provider = services.BuildServiceProvider();

// Resolve Services
IStudentService service = provider.GetRequiredService<IStudentService>();
ITeacherService service2 = provider.GetRequiredService<ITeacherService>();


service.AddStudent(
    new Student(
        1,
        "Arun",
        20,
        "ST001",
        "arun@gmail.com"
    )
);

service.AddStudent(
    new Student(
        2,
        "Priya",
        21,
        "ST002",
        "priya@gmail.com"
    )
);

service.AddStudent(
    new Student(
        3,
        "Rahul",
        22,
        "ST003",
        "rahul@gmail.com"
    )
);


service2.AddTeacher(
    new Teacher(
       1, "Seetha", "Assist. Professor", "seetha.k@lms.com"         
    )
);
service2.AddTeacher(
    new Teacher(
       2, "Lakshmi", "Sr. Professor", "lakshmi.j@lms.com"
    )
);
service2.AddTeacher(
    new Teacher(
       3, "Lakshman", "Phd. Professor", "lakshman.lk@lms.com"
    )
);


// Run application
Console.WriteLine("\n\n                     Student and Teacher Management System");
Console.WriteLine("\nMain Menu:");
Console.WriteLine("1 Student");
Console.WriteLine("2 Teacher");

Console.Write("Enter your choice   : ");
int menuID = int.Parse(Console.ReadLine()!);


if (menuID == 1)
{
    StudentController controller = provider.GetRequiredService<StudentController>();
    controller.Run();
}
else if (menuID == 2)
{
    TeacherController controller2 = provider.GetRequiredService<TeacherController>();
    controller2.Run();
}
else
{
    Console.WriteLine("Try Again...");
    Console.Write("Enter your choice   : ");
    menuID = int.Parse(Console.ReadLine()!);
}
//((menuID == 1 ) ? (services.AddTransient<StudentView>()) : (services.AddTransient<TeacherView>())); 