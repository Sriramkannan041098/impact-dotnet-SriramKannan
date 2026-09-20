using A3_ExceptionsDisposalAsync.Asynchronous;
using A3_ExceptionsDisposalAsync.Disposal;
using A3_ExceptionsDisposalAsync.ExceptionalHandling;
using System.Diagnostics;


Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Exceptional handling, Disposal and Asynchronous");


//Task 3.1 - Custom and Default Exceptional Handling
Console.WriteLine("\n\nTask 3.1 - demostratiion of both Custom and Default Exceptional Handling");
Console.WriteLine("\n           🏦 Account management Console App:\n");
BankAccount account = new BankAccount(5000);
account.Withdraw(200);

Console.WriteLine();
account.Withdraw(7000);
Console.WriteLine(account.CreditedAmount(5200));  //Credited Amount and balance after new credit
Console.WriteLine(account.CurrentBalanceStatus());
account.ParseAmount("");
//account.ParseAmount("1234567890987654345654356765432456789876543467898765433568909654321322345678");

// This causes InsufficientFundsException
//Console.WriteLine();
//account.Withdraw(4800); 



//Task 3.2 - Disposal
Console.WriteLine("\n\nTask 3.2 - Creational and Disposal of a file");
string filePath;

using (TempFileManager manager =   new TempFileManager())
{
    filePath = manager.FilePath;

    Console.WriteLine($"Inside using: {File.Exists(filePath)}\n");
}

Console.WriteLine($"Outside using: {File.Exists(filePath)}\n");



//Task 3.3 - Asynchronous
Console.WriteLine("\n\nTask 3.3 - Asynchronous Operation");
UserService service =   new UserService();

// Sequential
Console.WriteLine("\n--- Sequential ---");

Stopwatch sequentialWatch = Stopwatch.StartNew();    // stop watch timer - starts
string user1 = await service.FetchUserDataAsync(1);
Console.WriteLine(user1);
string user2 = await service.FetchUserDataAsync(2);  // here each task starts and waits until it finish
Console.WriteLine(user2);
string user3 = await service.FetchUserDataAsync(3);
Console.WriteLine(user3);

sequentialWatch.Stop();                              // stop watch timer - ends
Console.WriteLine($"Sequential Time: {sequentialWatch.ElapsedMilliseconds} ms");


// Concurrent
Console.WriteLine("\n--- Concurrent ---");

Stopwatch concurrentWatch = Stopwatch.StartNew();
Task<string> task1 = service.FetchUserDataAsync(1);
Task<string> task2 = service.FetchUserDataAsync(2);
Task<string> task3 = service.FetchUserDataAsync(3);
//Task<string> task4 = service.FetchUserDataAsync(4);
//Task<string> task5 = service.FetchUserDataAsync(5);
// The main use case of storing a Task is to start work now and wait for it later.


// here all task are initiated togerther and waits later
string[] newUser1 = await Task.WhenAll(task1, task2, task3);
//await Task.Delay(3000);
//string[] newUser2 = await Task.WhenAll(task4, task5);
concurrentWatch.Stop();
Console.WriteLine($"Concurrent Time: {concurrentWatch.ElapsedMilliseconds} ms");
