namespace JoF.Rail.Imports.NationalRail
{
    using System;
    using System.IO;
    using System.Xml;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Models.NationalRail.PportTimetable;

    public class PportTimetableRef
    {
        private const string DataFile = @"20181213020745_ref_v3.xml";

        private readonly string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\", @"Core\JoF.Rail.Imports\RawData\"));

        public PportTimetableRef()
        {
            var doc = new XmlDocument();
            doc.Load($"{this.baseDirectory}{DataFile}");

            this.Data = doc.InnerXml.DeserialiseXml<PportTimetable>();
        }

        public PportTimetable Data { get; set; }

        public void CreateLocations()
        {
            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NreLocations.json",
                this.Data.Locations.ToJson());
        }

        public void CreateReasons()
        {
            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NreReasons.json",
                $"{this.Data.LateReasons.ToJson()}{this.Data.CancelReasons.ToJson()}");
        }

        public void CreateVias()
        {
            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NreVias.json",
                this.Data.Vias.ToJson());
        }

        public void CreateCisSources()
        {
            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NreCisSources.json",
                this.Data.CisSources.ToJson());
        }

        public void CreateTocs()
        {
            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NreTocs.json",
                this.Data.Tocs.ToJson());
        }
    }
}
