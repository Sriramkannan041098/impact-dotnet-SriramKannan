namespace OOPs.SendNotfications
{
    public class PushNotification : Notification
    {
        // Override
        public override void Send()
        {
            Console.WriteLine("Sending Push notification...");
        }

        public sealed override void MessageReceive(int count)
        {
            base.MessageReceive(count);
        }

        /*
        * A override method in C# is a method derived class
        * can provide their own implementation and even grandChild class can also inherite this method
        * 
        * but sealed override methods cannot be inheritated by the grandChild Class
        */
    }
}
