namespace CSharpMiniProjects.MiniQ5
{
    public class NotificationService
    {
        // Event
        public event EventHandler<NotificationEventArgs>?
            OnNotificationSent;

        // Constructor
        public NotificationService()
        {
        }

        public void SendNotification( NotificationSender sender, string recipient, string message)
        {
            // Execute sender
            sender(recipient, message);

            // Create event arguments
            NotificationEventArgs eventArgs = new NotificationEventArgs(recipient,message);

            // Fire event
            OnNotificationSent?.Invoke(this,eventArgs);
        }
    }
}
