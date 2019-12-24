using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyProvider.Model
{
    [Serializable]
    [XmlRoot("Tarih_Date")]
    public class CurrencyList
    {
        [XmlElement("Currency")]
        public List<Currency> Currencies { get; set; }

        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlAttribute("Tarih")]
        public string Tarih { get; set; }

        [XmlAttribute("Bulten_No")]
        public string BultenNo { get; set; }
    }
}