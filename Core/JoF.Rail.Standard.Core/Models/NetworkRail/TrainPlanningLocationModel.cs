namespace JoF.Rail.Standard.Core.Models.NetworkRail
{
    using System;

    public class TrainPlanningLocationModel
    {
        //public string RecordType { get; set; }

        //public char ActionCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //public int OSEasting { get; set; }

        //public int OSNorthing { get; set; }

        public char TimingPoint { get; set; }   // T/M/O TRUST, Mandatory, Optional

        //public string Zone { get; set; }

        public int StanoxCode { get; set; }

        public char OffNetworkInd { get; set; }

        //public char ForceLpb { get; set; }      // .. 
    }
}
