/// <summary>
/// https://wiki.openraildata.com/index.php/Train_Planning_Data_Structure
/// </summary>
namespace JoF.Rail.Imports.NetworkRail
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Models.NetworkRail.ReferenceData;

    public class ReferenceData
    {
        private const string DataFile = @"20170830_ReferenceData";

        private readonly string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\", @"Core\JoF.Rail.Imports\RawData\"));

        private readonly string[] data;

        public ReferenceData()
        {
            this.data = File.ReadAllLines($"{this.baseDirectory}{DataFile}");
        }

        public void Location()
        {
            var locations = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "LOC")
                .Select(i => new Loc
                {
                    Code = i[2],
                    Name = i[3],
                    StartDate = i[4] == string.Empty ? DateTime.MinValue : DateTime.ParseExact(i[4], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    EndDate = i[5] == string.Empty ? DateTime.MaxValue : DateTime.ParseExact(i[5], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    TimingPoint = i[8][0],
                    StanoxCode = i[10] == string.Empty ? default : Convert.ToInt32(i[10]),
                    OffNetworkInd = i[11][0]
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrLocations.json",
                locations.ToJson());
        }

        public void Platform()
        {
            var platforms = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "PLT")
                .Select(i => new Plt
                {
                    Code = i[2],
                    Id = i[3],
                    StartDate = i[4] == string.Empty ? DateTime.MinValue : DateTime.ParseExact(i[4], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    EndDate = i[5] == string.Empty ? DateTime.MaxValue : DateTime.ParseExact(i[5], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    Length = i[6].Equals(string.Empty) ? default : Convert.ToInt32(i[6]),
                    PwrSupplyType = string.IsNullOrWhiteSpace(i[7]) ? string.Empty : i[7],
                    DooPax = i[8].Equals("Y") ? true : false,
                    DooNonPax = i[9].Equals("N") ? true : false
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrPlatforms.json",
                platforms.ToJson());
        }

        public void TimingLoad()
        {
            var loads = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "TLD")
                .Select(i => new Tld
                {
                    TractionType = i[2],
                    TrailingLoad = i[3],
                    Speed = string.IsNullOrWhiteSpace(i[4]) ? default : Convert.ToInt32(i[4]),
                    RA_Gauge = i[5],
                    Description = i[6],
                    ItpsPowerType = i[7],
                    ItpsLoad = i[8],
                    LimitingSpeed = string.IsNullOrWhiteSpace(i[9]) ? default : Convert.ToInt32(i[9])
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrTimingLoads.json",
                loads.ToJson());
        }

        public void Reference()
        {
            var refs = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "REF")
                .Select(i => new Ref
                {
                    RefCodeType = i[2],
                    RefCode = i[3],
                    Description = i[4]
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrReferenceCodes.json",
                refs.ToJson());
        }

        public void NetworkLink()
        {
            var refs = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "NWK")
                .Select(i => new Nwk
                {
                    Origin = i[2],
                    Dest = i[3],
                    LineCode = i[4],
                    LineDesc = i[5],
                    StartDte = i[6] == string.Empty ? DateTime.MinValue : DateTime.ParseExact(i[6], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    EndDte = i[7] == string.Empty ? DateTime.MaxValue : DateTime.ParseExact(i[7], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    InitialDir = i[8],
                    FinalDir = i[9],
                    Dist = i[10],
                    DooPax = i[11].Equals("Y") ? true : false,
                    DooNonPax = i[12].Equals("N") ? true : false,
                    Retb = i[13].Equals("Y") ? true : false,
                    Zone = i[14],
                    RevLine = i[15],
                    PwrSupType = i[16],
                    Ra = i[17],
                    MaxLen = string.IsNullOrWhiteSpace(i[18]) ? default : Convert.ToInt32(i[18])
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrNetworkLink.json",
                refs.ToJson());
        }

        public void TimingLink()
        {
            var refs = this.data.Select(d => d
                .Split('\t'))
                .Where(d => d[0] == "TLK")
                .Select(i => new Tlk
                {
                    Origin = i[2],
                    Destination = i[3],
                    RunningLine = i[4],
                    TractionType = i[5],
                    TrailingLoad = i[6],
                    Speed = i[7],
                    Ra_Gauge = i[8],
                    EntrySpeed = i[9],
                    ExitSpeed = i[10],
                    StartDate = i[11] == string.Empty ? DateTime.MinValue : DateTime.ParseExact(i[11], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    EndDate = i[12] == string.Empty ? DateTime.MaxValue : DateTime.ParseExact(i[12], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    SectionalRunningTime = i[13],
                    Description = i[14],
                });

            File.WriteAllText(
                $@"{this.baseDirectory}\Imported\NrTimingLink.json",
                refs.ToJson());
        }
    }
}
