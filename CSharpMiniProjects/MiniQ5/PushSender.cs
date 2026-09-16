namespace CSharpMiniProjects.MiniQ5
{
    public class PushSender
    {
        // Constructor
        public PushSender()
        {
        }

        public void Send(string recipient, string message)
        {
            Console.WriteLine(
                $"Push notification sent to " +
                $"{recipient}: {message}"
            );
        }
    }
}
