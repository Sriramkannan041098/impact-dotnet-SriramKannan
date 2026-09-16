namespace OOPsConcept2.MethodResMech.MethodHiding
{
    public class FileLogger : Logger
    {
        // Method hiding
        public new void Log()
        {
            Console.WriteLine("FileLogger.Log()");
        }
    }
}
