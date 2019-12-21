using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyProvider.Xml
{
    public static class XmlExtension
    {
        public static T DeserializeXML<T>(this string content)
        {
            T response = default(T);

            var serializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(content))
            using (var reader = XmlReader.Create(stringReader))
            {
                object result = serializer.Deserialize(reader);
                if (result != null && result is T)
                {
                    response = ((T)result);
                }
            }
            return response;
        }
    }
}
