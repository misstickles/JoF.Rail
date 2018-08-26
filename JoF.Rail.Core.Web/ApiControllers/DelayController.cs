namespace JoF.Rail.Core.Web.ApiControllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Models.ExternalData;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DelayController
    {
        private const string CodesFile = @"~/../Data/DelayCodes.json";

        [HttpGet("Code")]
        public string Code(int code, bool isCancelled)
        {
            using (StreamReader r = File.OpenText(CodesFile))
            {
                var data = r.ReadToEnd().DeserialiseJson<DelayCodes>();

                if (!isCancelled)
                {
                    return data.LateReasons.First(d => d.Code == code).Reason;
                }

                return data.CancelReasons.First(c => c.Code == code).Reason;
            }
        }

        [HttpGet("Codes")]
        public IEnumerable<(int code, string reason, bool isCancelled)> Codes(IEnumerable<(int code, bool isCancelled)> codes)
        {
            using (StreamReader r = File.OpenText(CodesFile))
            {
                var data = r.ReadToEnd().DeserialiseJson<DelayCodes>();

                var delayed = data.LateReasons.Where(late => codes.Where(c => c.isCancelled == false).Select(c => c.code).Contains(late.Code)).Select(l => (l.Code, l.Reason, false));
                var cancelled = data.CancelReasons.Where(canx => codes.Where(c => c.isCancelled == true).Select(c => c.code).Contains(canx.Code)).Select(c => (c.Code, c.Reason, true));

                return delayed.Concat(cancelled);
            }
        }
    }
}