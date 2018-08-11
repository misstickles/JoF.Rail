namespace JoF.Rail.Standard.Services
{
    using System.IO;
    using JoF.Rail.Standard.Core.Extensions;
    using Newtonsoft.Json;

    public static class ReadFile<T> where T : class
    {
        public static T GetFromJson(string filename)
        {
            using (StreamReader r = File.OpenText(filename))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static T GetFromXml(string filename)
        {
            using (StreamReader r = File.OpenText(filename))
            {
                var xml = r.ReadToEnd();
                return xml.DeserialiseXml<T>();
            }
        }
    }
}
