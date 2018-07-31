﻿namespace JoF.Rail.Tests.xUnit.Standard
{
    using System.Linq;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Models;
    using Xunit;

    public class StringExtensionsTests
    {
        [Fact]
        public void XmlString_ConvertsToObject()
        {
            var result = xml.DeserialiseXml<NetworkOverviewModel>();
            Assert.True(result.Tocs.Count == 30);
            // Assert.True(result.Tocs.First(t => t.TocCode == "NT").ServiceGroups.Count == 2);
            Assert.True(result.Tocs.First(t => t.TocCode == "SN").Status == "Minor delays on some routes");
        }

        private readonly string xml = @"<?xml version='1.0' encoding='utf-8'?><NSI xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='http://internal.nationalrail.co.uk/xml/XsdSchemas/External/Version4.0/nre-service-indicator-v4-0.xsd' xmlns='http://nationalrail.co.uk/xml/serviceindicator'><TOC><TocCode>AW</TocCode><TocName>Arriva Trains Wales</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>ArrivaTW</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>CC</TocCode><TocName>c2c</TocName><Status>Custom</Status><StatusImage>icon-note-noshadow.png</StatusImage><StatusDescription><![CDATA[Amended service to / from London Liverpool Street]]></StatusDescription><ServiceGroup><GroupName>London Liverpool Street</GroupName><CurrentDisruption>D232D5254C3A4858B518A471A318A99A</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>c2c_Rail</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>CS</TocCode><TocName>Caledonian Sleeper</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>CalSleeper</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>CH</TocCode><TocName>Chiltern Railways</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>chilternrailway</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>XC</TocCode><TocName>CrossCountry</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>crosscountryuk</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>EM</TocCode><TocName>East Midlands Trains</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>EMTrains</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>ES</TocCode><TocName>Eurostar</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>EurostarUK</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>GX</TocCode><TocName>Gatwick Express</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>GatwickExpress</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>GC</TocCode><TocName>Grand Central</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>GC_Rail</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>GN</TocCode><TocName>Great Northern</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>GNRailUK</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>GW</TocCode><TocName>Great Western Railway</TocName><Status>Minor delays on some routes</Status><StatusImage>icon-note-noshadow.png</StatusImage><ServiceGroup><GroupName>Hilsea</GroupName><CurrentDisruption>DFC51946C3C24ABD82618C6FA0FCC520</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>GWRHelp</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>LE</TocCode><TocName>Greater Anglia</TocName><Status>Custom</Status><StatusImage>icon-note-noshadow.png</StatusImage><StatusDescription><![CDATA[Amended service to / from London Liverpool Street]]></StatusDescription><ServiceGroup><GroupName>London Liverpool Street</GroupName><CurrentDisruption>D232D5254C3A4858B518A471A318A99A</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>greateranglia</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>HX</TocCode><TocName>Heathrow Express</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>HeathrowExpress</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>HT</TocCode><TocName>Hull Trains</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>Hull_Trains</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>IL</TocCode><TocName>Island Line</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>SW_Help</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>GR</TocCode><TocName>London North Eastern Railway</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>LNER</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>LN</TocCode><TocName>London Northwestern Railway</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>LNRailway</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>LO</TocCode><TocName>London Overground</TocName><Status>Custom</Status><StatusImage>icon-note-noshadow.png</StatusImage><StatusDescription><![CDATA[Amended service to / from London Liverpool Street]]></StatusDescription><ServiceGroup><GroupName>London Liverpool Street</GroupName><CurrentDisruption>D232D5254C3A4858B518A471A318A99A</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>ldnoverground</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>ME</TocCode><TocName>Merseyrail</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>Merseyrail</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>NT</TocCode><TocName>Northern</TocName><Status>Custom</Status><StatusImage>icon-note-noshadow.png</StatusImage><StatusDescription><![CDATA[An amended timetable is in use]]></StatusDescription><ServiceGroup><GroupName>Bridlington</GroupName><CurrentDisruption>97E7937C6A93488BA1436755BFECB429</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><ServiceGroup><GroupName>Service alterations</GroupName><CurrentDisruption>EFB86C2B2F4F490FBFC0E3DAFCF7F2ED</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>northernassist</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>SR</TocCode><TocName>ScotRail</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>ScotRail</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>SW</TocCode><TocName>South Western Railway</TocName><Status>Minor delays on some routes</Status><StatusImage>icon-note-noshadow.png</StatusImage><ServiceGroup><GroupName>Hilsea</GroupName><CurrentDisruption>DFC51946C3C24ABD82618C6FA0FCC520</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><ServiceGroup><GroupName>South Western Railway Industrial action</GroupName><CurrentDisruption>D4BBDAFEEDD941F181AB61CD6A210FC4</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>SW_Help</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>SE</TocCode><TocName>Southeastern</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>Se_Railway</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>SN</TocCode><TocName>Southern</TocName><Status>Minor delays on some routes</Status><StatusImage>icon-note-noshadow.png</StatusImage><ServiceGroup><GroupName>Hilsea</GroupName><CurrentDisruption>DFC51946C3C24ABD82618C6FA0FCC520</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>SouthernRailUK</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>SX</TocCode><TocName>Stansted Express</TocName><Status>Custom</Status><StatusImage>icon-disruption.png</StatusImage><StatusDescription><![CDATA[Amended service at London Liverpool Street]]></StatusDescription><ServiceGroup><GroupName>London Liverpool Street</GroupName><CurrentDisruption>D232D5254C3A4858B518A471A318A99A</CurrentDisruption><CustomDetail><![CDATA[Read about this disruption]]></CustomDetail><CustomURL>http://www.nationalrail.co.uk/</CustomURL></ServiceGroup><TwitterAccount>Stansted_Exp</TwitterAccount><AdditionalInfo><![CDATA[Latest travel news]]></AdditionalInfo></TOC><TOC><TocCode>XR</TocCode><TocName>TfL Rail</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>TfLRail</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>TL</TocCode><TocName>Thameslink</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>TLRailUK</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>TP</TocCode><TocName>TransPennine Express</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>TPEAssist</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>VT</TocCode><TocName>Virgin Trains</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>VirginTrains</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC><TOC><TocCode>WM</TocCode><TocName>West Midlands Railway</TocName><Status>Good service</Status><StatusImage>icon-tick2.png</StatusImage><TwitterAccount>WestMidRailway</TwitterAccount><AdditionalInfo><![CDATA[Follow us on Twitter]]></AdditionalInfo></TOC></NSI>";
    }
}
