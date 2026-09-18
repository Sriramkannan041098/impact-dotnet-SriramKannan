#define TRIAL_VERSION 
// This Preprocessor directive make the complier to include/ exclude the code at compile time based on the condition.


using SchoolManagementApp.Region;

using SchoolManagement;

class Program
{
    public static void Main(string[] args)
    {
        string appName = "School Management Console";
        Console.WriteLine($"Welcome to the {appName} App.");

        // Task 1.5: 
        // Invoking Student class from SchoolManagement without utilizing "using" directive
        Console.WriteLine("\n\nTask 1.5: Invoke Student Class with and without 'using' directive in Program.cs");
        SchoolManagement.Students students2 = new SchoolManagement.Students("Sriram Kannan", "PS001");
        students2.DisplayStudentInfo();

        // Invoking Student class from SchoolManagement by utilizing "using" directive
        Students students = new Students("Ronnie Prince", "PS002");
        students.DisplayStudentInfo();

        // Task 1.6: Resolving naming conflicts by using fully qualified names
        Console.WriteLine("\n\nTask 1.6: Resolve Naming Conflicts:");
        ModuleA.Helper.studentName = "Sanjana";
        ModuleA.Helper.Greet();

        //ModuleB.Helper.Greet();

        //Task 1.7: Demonstrating naming conventions
        Console.WriteLine("\n\nTask 1.7: Demonstrate Naming Conventions and handling Reserved Keywords:");
        students.NamingConvensions();


        //Task 1.8: Demonstrating preprocessor directives
        Console.WriteLine("\n\nTask 1.8: Demonstrate Preprocessor Directives:");
        Program trailProgram = new Program();
        trailProgram.TrailTask();
        RegionClass regionClass = new RegionClass("Sriram Kannan", 678);  // "Sriram Kannan", 678
        regionClass.DisplayRegionInfo();
        //RegionClass regionClass2 = new RegionClass();  // "Sriram Kannan", 678
        //regionClass2.DisplayRegionInfo();
    }


    public void TrailTask()
    {
        try
        {
#if !TRIAL_VERSION
              Console.WriteLine("Running Trial Version");
#else
            Console.WriteLine("Running Full Version");
#endif
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
