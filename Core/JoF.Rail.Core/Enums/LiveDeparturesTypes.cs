namespace JoF.Rail.Core.Enums
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum FilterType
    {
        [Description("from")]
        [Display(Name = "Arrivals")]
        Arrivals,

        [Description("to")]
        [Display(Name = "Departures")]
        Departures
    }

    public enum CoachClass
    {
        [Description("First")]
        First,

        [Description("Mixed")]
        Mixed,

        [Description("Standard")]
        Standard
    }

    public enum ToiletStatus
    {
        [Description("Unknown")]
        Unknown,

        [Description("InService")]
        InService,

        [Description("NotInService")]
        NotInService
    }

    public enum ToiletType
    {
        [Description("Unknown")]
        Unknown,

        [Description("None")]
        None,

        [Description("Standard")]
        Standard,

        [Description("Accessible")]
        Accessible
    }

    public enum ServiceType
    {
        [Description("train")]
        Train,

        [Description("bus")]
        Bus,

        [Description("ferry")]
        Ferry
    }
}
