namespace JoF.Rail.Models.NetworkRail.ReferenceData
{
    using System;

    public class Nwk
    {
        public string Origin { get; set; }

        public string Dest { get; set; }

        public string LineCode { get; set; }

        public string LineDesc { get; set; }

        public DateTime StartDte { get; set; }

        public DateTime EndDte { get; set; }

        public string InitialDir { get; set; }

        public string FinalDir { get; set; }

        public string Dist { get; set; }

        public bool DooPax { get; set; }

        public bool DooNonPax { get; set; }

        public bool Retb { get; set; }

        public string Zone { get; set; }

        public string RevLine { get; set; }

        public string PwrSupType { get; set; }

        public string Ra { get; set; }

        public int MaxLen { get; set; }
    }
}
