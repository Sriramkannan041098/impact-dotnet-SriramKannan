using System.Text.Json;
using System.Xml.Linq;

namespace A3_AdvancedDesignPatterns.AdapterPattern
{
    public class XmlReportAdapter : IReportGenerator
    {
        private readonly ThirdPartyXmlReportGenerator _thirdPartyGenerator;

        public XmlReportAdapter(ThirdPartyXmlReportGenerator thirdPartyGenerator)
        {
            _thirdPartyGenerator = thirdPartyGenerator;
        }

        public void GenerateReport(string jsonData)
        {
            using JsonDocument document = JsonDocument.Parse(jsonData);

            JsonElement root = document.RootElement;

            string name = root.GetProperty("name").GetString()!;
            decimal total = root.GetProperty("total").GetDecimal();

            XElement xml = new XElement(
              "Report",
                new XElement("Name", name),
                new XElement("Total", total)
            );

            _thirdPartyGenerator.GenerateXmlReport(xml.ToString());
        }
    }
}
