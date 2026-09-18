using A3_AdvancedDesignPatterns.AdapterPattern;
using A3_AdvancedDesignPatterns.FacadePattern;
using A3_AdvancedDesignPatterns.RepositoryPattern;
using A3_AdvancedDesignPatterns.Strategy;

Console.WriteLine("Advance Design Patterns");

//Task 3.7 - Startegy
Console.WriteLine("\n\nTask 3.7 - Strategy Pattern Demonstrartion");
// Initial strategy
Console.WriteLine("Shopping with Credit Card");
ShoppingCart cart = new ShoppingCart(4);
cart.SetPaymentStrategy(new CreditCardPayment());
cart.Checkout(2500);

// Switch strategy at runtime
Console.WriteLine("\nShopping with UPI Payment");
cart.SetPaymentStrategy( new UpiPayment());
cart.Checkout(1500);

// Switch strategy again
Console.WriteLine("\nShopping with Netbanking");
cart.SetPaymentStrategy(new NetBankingPayment());
cart.Checkout(3000);



//Task 3.8 Repository + Unit of Work
Console.WriteLine("\n\nTask 3.8 - Repository Pattern Demonstrartion");
// Create repositories
IRepository<Student> studentRepository =  new StudentRepository();
IRepository<Course> courseRepository =  new CourseRepository();

// Create UnitOfWork
IUnitOfWork unitOfWork = new UnitOfWork( studentRepository,courseRepository);

// Add Students
unitOfWork.Students.Add(new Student(1, "Arun"));

unitOfWork.Students.Add(new Student(2, "Suresh"));

unitOfWork.Students.Add(new Student(3, "Priyanka"));

Console.WriteLine();

// Add Courses
unitOfWork.Courses.Add(new Course(1, "C#"));

unitOfWork.Courses.Add(new Course(2, "ASP.NET Core"));

// Get Student
Student? student = unitOfWork.Students.GetById(1);

if (student != null)
{
    Console.WriteLine( $"\nStudent Found: {student.Name}");
}

// Update Student
unitOfWork.Students.Update(new Student(1, "Arun Kumar"));

// Delete Course
Console.WriteLine();
unitOfWork.Courses.Delete(2);
unitOfWork.Students.Delete(3);


// Save
unitOfWork.Save();



//Task 3.9 - Adapter and Facade Patterns
Console.WriteLine("\n\nTask 3.9 Part - 1 Adapter Pattern");

string jsonReport =
    """
            {
                "name": "Monthly Sales",
                "total": 50000
            }
            """;

ThirdPartyXmlReportGenerator thirdPartyGenerator =  new ThirdPartyXmlReportGenerator();

IReportGenerator reportAdapter = new XmlReportAdapter(thirdPartyGenerator );

// Application gives JSON.
// Adapter converts JSON to XML.
// Third-party system receives XML.
reportAdapter.GenerateReport(jsonReport);



Console.WriteLine("\n\nTask 3.9 Part - 2  Facade Pattern");

InventoryService inventory = new InventoryService();
PaymentService payment = new PaymentService();
ShippingService shipping =  new ShippingService();

OrderFacade orderFacade =new OrderFacade(
  inventory,
  payment,
  shipping
);

// One method coordinates all subsystems.
orderFacade.PlaceOrder(productId: 101,amount: 2500);