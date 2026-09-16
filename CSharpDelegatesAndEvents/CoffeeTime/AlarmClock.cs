namespace CSharpDelegatesAndEvents.CoffeeTime
{
    public class AlarmClock
    {
        // Event
        public event EventHandler<AlarmEventArgs>? OnAlarmRing;

        // Constructor
        public AlarmClock()
        {
        }

        // Trigger alarm
        public void TriggerAlarm()
        {
            DateTime alarmTime = DateTime.Now;

            Console.WriteLine(
                "Alarm is ringing..."
            );

            AlarmEventArgs eventArgs =
                new AlarmEventArgs(alarmTime);

            OnAlarmRing?.Invoke(
                this,
                eventArgs
            );
        }
    }
}
