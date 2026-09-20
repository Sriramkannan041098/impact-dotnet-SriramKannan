using A3_DesignPatterns.FactoryPattern;
using A3_DesignPatterns.SingletonPattern;
using A3_DesignPatterns.StockTickerObserver;

Console.WriteLine("Design Pattern");


//Task 3.4 - Singleton Pattern
Console.WriteLine("\n\nTask 3.4 - Singleton Pattern");
LoggerHandler.HandlerMethod();

Logger logging = new Logger();
//logging.Testing();





//Task 3.5 - Factory Method
Console.WriteLine("\n\nTask 3.5 - Factory Method");

//Simple Factory
Console.WriteLine("Simple Factory:");

IVehicle car = VehicleFactory.InduceVehicle("car");
car.Drive();

IVehicle bike = VehicleFactory.InduceVehicle("bike");
bike.Drive();

IVehicle truck = VehicleFactory.InduceVehicle("Truck");
truck.Drive();
//Simple Factory - A single class creates objects and 


//Factory Method
Console.WriteLine("\nFactory Method:");

VehicleFactoryMethod carFactory = new CarFactory();
carFactory.StartVehicle();

VehicleFactoryMethod bikeFactory = new BikeFactory();
bikeFactory.StartVehicle();
//Factory method - Defines an interface/abstract method for object creation.





//Task 3.6 - Observer
Console.WriteLine("\n\nTask 3.6 - Observer");


// Part A - Custom IObserver
Console.WriteLine("Custom IObserver Implementation:");

StockTicker stockTicker = new StockTicker();

Investor investor1 = new Investor("Sriram");
Investor investor2 = new Investor("Kannan");
Investor investor3 = new Investor("Rajeshvari");

stockTicker.Subscribe(investor1);
stockTicker.Subscribe(investor2);
stockTicker.Subscribe(investor3);

stockTicker.ChangePrice("Psiog Digital", 3800);

// Part B - C# Events
Console.WriteLine("\nC# Event Implementation:");

EventBasedStockTicker eventStockTicker = new EventBasedStockTicker();

eventStockTicker.PriceChanged += (sender, args) =>
{
   Console.WriteLine($"{args.InvestorName} received update: {args.StockName} = {(args.Price):C}\n");
};

eventStockTicker.ChangePrice("Sriram","Psiog Digital", 3850);
eventStockTicker.ChangePrice("Kannan", "Psiog Digital", 3850);
eventStockTicker.ChangePrice("Rajeshvari", "Psiog Digital", 3850);


/* Observer Pattern
 * The Observer Pattern is a design pattern where one object (Subject) 
 * automatically notifies multiple dependent objects (Observers) 
 * whenever its state changes.
 *                        (OR)
 * When observers subscribe to a subject, they are 
 * automatically notified whenever the subject's state changes.
 * This Design Pattern is called Observer Pattern
 */




