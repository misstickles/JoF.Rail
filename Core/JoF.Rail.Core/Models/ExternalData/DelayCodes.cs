namespace JoF.Rail.Core.Models.ExternalData
{
    using System.Collections.Generic;

    public class DelayCodes
    {
        public IEnumerable<Codes> LateReasons { get; set; }

        public IEnumerable<Codes> CancelReasons { get; set; }

        public class Codes
        {
            public int Code { get; set; }

            public string Reason { get; set; }
        }
    }
}
