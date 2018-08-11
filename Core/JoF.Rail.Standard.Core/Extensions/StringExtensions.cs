namespace JoF.Rail.Standard.Core.Extensions
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    public static class StringExtensions
    {
        public static T DeserialiseXml<T>(this string xml)
            where T : class
        {
            T result = null;

            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(sr);
            }

            return result;
        }

        public static T DeserialiseJson<T>(this string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson(this object model, JsonSerializerSettings settings = null)
        {
            if (model == null) return null;

            return JsonConvert.SerializeObject(model, settings);
        }
    }
}
