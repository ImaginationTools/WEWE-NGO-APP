using System.Xml.Linq;
using WEWE.Maui.Models;
using System.Collections.Generic;

namespace WEWE.Maui.Services
{
    public class OdkXmlService
    {
        public XDocument ExportWidowsToXml(List<WidowRegistration> widows)
        {
            var root = new XElement("Widows");


            foreach (var w in widows)
            {
                root.Add(new XElement("Widow",
                    new XElement("WidowID", w.WidowID),
                    new XElement("FullName", w.FullName),
                    new XElement("NationalID", w.NationalID),
                    new XElement("PhoneNumber", w.PhoneNumber),
                    new XElement("DOB", w.DOB),
                    new XElement("DependentsCount", w.DependentsCount),
                    new XElement("MonthlyIncome", w.MonthlyIncome),
                    new XElement("HasDisability", w.HasDisability),
                    new XElement("HousingStatus", w.HousingStatus),
                    new XElement("VulnerabilityTier", w.VulnerabilityTier),
                    new XElement("LGA", w.LGA),
                    new XElement("State", w.State),
                    new XElement("Latitude", w.Latitude),
                    new XElement("Longitude", w.Longitude),
                    new XElement("CreatedAt", w.CreatedAt),
                    new XElement("UpdatedAt", w.UpdatedAt)
                ));
            }
            return new XDocument(root);
        }
    }
}