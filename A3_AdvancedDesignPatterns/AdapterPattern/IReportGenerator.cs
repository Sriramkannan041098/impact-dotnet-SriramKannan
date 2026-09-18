using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.AdapterPattern
{
    public interface IReportGenerator
    {
        void GenerateReport(string xmlData);
    }
}
