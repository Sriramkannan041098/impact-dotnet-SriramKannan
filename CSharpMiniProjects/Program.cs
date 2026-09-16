using CSharpMiniProjects.ExtensionMethods;
using CSharpMiniProjects.MiniQ4;
using CSharpMiniProjects.MiniQ5;
using CSharpMiniProjects.MiniQ6;

Console.WriteLine("Mini Projects on Advance Concepts");

//Task 2.14 - Extension Methods Demostrations
Console.WriteLine("\n\nTask 2.14 - String Extension Methods");
Employee employee = new Employee("Sriram", 60000);

var employeeInfo =  new {
    employee.Name, 
    AnnualSalary = employee.MonthlySalary * 12};

Console.WriteLine($"Name: {employeeInfo.Name}");
Console.WriteLine($"Annual Salary: {employeeInfo.AnnualSalary}");

Console.WriteLine("\nInterger Extension Demostration");
Console.WriteLine(IntegerExtensions.ToWords(89));
Console.WriteLine(IntegerExtensions.ToWords(67));
Console.WriteLine(IntegerExtensions.ToWords(923));
//Console.WriteLine(IntegerExtensions.ToWords(1004)); // Exception Error is thrown



//Task MiniQ4 Employee Payroll System
Console.WriteLine("\n\nMiniQ4 - Employee Payment System");
List<EmployeeStatus> employeestatus =  new List<EmployeeStatus>
{
  new FullTimeEmployee(1, "Arun",   "IT",  70000),
  new FullTimeEmployee(2, "Priya",  "HR",  60000),
  new FullTimeEmployee(5, "Anitha", "IT", 80000),
  new PartTimeEmployee(3, "Rahul",  "IT",  500, 40),
  new ContractEmployee(4, "Vijay",  "Finance", 55000)  
};

// Polymorphism
decimal totalPayroll = 0;
foreach (EmployeeStatus employeeData in employeestatus)
{
    decimal salary = employeeData.CalculateSalary();
    Console.WriteLine( $"{employeeData.Name}: {salary:C}");
    totalPayroll += salary;
}
Console.WriteLine($"\nTotal Payroll: {totalPayroll:C}");

// Tax
Console.WriteLine("\nTax:");
foreach (EmployeeStatus employeeTax in employeestatus)
{
    if (employeeTax is ITaxable taxable)
    {
        Console.WriteLine($"{employeeTax.Name}: " + $"{taxable.CalculateTax():C}");
    }
}

// Group By Department
Console.WriteLine("\nPayroll By Department:");
var departmentGroups = employeestatus.GroupBy(emp =>  emp.Department);

foreach (var group in departmentGroups)
{
    decimal departmentTotal = group.Sum(employee => employee.CalculateSalary());
    Console.WriteLine($"{group.Key}: " + $"{departmentTotal:C}" );
}




//Task MiniQ5 Notification Engine Console Application
Console.WriteLine("\n\nMiniQ5 Notification Engine Console Application\n");
NotificationService service = new NotificationService();
EmailSender emailSender = new EmailSender();
SmsSender smsSender = new SmsSender();
PushSender pushSender = new PushSender();


// Subscribe to event
service.OnNotificationSent +=(sender, e) =>
{ 
   Console.WriteLine($"LOG: Notification sent to " + $"{e.Recipient}\n");
};


// Send Email
service.SendNotification(emailSender.Send, "user@example.com",  "Welcome!");

// Send SMS
service.SendNotification(smsSender.Send,"9876543210", "Your OTP is 1234");

// Send Push
service.SendNotification(pushSender.Send, "User123", "You have a new message");





//Task MiniQ6 Library Management using LINQ
Console.WriteLine("\n\nMiniQ6 Library Management using LINQ");
BookData bookData =  new BookData();

List<Book> books = bookData.GetBooks();


// 1. Available books by author
Console.WriteLine("\n1. Available books by J.R.R. Tolkien:");

var booksByAuthor = books.Where(book =>book.Author == "J.R.R. Tolkien" &&  book.IsAvailable).ToList();

foreach (Book book in booksByAuthor)
{
    Console.WriteLine($"{book.Title} - {book.Year}");
}


// 2. Group by Genre + Count
Console.WriteLine("\n2. Books grouped by genre:");

var booksByGenre = books.GroupBy(book => book.Genre).Select(group => new
{
    Genre = group.Key,
    Count = group.Count()
});

foreach (var group in booksByGenre)
{
    Console.WriteLine($"{group.Genre}: {group.Count}");
}


// 3. Oldest book
Console.WriteLine("\n3. Oldest Book:");

Book oldestBook = books.OrderBy(book => book.Year).First();

Console.WriteLine($"{oldestBook.Title} - {oldestBook.Year}");


// 4. Books after 2010 sorted by title
Console.WriteLine("\n4. Books after 2010:");

var recentBooks = books.Where(book => book.Year > 2010).OrderBy(book => book.Title);

foreach (Book book in recentBooks)
{
    Console.WriteLine($"{book.Title} - {book.Year}");
}
