namespace CSharpMiniProjects.MiniQ5
{
    public class NotificationEventArgs : EventArgs
    {
        public string Recipient { get; }

        public string Message { get; }

        // Constructor
        public NotificationEventArgs(string recipient, string message)
        {
            Recipient = recipient;
            Message = message;
        }
    }



}
