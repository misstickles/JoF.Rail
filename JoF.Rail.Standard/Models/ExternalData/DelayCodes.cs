using System.Collections.Generic;

namespace JoF.Rail.Standard.Models.ExternalData
{
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
