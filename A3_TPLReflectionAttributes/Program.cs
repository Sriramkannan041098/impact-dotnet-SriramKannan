using A3_TPLReflectionAttributes.Attributes;
using A3_TPLReflectionAttributes.Reflection;
using A3_TPLReflectionAttributes.TaskParallelLibrary;

Console.WriteLine("TPL, Reflection and Attributes");


Console.WriteLine("\n\nTask 3.10 - Task Parallel Library Demostrartion");
PerformanceHandler perform = new PerformanceHandler();


Console.WriteLine("\n\nTask 3.11 - Reflection Demostartion");
InvoiceHandler invoice = new InvoiceHandler();


Console.WriteLine("\n\nTask 3.12 - Custom Attribute Validator");

User user =new User(
   1,
   "Joseph Sriram AliKhan"
);
UserValidator validator = new UserValidator();

validator.Validate(user);