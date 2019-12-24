using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyProvider.Xml
{
    public static class XmlExtension
    {
        /// <summary>
        /// Deserializes the XML content to a specified object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeserializeXML<T>(this string content)
        {
            T response = default(T);

            if (!string.IsNullOrEmpty(content))
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var stringReader = new StringReader(content))
                using (var reader = XmlReader.Create(stringReader))
                {
                    if (serializer.CanDeserialize(reader))
                    {
                        object result = serializer.Deserialize(reader);
                        if (result != null && result is T)
                        {
                            response = ((T)result);
                        }
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Serializes the specified object and returns the xml value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SeriliazerXML<T>(this T obj)
        {
            string result = string.Empty;

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, obj);
            result = writer.ToString();

            return result;
        }
    }
}