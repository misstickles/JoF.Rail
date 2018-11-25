namespace JoF.Rail.Imports.NetworkRail
{
    using System;
    using System.IO;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Models.KnowledgeBase;

    public class KnowledgeBaseData
    {
        private readonly string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\", @"Data\"));

        public void Stations()
        {
            var xml = File.ReadAllText($@"{this.baseDirectory}\KbStations.xml");

            // TODO: do not hard-code XSLT path
            var data = xml.DeserialiseXml<StationModel>(string.Empty);

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\KbStations.json",
                data.ToJson());

            File.Copy(
                $@"{this.baseDirectory}\Imported\KbStations.json",
                $@"{Path.GetFullPath(Path.Combine(this.baseDirectory,  @"..\", @"Hosting\JoF.Rail.Web\Data", "KbStations.json"))}",
                true);
        }
    }
}
