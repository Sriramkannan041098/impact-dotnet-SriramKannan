using OOPs.AccountManagement;
using OOPs.Automobiles;
using OOPs.SendNotfications;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Undersdanding OOPs Concept");

        Console.WriteLine("\n\nTask 2.1 - Banking Application");
        BankAccount acc = new BankAccount();
        acc.Deposit(-10);   //Invalid Amount
        acc.Deposit(2000);  //Deposit
        acc.Withdraw(800);  //Withdraw
        acc.Withdraw(8000); //Overdraw attempt
        acc.TransactionHistory();  //Transaction histroy


        Console.WriteLine("\n\nTask 2.2 - Banking Application");
        ElectricCar ev = new ElectricCar("Mahindra", "B6e", 2025, 100, 4);
        ev.DisplayInfo();

        Bike bike = new Bike("Yamaha","FZ150", 2023, 150);
        bike.DisplayInfo();

        Car car = new Car("Tata", "Altroz", 2026, 4);
        car.DisplayInfo();



        Console.WriteLine("\n\nTask 2.3 - Send Nofications through different medium");
        Notification email = new EmailNotification();
        email.Send();
        email.MessageReceive(20);

        Notification sms = new SmsNotification();
        sms.Send();
        sms.MessageReceive(321);

        Notification push = new PushNotification();       
        push.Send();
        push.MessageReceive(269);

        Notification notify = new Notification();
        Console.WriteLine("Initiating Base Class Directly for testing purpose from Program.cs file:");
        notify.Send();
        notify.MessageReceive(0);
    }
}