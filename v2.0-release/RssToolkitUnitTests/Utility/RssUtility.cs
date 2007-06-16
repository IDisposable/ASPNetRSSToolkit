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

        public const string AtomXml = @"<?xml version='1.0' encoding='UTF-8'?>
                                        <feed version='0.3' xml:lang='en'>
                                          <generator>NFE/1.0</generator>
                                          <title>Google News</title>
                                          <link rel='alternate' type='text/html' href='http://news.google.com/'/>
                                          <tagline>Google News</tagline>
                                          <author>
                                            <name>Google Inc.</name>
                                            <email>news-feedback@google.com</email>
                                          </author>
                                          <copyright>&amp;copy;2007 Google</copyright>
                                          <modified>2007-04-10T21:26:45+00:00</modified>
                                          <!-- A couple notes:
                                             * add an 'output=atom' param to get Atom
                                             * section pages have a 'topic=?' param;
                                               use 'topic=h' for a Top Stories section.
                                        -->
                                          <entry>
                                            <title>Breaking News: Larry is Dannieylynn&amp;#39;s Daddy - NTV</title>
                                            <link rel='alternate' type='text/html' href='http://www.nebraska.tv/home/ticker/6957412.html'/>
                                            <id>tag:news.google.com,2005:cluster=427861bc</id>
                                            <summary>Top Stories</summary>
                                            <issued>2007-04-10T20:02:38+00:00</issued>
                                            <modified>2007-04-10T20:02:38+00:00</modified>
                                            <content type='text/html' mode='escaped'>&lt;br&gt;&lt;table border=0 align= cellpadding=5 cellspacing=0&gt;&lt;tr&gt;&lt;td width=80 align=center valign=top&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0i-0&amp;fd=A&amp;url=http://www.washingtonpost.com/wp-dyn/content/article/2007/04/10/AR2007041000935.html%3Fhpid%3Dmoreheadlines&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;img src=http://news.google.com/news?imgefp=AIJRy0UJh38J&amp;imgurl=media3.washingtonpost.com/wp-dyn/content/photo/2007/04/10/PH2007041000936.jpg width=56 height=80 alt=&quot;&quot; border=1&gt;&lt;br&gt;&lt;font size=-2&gt;Washington Post&lt;/font&gt;&lt;/a&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-0&amp;fd=A&amp;url=http://www.nebraska.tv/home/ticker/6957412.html&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;b&gt;Breaking News: Larry is Dannieylynn&amp;#39;s Daddy&lt;/b&gt;&lt;/a&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;font color=#6f6f6f&gt;&lt;b&gt;NTV&amp;nbsp;-&lt;/font&gt; &lt;nobr&gt;1 hour ago&lt;/nobr&gt;&lt;/b&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;NASSAU, BAHAMAS (AP) DNA tests confirm that Larry Birkhead is the father of the late Anna Nicole Smith&amp;#39;s baby. The results were made public following a court hearing in the Bahamas.&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-1&amp;fd=A&amp;url=http://www.hollywoodtoday.net/%3Fp%3D636&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;Billion Dollar Baby Daddy is Birkhead in Anna Nicole Case&lt;/a&gt; &lt;font size=-1 color=#6f6f6f&gt;&lt;nobr&gt;Hollywood Today Newsmagazine&lt;/nobr&gt;&lt;/font&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-2&amp;fd=A&amp;url=http://www.mercurynews.com/celebrities/ci_5634567&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;Hearing on Smith daughter scheduled&lt;/a&gt; &lt;font size=-1 color=#6f6f6f&gt;&lt;nobr&gt;San Jose Mercury News&lt;/nobr&gt;&lt;/font&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1 class=p&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-3&amp;fd=A&amp;url=http://abclocal.go.com/kgo/story%3Fsection%3Dentertainment%26id%3D5193393&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;abc7news.com&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-4&amp;fd=A&amp;url=http://www.247gay.com/article.cfm%3Fsection%3D66%26id%3D14081&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;247gay.com&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-5&amp;fd=A&amp;url=http://www.forbes.com/feeds/ap/2007/04/10/ap3599299.html&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;Forbes&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-0-6&amp;fd=A&amp;url=http://www.cnn.com/2007/LAW/04/10/smith.baby/&amp;cid=1115185596&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;CNN&lt;/nobr&gt;&lt;/a&gt;&lt;/font&gt;&lt;br/&gt;&lt;font class=p size=-1&gt;&lt;a class=p href=http://news.google.com/?ncl=1115185596&amp;hl=en&gt;&lt;nobr&gt;&lt;b&gt;all 821 news articles&lt;/b&gt;&lt;/nobr&gt;&lt;/a&gt;&lt;/font&gt;&lt;br clear=all&gt; </content>
                                          </entry>
                                          <entry>
                                            <title>2 Former Youth Prison Workers Arrested - Forbes</title>
                                            <link rel='alternate' type='text/html' href='http://www.forbes.com/feeds/ap/2007/04/10/ap3599243.html'/>
                                            <id>tag:news.google.com,2005:cluster=4279543b</id>
                                            <summary>Top Stories</summary>
                                            <issued>2007-04-10T19:41:53+00:00</issued>
                                            <modified>2007-04-10T19:41:53+00:00</modified>
                                            <content type='text/html' mode='escaped'>&lt;br&gt;&lt;table border=0 align= cellpadding=5 cellspacing=0&gt;&lt;tr&gt;&lt;td width=80 align=center valign=top&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1i-0&amp;fd=A&amp;url=http://www.kcentv.com/news/c-article.php%3Fcid%3D1%26nid%3D12468&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;img src=http://news.google.com/news?imgefp=oiOTdaMcDUkJ&amp;imgurl=www.kcentv.com/images/martin.jpg width=80 height=53 alt=&quot;&quot; border=1&gt;&lt;br&gt;&lt;font size=-2&gt;KCEN-TV&lt;/font&gt;&lt;/a&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-0&amp;fd=A&amp;url=http://www.forbes.com/feeds/ap/2007/04/10/ap3599243.html&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;b&gt;2 Former Youth Prison Workers  Arrested&lt;/b&gt;&lt;/a&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;font color=#6f6f6f&gt;&lt;b&gt;Forbes&amp;nbsp;-&lt;/font&gt; &lt;nobr&gt;1 hour ago&lt;/nobr&gt;&lt;/b&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;By ALICIA A. CALDWELL 04.10.07, 3:34 PM ET. Two former West Texas juvenile prison employees were indicted Tuesday the most serious charges to emerge from the scandal, accusing them of sexually abusing teenage inmates.&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-1&amp;fd=A&amp;url=http://www.statesman.com/news/content/news/stories/local/04/11/11indict.html&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;Two former Youth Commission officials indicted in West Texas&lt;/a&gt; &lt;font size=-1 color=#6f6f6f&gt;&lt;nobr&gt;Austin American-Statesman (subscription)&lt;/nobr&gt;&lt;/font&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-2&amp;fd=A&amp;url=http://www.dallasnews.com/sharedcontent/dws/dn/latestnews/stories/041107dntextyc.be59c6b.html&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;Former TYC administrators indicted on sex charges 3:16 PM CDT&lt;/a&gt; &lt;font size=-1 color=#6f6f6f&gt;&lt;nobr&gt;Dallas Morning News (subscription)&lt;/nobr&gt;&lt;/font&gt;&lt;/font&gt;&lt;br&gt;&lt;font size=-1 class=p&gt;&lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-3&amp;fd=A&amp;url=http://www.chron.com/disp/story.mpl/ap/nation/4702686.html&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;Houston Chronicle&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-4&amp;fd=A&amp;url=http://www.kcentv.com/news/c-article.php%3Fcid%3D2%26nid%3D2150&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;KCEN-TV&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-5&amp;fd=A&amp;url=http://www.iht.com/articles/ap/2007/04/10/america/NA-GEN-US-Juvenile-Prison-Abuse-Prosecutor.php&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;International Herald Tribune&lt;/nobr&gt;&lt;/a&gt;&amp;nbsp;- &lt;a href=&quot;http://news.google.com/news/url?sa=T&amp;ct=us/0-1-6&amp;fd=A&amp;url=http://www.wlos.com/template/inews_wire/wires.national/2211521f-www.wlos.com.shtml&amp;cid=1115247675&amp;ei=FAEcRpHOMYTEoQLp6LijCQ&quot;&gt;&lt;nobr&gt;WLOS&lt;/nobr&gt;&lt;/a&gt;&lt;/font&gt;&lt;br/&gt;&lt;font class=p size=-1&gt;&lt;a class=p href=http://news.google.com/?ncl=1115247675&amp;hl=en&gt;&lt;nobr&gt;&lt;b&gt;all 95 news articles&lt;/b&gt;&lt;/nobr&gt;&lt;/a&gt;&lt;/font&gt;&lt;br clear=all&gt; </content>
                                          </entry>
                                        </feed>";
        public const string RdfXml = @"<?xml version='1.0' encoding='iso-8859-1'?>
                                        <?xml-stylesheet href='dsa-rdf.css' type='text/css'?>
                                        <rdf:RDF
                                          xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#'
                                          xmlns='http://purl.org/rss/1.0/'
                                          xmlns:dc='http://purl.org/dc/elements/1.1/'
                                          xml:lang='en'
                                        >
                                        <channel rdf:about='http://www.debian.org/security/dsa.rdf'>
                                          <title>Debian Security</title>
                                          <link>http://security.debian.org/</link>
                                          <description>
                                        Debian Security Advisories
                                          </description>
                                          <dc:date>2007-04-09T17:28:05+00:00</dc:date>
                                          <items>
                                            <rdf:Seq>
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1278' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1271' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1270' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1269' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1268' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1267' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1266' />
                                        <rdf:li resource='http://www.debian.org/security/2007/dsa-1265' />
                                            </rdf:Seq>
                                          </items>
                                        </channel>
                                        <item rdf:about='http://www.debian.org/security/2007/dsa-1278'>
                                          <title>DSA-1278 man-db</title>
                                          <link>http://www.debian.org/security/2007/dsa-1278</link>
                                          <description>
                                            buffer overflow
                                          </description>
                                          <dc:date>2007-04-06</dc:date>
                                        </item>
                                        <item rdf:about='http://www.debian.org/security/2007/dsa-1277'>
                                          <title>DSA-1277 XMMS</title>
                                          <link>http://www.debian.org/security/2007/dsa-1277</link>
                                          <description>
                                            several vulnerabilities
                                          </description>
                                          <dc:date>2007-04-04</dc:date>
                                        </item>
                                        </rdf:RDF>";

        public static RssDocument GetRssDocumentFromUrl()
        {
            RssDocument rss = RssDocument.Load(new System.Uri(RssUrl));
            return rss;
        }

        public static RssDocument GetRssDocumentFromXml()
        {
            RssDocument rss = RssDocument.Load(RssXml);
            return rss;
        }

        public static RssDocument GetRssDocumentFromOpmlUrl()
        {
            RssDocument rss = RssDocument.Load(new System.Uri(OpmlUrl));
            return rss;
        }

        public static RssDocument GetRssDocumentFromOpmlXml()
        {
            RssDocument rss = RssDocument.Load(OpmlXml); 
            return rss;
        }

        public static OpmlDocument GetOpmlDocumentFromXml()
        {
            return OpmlDocument.Load(OpmlXml);
        }
    }
}
