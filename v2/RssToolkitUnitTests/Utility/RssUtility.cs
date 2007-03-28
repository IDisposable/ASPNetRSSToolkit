using System;
using System.Collections.Generic;
using System.Text;
using RssToolkit.Rss;
using RssToolkit.Opml;

namespace RssToolkitUnitTest.Utility
{
    internal static class RssUtility
    {
        public const string RssUrl = "http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml";
        public static string[] RssUrls = new string[] { "http://msdn.microsoft.com/rss.xml", "http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml" };
        public const string RssXml = @"<?xml version='1.0' encoding='iso-8859-1' ?>
                                <rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>
	                                <channel>
		                                <title>Yahoo! News: Top Stories</title>
		                                <link>http://news.yahoo.com/i/716</link>
		                                <description>Top Stories</description>
		                                <language>en-us</language>
			                            <pubDate>Wed, 14 Feb 2007 23:05:49 GMT</pubDate>
		                                <lastBuildDate>Wed, 14 Feb 2007 23:10:27 GMT</lastBuildDate>
		                                <ttl>5</ttl>
		                                <copyright>Copyright (c) 2007 Yahoo! Inc. All rights reserved.</copyright>
                                        <category domain='http://www.microsoft.com'>MSFT</category> 
                                        <category domain='http://www.yahoo.com'>YHOO</category> 
                                        <cloud domain='rpc.sys.com' port='80' path='/RPC2' registerProcedure='pingMe' protocol='soap'/>
                                        <docs>http://blogs.law.harvard.edu/tech/rss</docs>
                                        <generator>MightyInHouse Content System v2.3</generator>
                                        <managingEditor>other@email.com</managingEditor>
                                        <webMaster>other2@email.com</webMaster>
                                        <rating>10</rating>
		                                <image>
			                                <title>Yahoo! News</title>
			                                <width>142</width>
			                                <height>18</height>
			                                <link>http://news.yahoo.com/i/716</link>
			                                <url>http://us.i1.yimg.com/us.yimg.com/i/us/nws/th/main_142b.gif</url>
                                            <description>Yahoo News on the hour.</description>
		                                </image>
		                                <item>
                                            <author>someone@email.com</author>
                                            <comments>This feed is from Yahoo News</comments>
			                                <title>Bush: Iran is source of deadly weapons</title>
			                                <link>http://us.rd.yahoo.com/dailynews/rss/topstories/*http://news.yahoo.com/s/ap/20070214/ap_on_go_pr_wh/bush</link>
			                                <guid isPermaLink='false'>ap/20070214/bush</guid>
			                                <pubDate>Wed, 14 Feb 2007 23:05:49 GMT</pubDate>
			                                <description>This is a feed description</description>
			                                <media:content url='http://d.yimg.com/us.yimg.com/p/afp/20070214/capt.sge.sjp12.140207164239.photo00.photo.default-512x353.jpg?x=130&amp;y=89&amp;sig=6o.nRJlRJq_zQYDs3VnTgg--' type='image/jpeg' height='89' width='130'/>
			                                <media:text type='html'>&#60;p>&#60;a href='http://us.rd.yahoo.com/dailynews/rss/topstories/*http://news.yahoo.com/s/ap/20070214/ap_on_go_pr_wh/bush'>&#60;img src='http://d.yimg.com/us.yimg.com/p/afp/20070214/capt.sge.sjp12.140207164239.photo00.photo.default-512x353.jpg?x=130&amp;y=89&amp;sig=6o.nRJlRJq_zQYDs3VnTgg--' align='left' height='89' width='130' alt='photo' title='US President George W. Bush speaks during a press conference in the East Room of the White House in Washington, DC. Bush said the new US-led effort to secure Baghdad was under way but warned it will &amp;quot;take time&amp;quot; and that there will be violence from those trying to derail his plan.(AFP/Jim Watson)' border='0'/>&#60;/a>&#60;/p>&#60;br clear='all'/></media:text>
			                                <media:credit role='publishing company'>(AP)</media:credit>
                                            <category domain='http://www.google.com'>GOOG</category> 
                                            <category domain='http://www.sun.com'>SUNW</category> 
                                            <source url='http://www.tomalak.org/links2.xml'>Tomalak's Realm</source>
	                                        <enclosure url='http://www.scripting.com/mp3s/weatherReportSuite.mp3' length='12216320' type='audio/mpeg' />
	                                </item>
                                    <textInput>
                                        <title>The label of the Submit button in the text input area.</title>
                                        <description>Explains the text input area.</description> 
                                        <name>The name of the text object in the text input area.</name>
                                        <link>The URL of the CGI script that processes text input requests.</link>
                                    </textInput>
                                    <skipHours>
                                        <hour>0</hour>
                                        <hour>1</hour>
                                    </skipHours>
                                    <skipDays>
                                        <day>Tuesday</day>
                                        <day>Friday</day>
                                    </skipDays>
	                                </channel>
                                </rss>";

