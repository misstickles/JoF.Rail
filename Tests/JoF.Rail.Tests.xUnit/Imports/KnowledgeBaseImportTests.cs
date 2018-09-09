namespace JoF.Rail.Tests.xUnit.Imports
{
    using JoF.Rail.Imports.NetworkRail;
    using Xunit;

    public class KnowledgeBaseImportTests
    {
        private KnowledgeBaseData kb = new KnowledgeBaseData();

        [Fact]
        public void Import_Stations_AsJsonFile()
        {
            this.kb.Stations();
        }
    }
}
