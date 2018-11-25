<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:add="http://www.govtalk.gov.uk/people/AddressAndPersonalDetails" xmlns:com="http://nationalrail.co.uk/xml/common"
  exclude-result-prefixes="add com">
  
  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes"/>
  
  <xsl:template match="/">
    <Stations>
      <xsl:apply-templates select="/StationList/Station"/>
    </Stations>
  </xsl:template>

  <xsl:template match="Station">
    <Station>
      <AltIds>
        <xsl:apply-templates select="AlternativeIdentifiers"/>      
      </AltIds>
      <CrsCode>
        <xsl:value-of select="CrsCode"/>
      </CrsCode>
      <Facilities>
        <xsl:apply-templates select="StationFacilities"/>
      </Facilities>
      <Fare>
        <xsl:apply-templates select="Fares"/>
      </Fare>
      <Latitude>
        <xsl:value-of select="Latitude"/>
      </Latitude>
      <Longitude>
        <xsl:value-of select="Longitude"/>
      </Longitude>
      <Name>
        <xsl:value-of select="Name"/>
      </Name>
      <Operator>
        <xsl:value-of select="StationOperator"/>
      </Operator>
      <SixteenCharName>
        <xsl:value-of select="SixteenCharacterName"/>      
      </SixteenCharName>
      <Tocs>
        <xsl:apply-templates select="TrainOperatingCompanies"/>
      </Tocs>
      <Postcode>
        <xsl:value-of select="Address/com:PostalAddress/add:A_5LineAddress/add:PostCode" />
      </Postcode>
    </Station>
  </xsl:template>
  
  <xsl:template match="AlternativeIdentifiers">
    <LocCode>
      <xsl:value-of select="NationalLocationCode"/>
    </LocCode>
  </xsl:template>
  
  <xsl:template match="TrainOperatingCompanies">
    <Toc>
      <xsl:value-of select="TocRef"/>  
    </Toc>
  </xsl:template>

  <xsl:template match="StationFacilities">
    <Atm>
      <xsl:value-of select="AtmMachine/com:Available"/>
    </Atm>
    <Toilet>
      <xsl:value-of select="Toilets/com:Available" />
    </Toilet>
  </xsl:template>

  <xsl:template match="Fares">
    <Oyster>
      <xsl:value-of select="UseOystercard"/>
    </Oyster>
    <TktMachine>
      <xsl:value-of select="TicketMachine/Available"/>
    </TktMachine>
    <TktOffice>
      <xsl:choose>
        <xsl:when test="TicketOffice/com:Open">true</xsl:when>
        <xsl:otherwise>false</xsl:otherwise>
      </xsl:choose>
    </TktOffice>
  </xsl:template>

</xsl:stylesheet>