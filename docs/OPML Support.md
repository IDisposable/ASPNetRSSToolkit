# OPML (Outline Processor Markup Language) Support
The RssToolkit also has support for OPML feeds [http://www.opml.org/spec](http://www.opml.org/spec) which allows you to list a number of feeds (referred to as Outlines) that can then be individually referenced or aggregated. When used with the RssToolkit, an OPML file (or feed URL) will cause each referenced feel to be be fetched and processed and the resulting items merged into (at this time) chronological order. This allows you to create an OPML file (or feed) that looks something like this:
{{
<?xml version="1.0" encoding="iso-8859-1"?>
<opml version="1.1">
  <head>
    <title>List of Feeds News Feeds</title>
    <dateCreated>Tue, 11 Nov 2003 19:47:24 GMT</dateCreated>
    <dateModified>Tue, 11 Nov 2003 19:47:28 GMT</dateModified>
    <ownerName>Webmaster</ownerName>
    <ownerEmail>owner@msdn.com</ownerEmail>
    <expansionState></expansionState>
    <vertScrollState>3</vertScrollState>
    <windowTop>93</windowTop>
    <windowLeft>127</windowLeft>
    <windowBottom>585</windowBottom>
    <windowRight>710</windowRight>
  </head>
  <body>
    <outline text='BBC News’ 
                 description='Updated every minute of every day - FOR PERSONAL USE ONLY'
                 htmlUrl='http://news.bbc.co.uk/go/click/rss/0.91/public/-/1/hi/default.stm'
                 language='unknown' title='BBC News' type='rss' version='RSS'
                 xmlUrl='http://news.bbc.co.uk/rss/newsonline_uk_edition/front_page/rss091.xml'/>
    <outline text='CNET News.com'
                 description='Tech news and business reports by CNET News.com. Focused on information technology, core topics include computers, hardware, software, networking, and Internet media.'
                 htmlUrl='http://news.com.com/'
                 language='unknown' title='CNET News.com' type='rss' version='RSS2'
                 xmlUrl='http://news.com.com/2547-1_3-0-5.xml'/>
  </body>
</opml>
}}
Which will result in a single generated feed that aggregates the contents of the two feeds mentioned into a single feed.  If you are using the base {{RssDocument}} class, you can access all of the items using the standard {{Items}} property and the OPML feed (or file) can be loaded using any of the standard {{Load}} overrides as shown in the +Using **{{RssDocument}}** class+ section of the [Consuming Feeds](Consuming-Feeds) documenation.