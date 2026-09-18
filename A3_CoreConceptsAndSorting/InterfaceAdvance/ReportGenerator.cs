namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    using System;

    public abstract class ReportGenerator
    {
        // Abstract class can contain state.
        protected string ReportName;

        // Abstract class can have a constructor.
        protected ReportGenerator(string reportName)
        {
            ReportName = reportName;
        }

        // Derived classes must implement this method.
        public abstract void GenerateReport();

        // Abstract class can also contain implemented methods.
        public void DisplayReportName()
        {
            Console.WriteLine(
                $"Report: {ReportName}"
            );
        }
    }
}
