namespace JoF.Rail.Core.Extensions
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    public static class StringExtensions
    {
        /// <summary>
        /// Deserialise xml string into POCO
        /// </summary>
        /// <typeparam name="T">The POCO to deserialise to</typeparam>
        /// <param name="xml">XML string</param>
        /// <returns>{T}</returns>
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

        /// <summary>
        /// Deserialises json string into POCO
        /// </summary>
        /// <typeparam name="T">The POCO to deserialise to</typeparam>
        /// <param name="json">JSON string</param>
        /// <returns>{T}</returns>
        public static T DeserialiseJson<T>(this string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Converts object model to JSON
        /// </summary>
        /// <param name="model">POCO model</param>
        /// <param name="settings">Serialiser settings</param>
        /// <returns>JSON string</returns>
        public static string ToJson(this object model, JsonSerializerSettings settings = null)
        {
            if (model == null) return null;

            return JsonConvert.SerializeObject(model, settings);
        }

        /// <summary>
        /// The offset delay in scheduled and estimated times, minutes
        /// </summary>
        /// <param name="estimatedTime">Estimated time string HH:mm</param>
        /// <param name="scheduledTime">Scheduled time string HH:mm</param>
        /// <returns>string of delay in minutes</returns>
        public static string ToTimeDelay(this string estimatedTime, string scheduledTime)
        {
            if (estimatedTime == null
                || scheduledTime == null
                || !estimatedTime.Contains(":")
                || estimatedTime == scheduledTime)
            {
                return "-";
            }

            var now = DateTime.Now;

            var estIso = now.ToString($"yyyy-MM-ddT{estimatedTime}:00");
            var schedIso = now.ToString($"yyyy-MM-ddT{scheduledTime}:00");

            DateTime.TryParse(estIso, out var estTime);
            DateTime.TryParse(schedIso, out var schedTime);

            // assume next morning
            if (estTime.Hour < schedTime.Hour)
            {
                estTime = estTime.AddDays(1);
            }

            var delay = estTime - schedTime;

            return $"{(60 * delay.Hours) + delay.Minutes}";
        }

        /// <summary>
        /// Convert two time strings to delay
        /// </summary>
        /// <param name="estimatedTime">Time to compare against</param>
        /// <param name="actualTime">Actual time</param>
        /// <param name="hasColon">Whether time string has colon</param>
        /// <returns>Delay, minutes</returns>
        public static string ToTimeDelay(this string estimatedTime, string actualTime, bool hasColon)
        {
            if (!hasColon)
            {
                var bEst = int.TryParse(estimatedTime, out var est);
                var bAct = int.TryParse(actualTime, out var ac);

                if (!bEst || !bAct)
                {
                    return "-";
                }

                estimatedTime = $"{estimatedTime.Substring(0, 2)}:{estimatedTime.Substring(2, 2)}";
                actualTime = $"{actualTime.Substring(0, 2)}:{actualTime.Substring(2, 2)}";
            }

            return actualTime.ToTimeDelay(estimatedTime);
        }
    }
}
