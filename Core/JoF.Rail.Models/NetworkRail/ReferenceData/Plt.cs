namespace JoF.Rail.Models.NetworkRail.ReferenceData
{
    using System;

    public class Plt
    {
        public string Code { get; set; }

        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Length { get; set; }

        public string PwrSupplyType { get; set; }

        public bool DooPax { get; set; }

        public bool DooNonPax { get; set; }
    }
}
