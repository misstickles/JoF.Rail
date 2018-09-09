namespace JoF.Rail.Core.Enums
{
    using System.ComponentModel;

    public enum ReerencefCodeTypes
    {
        [Description("Accommodation")]
        ACC,
        [Description("Bank Holidays Excepted codes")]
        BHX,
        [Description("Service brands")]
        BRA,
        [Description("Business sector")]
        BUS,
        [Description("Catering codes")]
        CAT,
        [Description("Operating characteristics codes")]
        OPC,
        [Description("Power supply type")]
        PWR,
        [Description("Reservation codes")]
        RES,
        [Description("Sleeper codes")]
        SLE,
        [Description("Train class")]
        TCL,
        [Description("Train category")]
        TCT,
        [Description("Train Operator codes")]
        TOC,
        [Description("Train status")]
        TRS,
        [Description("Train publication status")]
        TST,
        [Description("Reference code types")]
        REF,
        [Description("Network Rail zones")]
        ZNE,
        [Description("Activities at a location")]
        ACT,
    }
}
