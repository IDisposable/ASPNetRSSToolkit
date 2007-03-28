<?xml version="1.0" ?>
<xsl:stylesheet version="1.1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:atom="http://www.w3.org/2005/Atom" >
    <xml:output mode="xml" encoding="UTF-8"/>

    <xsl:template match="//atom:feed">
        <xsl:element name="rss">
            <xsl:attribute name="version"><xsl:value-of select="2.0"/></xsl:attribute>
            <xsl:element name="channel">
                <xsl:element name="generator">
                    <xsl:value-of select="atom:generator"/>
                </xsl:element>
                <xsl:element name="title">
                    <xsl:value-of select="atom:title"/>
                </xsl:element>
                <xsl:element name="link">
                    <xsl:value-of select="atom:link/@href"/>
                </xsl:element>
                <xsl:element name="description">
                    <xsl:value-of select="atom:tagline"/>
                </xsl:element>
                <xsl:element name="copyright">
                    <xsl:value-of select="atom:copyright"/>
                </xsl:element>
                <xsl:element name="pubDate">
                    <xsl:value-of select="atom:modified"/>
                </xsl:element>
                <xsl:element name="lastBuildDate">
                    <xsl:value-of select="atom:modified"/>
                </xsl:element>
                <xsl:call-template name="items"/>
            </xsl:element>
        </xsl:element>
    </xsl:template>

    <xsl:template name="items">
        <xsl:for-each select="atom:entry">
            <xsl:element name="item">
                <xsl:element name="title">
                    <xsl:value-of select="atom:title"/>
                </xsl:element>
                <xsl:element name="link">
                    <xsl:value-of select="atom:link/@href"/>
                </xsl:element>
                <xsl:element name="description">
                    <xsl:value-of select="atom:content"/>
                </xsl:element>
                <xsl:element name="pubDate">
                    <xsl:value-of select="atom:modified"/>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
    </xsl:template>

</xsl:stylesheet>
