namespace JoF.Rail.Models.NetworkRail.ReferenceData
{
    using System;

    public class Tlk
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public string RunningLine { get; set; }

        public string TractionType { get; set; }

        public string TrailingLoad { get; set; }

        public string Speed { get; set; }

        public string Ra_Gauge { get; set; }

        public string EntrySpeed { get; set; }

        public string ExitSpeed { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SectionalRunningTime { get; set; } // mmm'ss

        public string Description { get; set; }
    }
}