        public const string OpmlUrl = "http://static2.podcatch.com/blogs/gems/opml/mySubscriptions.opml";
        
        public const string OpmlXml = @"<?xml version='1.0' encoding='ISO-8859-1'?>
                                    <opml version='1.1'>
	                                    <head>
		                                    <title>mySubscriptions.opml</title>
		                                    <dateCreated>Sat, 18 Jun 2005 12:11:52 GMT</dateCreated>
		                                    <dateModified>Tue, 02 Aug 2005 21:42:48 GMT</dateModified>
		                                    <ownerName>Some One</ownerName>
		                                    <ownerEmail>someone@email.com</ownerEmail>
		                                    <expansionState></expansionState>
		                                    <vertScrollState>1</vertScrollState>
		                                    <windowTop>61</windowTop>
		                                    <windowLeft>304</windowLeft>
		                                    <windowBottom>562</windowBottom>
		                                    <windowRight>842</windowRight>
                                            <link>http://www.microsoft.com</link>
		                                    </head>
	                                    <body>
		                                    <outline text='BBC News | News Front Page | UK Edition' description='Updated every minute of every day - FOR PERSONAL USE ONLY' htmlUrl='http://news.bbc.co.uk/go/click/rss/0.91/public/-/1/hi/default.stm' language='unknown' title='BBC News | News Front Page | UK Edition' type='rss' version='RSS' xmlUrl='http://news.bbc.co.uk/rss/newsonline_uk_edition/front_page/rss091.xml'/>
		                                    <outline text='CNET News.com' description='Tech news and business reports by CNET News.com. Focused on information technology, core topics include computers, hardware, software, networking, and Internet media.' htmlUrl='http://news.com.com/' language='unknown' title='CNET News.com' type='rss' version='RSS2' xmlUrl='http://news.com.com/2547-1_3-0-5.xml'/>
                                        </body>
                                    </opml>";
        public const string AtomUrl = "http://news.google.com/?output=atom";
        public const string RdfUrl = "http://www.debian.org/security/dsa";

        public static RssDocument GetRssDocumentFromUrl()
        {
            RssDocument rss = new RssDocument();
            rss.LoadFromUrl(RssUrl);
            return rss;
        }

        public static RssDocument GetRssDocumentFromXml()
        {
            RssDocument rss = new RssDocument();
            rss.LoadFromXml(RssXml);
            return rss;
        }

        public static RssDocument GetRssDocumentFromOpmlUrl()
        {
            RssDocument rss = new RssDocument();
            rss.LoadFromOpmlUrl(OpmlUrl);
            return rss;
        }

        public static RssDocument GetRssDocumentFromOpmlXml()
        {
            RssDocument rss = new RssDocument();
            rss.LoadFromOpmlXml(OpmlXml);
            return rss;
        }

        public static OpmlDocument GetOpmlDocumentFromXml()
        {
            return OpmlDocument.LoadFromXml(OpmlXml);
        }
    }
}
