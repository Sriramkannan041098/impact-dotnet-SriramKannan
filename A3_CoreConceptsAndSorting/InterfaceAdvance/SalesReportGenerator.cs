using System;
using System.Collections.Generic;
using System.Text;

namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    public class SalesReportGenerator : ReportGenerator
    {
        public SalesReportGenerator(string reportName)
            : base(reportName)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine(
                "Sales report generated."
            );
        }
    }
}
