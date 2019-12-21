using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CurrencyProvider.Model
{
    public class Currency
    {
        [XmlAttribute("CurrencyCode")]
        public string Code { get; set; }

        [XmlElement(ElementName = "Unit")]
        public string Unit { get; set; }

        [XmlElement(ElementName = "CurrencyName")]
        public string Name { get; set; }



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
