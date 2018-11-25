namespace JoF.Rail.Core.Models.Map
{
    using System.Collections.Generic;

    public class StationLocation
    {
        public IEnumerable<Station> Stations { get; set; }

        public class Station
        {
            public string Crs { get; set; }

            public string Name { get; set; }

            public string Operator { get; set; }

            public string OperatorName { get; set; }

            public string OperatorColour { get; set; }

            public double Lat { get; set; }

            public double Long { get; set; }

            public string Postcode { get; set; }

            public string SixtnCharName { get; set; }

            public IEnumerable<TocRef> Tocs { get; set; }

            public IEnumerable<AltId> AltIds { get; set; }

            public Fares Fare { get; set; }

            public Facility Facilities { get; set; }

            public class TocRef
            {
                public string Toc { get; set; }

                public string TocName { get; set; }

                public string Colour { get; set; }

                public string Type { get; set; }
            }

            public class AltId
            {
                public string LocCode { get; set; }
            }

            public class Fares
            {
                private bool oyster;
                private bool ticketMachine;
                private bool ticketOffice;

                public bool? Oyster
                {
                    get
                    {
                        return this.oyster;
                    }

                    set
                    {
                        if (value == null || value.Equals(string.Empty))
                        {
                            this.oyster = false;
                        }
                        else
                        {
                            this.oyster = (bool)value;
                        }
                    }
                }

                public bool? TktMachine
                {
                    get
                    {
                        return this.ticketMachine;
                    }

                    set
                    {
                        if (value == null || value.Equals(string.Empty))
                        {
                            this.ticketMachine = false;
                        }
                        else
                        {
                            this.ticketMachine = (bool)value;
                        }
                    }
                }

                public bool? TktOffice
                {
                    get
                    {
                        return this.ticketOffice;
                    }

                    set
                    {
                        if (value == null || value.Equals(string.Empty))
                        {
                            this.ticketOffice = false;
                        }
                        else
                        {
                            this.ticketOffice = (bool)value;
                        }
                    }
                }
            }

            public class Facility
            {
                private bool atm;
                private bool toilet;

                public bool? Atm
                {
                    get
                    {
                        return this.atm;
                    }

                    set
                    {
                        if (value == null || value.Equals(string.Empty))
                        {
                            this.atm = false;
                        } else
                        {
                            this.atm = (bool)value;
                        }
                    }
                }

                public bool? Toilet
                {
                    get
                    {
                        return this.toilet;
                    }

                    set
                    {
                        if (value == null || value.Equals(string.Empty))
                        {
                            this.toilet = false;
                        }
                        else
                        {
                            this.toilet = (bool)value;
                        }
                    }
                }
            }
        }
    }
}
