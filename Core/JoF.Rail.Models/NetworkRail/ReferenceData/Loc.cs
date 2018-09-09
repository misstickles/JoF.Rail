namespace JoF.Rail.Models.NetworkRail.ReferenceData
{
    using System;

    public class Loc
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public char TimingPoint { get; set; } // T/M/O TRUST, Mandatory, Optional

        public int StanoxCode { get; set; }

        public char OffNetworkInd { get; set; }
    }
}
