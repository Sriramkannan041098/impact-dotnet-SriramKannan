using SchoolManagement;


class Program
{
    public static void Main(string[] args)
    {
        string appName = "School Management Console";
        Console.WriteLine($"Welcome to the {appName} App.");

        // Invoking Student class from SchoolManagement without utilizing "using" directive
        SchoolManagement.Students students2 = new SchoolManagement.Students("Sriram Kannan", "PS001");
        students2.DisplayStudentInfo();

        // Invoking Student class from SchoolManagement by utilizing "using" directive
        Students students = new Students("Ronnie Prince", "PS002");
        students.DisplayStudentInfo();
        students.NamingConvensions();


        Console.WriteLine("\nDemonstrating the use of namespaces and resolving naming conflicts:");
         ModuleA.Helper.Greet();
         ModuleB.Helper.Greet();
    }
}
