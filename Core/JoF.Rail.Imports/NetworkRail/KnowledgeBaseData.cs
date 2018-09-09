namespace JoF.Rail.Imports.NetworkRail
{
    using System;
    using System.IO;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Models.KnowledgeBase;

    public class KnowledgeBaseData
    {
        private readonly string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\", @"Core\JoF.Rail.Imports\RawData\"));

        public void Stations()
        {
            var xml = File.ReadAllText($@"{this.baseDirectory}\KbStations.xml");

            var data = xml.DeserialiseXml<StationModel>();

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\KbStations.json",
                data.ToJson());
        }
    }
}
