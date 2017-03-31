# Publishing feeds with the RssToolkit
To publish feeds, you need to do two things. Firstly, you have indicate that you offer an feed to allow autodiscovery and subscription. Secondly, you need to construct an RssDocument class instance that contains the elements you wish to publish and make that feed available on a page.

## Publishing links to your feed
The {{RssHyperLink}} control is a {{WebControl}} that can be embedded on any {{.aspx}} page for publishing links to your feed.  You point the the control to the feed location and it automatically generates a link tag suitable for inclusion in the {{<HEAD>}} block of an HTML page.
How-to: [Publishing feed link with RssHyperLink](Publishing-feed-link-with-RssHyperLink)

## Publishing the feed
You can publish the contents of your feed in several ways. You can embed the feed in a standard {{.aspx}} page, you can emit the feed from an {{.ashx}} handler, or you emit the feed as a file that can be statically accessed. In addition, the feed can be published as an RSS, Atom, or RDF document.

### Using the {{RssHttpHandlerBase}} class
When you generate a custom feed class using the {{RssDl.exe}} command-line compiler or the {{RssBuildProvider}}, it automatically includes a base class that can be used to generate feeds from strong-typed {{Items}} defined by the feed. The base class is an HttpProvider and can be used in the code behind of an {{.ashx}} HttpHandler page.
How-to: [Publishing a feed using ASHX handler](Publishing-a-feed-using-ASHX-handler)

### Using the {{RssDocument}} class
If you generate a custom feed class, or use the weak-typed {{RssDocument}} base class, you can emit the feed as an XML document ({{String}}) which can be included in any page's contents. You could also use the string to write directly to a file or embed a feed's contents in a database or email message.
How-to: [Publishing a feed using ToXML](Publishing-a-feed-using-ToXML)