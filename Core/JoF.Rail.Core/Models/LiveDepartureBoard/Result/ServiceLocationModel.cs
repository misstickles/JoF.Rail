namespace JoF.Rail.Core.Models.LiveDepartureBoard.Result
{
    public class ServiceLocationModel
    {
        public string Location { get; set; }

        public string Crs { get; set; }

        public string Via { get; set; }

        public string FutureChangeTo { get; set; }

        public bool AssociationIsCancelled { get; set; }
    }
}
