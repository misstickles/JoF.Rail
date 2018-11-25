namespace JoF.Rail.Tests.xUnit.Web.Api
{
    using System.Linq;
    using FluentAssert;
    using JoF.Rail.Web.ApiControllers;
    using Xunit;

    public class StationMapMarkersTest
    {
        [Fact]
        public async void StationMapMarkers_GetAll_HasLotsOfResults()
        {
            var sut = new StationMapMarkersController();

            var results = await sut.All();

            results.Stations.ToList().Count().ShouldBeGreaterThan(100);
        }
    }
}
