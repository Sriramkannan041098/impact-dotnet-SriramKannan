namespace CSharpDelegatesAndEvents.CoffeeTime
{
    public class CoffeeMachine
    {
        // Constructor
        public CoffeeMachine()
        {
        }

        // Event handler
        public void OnAlarmRing(
            object? sender,
            AlarmEventArgs e)
        {
            Console.WriteLine(
                $"Coffee machine started at " +
                $"{e.AlarmTime:HH:mm:ss}"
            );
        }
    }
}
