namespace A3_AdvancedDesignPatterns.AdapterPattern
{
    public class ThirdPartyXmlReportGenerator
    {
        public void GenerateXmlReport(string xmlData)
        {
            Console.WriteLine(
                "Third-party XML report generated:"
            );

            Console.WriteLine(xmlData);
        }
    }
}
