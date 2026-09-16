using CSharpDelegatesAndEvents.CoffeeTime;
using CSharpDelegatesAndEvents.ListOperationss;
using CSharpDelegatesAndEvents.MathOperation;


Console.WriteLine("Delegates and event s Demostration");

//Task 2.8 : Math Operations
Console.WriteLine("\nTask 2.8 Math Operation");
MathOperations mathOperations =   new MathOperations();

// Custom delegate
mathOperations.DemonstrateDelegate();

// Multicast delegate
mathOperations.DemonstrateMulticastDelegate();

// Func delegate
mathOperations.DemonstrateFunc();




//Task 2.9 - Coffee Machine
Console.WriteLine("\n\nTask 2.9 Coffee Time");
AlarmClock alarmClock =   new AlarmClock();

Person person = new Person("Sriram");

CoffeeMachine coffeeMachine = new CoffeeMachine();

// Subscribe Person
alarmClock.OnAlarmRing += person.OnAlarmRing;

// Subscribe CoffeeMachine
alarmClock.OnAlarmRing += coffeeMachine.OnAlarmRing;

// Trigger event
alarmClock.TriggerAlarm();



//Task 2.10 - Action, Func, Predicate & Processing Pipeline
Console.WriteLine("\n\nTask 2.10 Processing the List");
ListProcessor processor =   new ListProcessor();

// Action<string>
Action<string> printUpperCase =  text => Console.WriteLine( text.ToUpper() );
printUpperCase("hello world");


// Func<int,int,int>
Func<int, int, int> multiply = (a, b) => a * b;

Console.WriteLine( $"Multiply: {multiply(5, 10)}");


// Predicate<int>
Predicate<int> isEven =  number => number % 2 == 0;

Console.WriteLine( $"Is 10 even? {isEven(10)}");


// ProcessList
List<int> numbers = new List<int> {1, 2, 3,  4, 5,  6};

Console.WriteLine("\nEven numbers squared:");

processor.ProcessList(numbers,

    // Filter
    number => number % 2 == 0,

    // Transform
    number => number * number,

    // Output
    result => Console.WriteLine(result)
);
    