namespace JoF.Rail.Core.Web.Features.Boards
{
    using System.Collections.Generic;

    public class BoardsViewModel : Departures.Query
    {
        public List<(string value, string text)> TimeWindows => new List<(string, string)>
        {
            ("0", "0"),
            ("10", "10"),
            ("20", "20"),
            ("30", "30"),
            ("40", "40"),
            ("50", "50"),
            ("60", "60"),
            ("70", "70"),
            ("80", "80"),
            ("90", "90"),
            ("100", "100"),
            ("110", "110"),
            ("120", "120"),
        };

        public List<(string value, string text, string group)> TimeOffsets => new List<(string, string, string)>
        {
            ("-120", "-2hr", "Previous Services"),
            ("-115", "-1hr 45", "Previous Services"),
            ("-90", "-1hr 30", "Previous Services"),
            ("-75", "-1hr 15", "Previous Services"),
            ("-60", "-1hr", "Previous Services"),
            ("-45", "-45 mins", "Previous Services"),
            ("-30", "-30 mins", "Previous Services"),
            ("-15", "-15", "Previous Services"),
            ("0", "Now", "Now"),
            ("15", "+15 mins", "Future Services"),
            ("30", "+30 mins", "Future Services"),
            ("45", "+45 mins", "Future Services"),
            ("60", "+1hr", "Future Services"),
            ("75", "+1hr 15", "Future Services"),
            ("90", "+1hr 30", "Future Services"),
            ("105", "+1h 45", "Future Services"),
            ("120", "+2hr", "Future Services"),
        };
    }
}
