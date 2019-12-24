using System.Xml.Serialization;

namespace CurrencyProvider.Entity
{
    public class CurrencyEntity
    {
        [XmlAttribute("CrossOrder")]
        public string CrossOrder { get; set; }

        [XmlAttribute("Kod")]
        public string Kod { get; set; }



        [XmlElement(ElementName = "Unit")]
        public string Unit { get; set; }

        [XmlAttribute("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlElement(ElementName = "CurrencyName")]
        public string CurrencyName { get; set; }



        [XmlElement(ElementName = "ForexBuying")]
        public string ForexBuying { get; set; }

        [XmlElement(ElementName = "ForexSelling")]
        public string ForexSelling { get; set; }



        [XmlElement(ElementName = "BanknoteBuying")]
        public string BanknoteBuying { get; set; }

        [XmlElement(ElementName = "BanknoteSelling")]
        public string BanknoteSelling { get; set; }



        [XmlElement(ElementName = "CrossRateUSD")]
        public string CrossRateUsd { get; set; }

        [XmlElement(ElementName = "CrossRateOther")]
        public string CrossRateOther { get; set; }
    }
}