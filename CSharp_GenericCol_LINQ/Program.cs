using CSharp_GenericCol_LINQ.BooksManagement;
using CSharp_GenericCol_LINQ.GenericCollections;
using CSharp_GenericCol_LINQ.LINQ;

Console.WriteLine("Understanding Generic Collections and LINQ Syntax");


//Task 2.11 -  Generic Collection Demostration
Console.WriteLine("\n\nTask 2.11 - Generic Collection Demostration");
Repository<Student> studentRepository =   new Repository<Student>();

studentRepository.Add(new Student(1, "Sriram", 27));
studentRepository.Add(new Student(2, "Ronnie", 24));

Console.WriteLine("Students:");

foreach (Student student in studentRepository.GetAll())
{
    Console.WriteLine(student);
}


Repository<Product> productRepository =   new Repository<Product>();

productRepository.Add(new Product(101, "Ear Pods",  5489));
productRepository.Add(new Product(102, "Keyboard", 1579));

Console.WriteLine("\nProducts:");

foreach (Product product in productRepository.GetAll())
{
    Console.WriteLine(product);
}



//Task 2.12 -  Understanding IEnumable
Console.WriteLine("\n\nTask 2.12 - IEnumable Demostration");

// Even Number Iterator
NumberGenerator generator =  new NumberGenerator();

Console.WriteLine("Even Numbers:");

foreach (int number in generator.GetEvenNumbers(10))
{
    Console.WriteLine(number);
}


// Book Collection
BookCollection books = new BookCollection();

books.Add(
    new Book("Clean Code", "Robert C. Martin", 2008)
);

books.Add(
    new Book("Design Patterns", "Erich Gamma", 1994)
);

books.Add(
    new Book("C# in Depth", "Jon Skeet", 2019)
);

Console.WriteLine("\nBooks in alphabetical order:");

foreach (Book book in books)
{
    Console.WriteLine(book);
}


//Task 2.13 -  Understanding IEnumable
Console.WriteLine("\n\nTask 2.13 - LINQ Demostration");
EmployeeData employeeData =  new EmployeeData();

List<Employee> employees =  employeeData.GetEmployees();


// 1. FILTER: Salary > 50000
Console.WriteLine("\n1. Salary > 50000");

// Query syntax
var highSalaryQuery =  from employee in employees  where employee.Salary > 50000   select employee;

// Method syntax
var highSalaryMethod = employees.Where(employee => employee.Salary > 50000);


foreach (Employee employee in highSalaryQuery)
{
    Console.WriteLine($"{employee.Name} - {employee.Salary}");
}


// 2. ORDER BY SALARY DESCENDING
Console.WriteLine("\n2. Salary Descending");

// Query syntax
var salaryQuery = from employee in employees orderby employee.Salary descending  select employee;

// Method syntax
var salaryMethod = employees.OrderByDescending(employee =>  employee.Salary);


foreach (Employee employee in salaryQuery)
{
    Console.WriteLine($"{employee.Name} - {employee.Salary}");
}


// 3. GROUP BY DEPARTMENT
Console.WriteLine("\n3. Group By Department");

// Query syntax
var departmentQuery = from employee in employees  group employee by employee.Department into departmentGroup
    select new
    {
        Department = departmentGroup.Key,
        Count = departmentGroup.Count(),
        AverageSalary =
            departmentGroup.Average(
                employee => employee.Salary)
    };

// Method syntax
var departmentMethod =
    employees
        .GroupBy(employee =>
            employee.Department)
        .Select(departmentGroup => new
        {
            Department =
                departmentGroup.Key,

            Count =
                departmentGroup.Count(),

            AverageSalary =
                departmentGroup.Average(
                    employee =>
                        employee.Salary)
        });


foreach (var department in departmentQuery)
{
    Console.WriteLine(
        $"{department.Department} - " +
        $"Count: {department.Count}, " +
        $"Average Salary: " +
        $"{department.AverageSalary:F2}"
    );
}


// 4. PROJECTION: Name + Experience
Console.WriteLine("\n4. Employee Experience");

// Query syntax
var experienceQuery = from employee in employees
    select new
    {
        employee.Name,

        Experience =
            DateTime.Now.Year -
            employee.JoiningDate.Year
    };

// Method syntax
var experienceMethod = employees
        .Select(employee => new
        {
            employee.Name,

            Experience =
                DateTime.Now.Year -
                employee.JoiningDate.Year
        });


foreach (var employee in experienceQuery)
{
    Console.WriteLine(
        $"{employee.Name} - " +
        $"Experience: " +
        $"{employee.Experience} years"
    );
}