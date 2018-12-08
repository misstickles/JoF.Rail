namespace JoF.Rail.Tests.xUnit.Imports
{
    using JoF.Rail.Imports.NetworkRail;
    using Xunit;

    public class NetworkRailReferenceDataTests
    {
        private readonly ReferenceData referenceData;

        public NetworkRailReferenceDataTests()
        {
            this.referenceData = new ReferenceData();
        }

        [Fact]
        public void ImportRef_Loc_AsJsonFile()
        {
            this.referenceData.Location();
        }

        [Fact]
        public void ImportRef_Plt_AsJsonFile()
        {
            this.referenceData.Platform();
        }

        [Fact]
        public void ImportRef_Tld_AsJsonFile()
        {
            this.referenceData.TimingLoad();
        }

        [Fact]
        public void ImportRef_Ref_AsJsonFile()
        {
            this.referenceData.Reference();
        }

        [Fact]
        public void ImportRef_Nwk_AsJsonFile()
        {
            this.referenceData.NetworkLink();
        }

        [Fact]
        public void ImportRef_Tlk_AsJsonFile()
        {
            // NOTE: this file is around 315Mb
            // TODO: consider shrinking the fields
            // this.referenceData.TimingLink();
        }
    }
}
