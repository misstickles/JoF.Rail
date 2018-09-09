namespace JoF.Rail.Tests.xUnit.Imports
{
    using JoF.Rail.Imports.NationalRail;
    using JoF.Rail.Models.NationalRail.PportTimetable;
    using Xunit;

    public class PportTimetableRefImportTests
    {
        private readonly PportTimetableRef pportTimetableRef;

        private readonly PportTimetable data;

        public PportTimetableRefImportTests()
        {
            this.pportTimetableRef = new PportTimetableRef();
            this.data = this.pportTimetableRef.Data;
        }

        [Fact]
        public void ImportPport_Locations_AsJsonFile()
        {
            this.pportTimetableRef.CreateLocations();
        }

        [Fact]
        public void ImportPport_Tocs_AsJsonFile()
        {
            this.pportTimetableRef.CreateTocs();
        }

        [Fact]
        public void ImportPport_Vias_AsJsonFile()
        {
            this.pportTimetableRef.CreateVias();
        }

        [Fact]
        public void ImportPport_Reasons_AsJsonFile()
        {
            this.pportTimetableRef.CreateReasons();
        }

        [Fact]
        public void ImportPport_CisSources_AsJsonFile()
        {
            this.pportTimetableRef.CreateCisSources();
        }
    }
}
