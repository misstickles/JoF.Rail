namespace JoF.Rail.Core.Extensions
{
    using System.IO;
    using System.IO.Compression;
    using System.Xml.Serialization;

    public static class ByteExtensions
    {
        public static T ToString<T>(this byte[] bytes)
            where T : class
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (GZipStream gz = new GZipStream(ms, CompressionMode.Decompress))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(gz);
                }
                catch
                {
                    // TODO: catch
                }

                return null;
            }

            //return Convert.ToBase64String(bytes);
            //return Encoding.UTF8.GetString(bytes);
        }
    }
}
