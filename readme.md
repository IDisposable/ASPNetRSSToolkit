## ASP.Net RSS Toolkit gives ASP.Net applications the ability to consume and publish to RSS feeds.



## Features include:

* {{RssDataSource}} control to consume feeds in ASP.NET applications

	* Works with ASP.NET data bound controls

	* Implements schema to generate columns at design time

	* Supports auto-generation of columns at runtime (via {{ICustomTypeDescriptor}} implementation)

* Caching of downloaded feeds both in-memory and on-disk (persisted across process restarts)

* Generation of strongly typed classes for feeds (including strongly typed channel, items, image, handler) based on a feed URL (the toolkit recognizes RSS, Atom and RDF feeds) or a file containing a sample feed. Allows programmatically download (and creation) of feeds using strongly-typed classes.

## The toolkit includes:

* Consuming feeds, using:

	* Stand-alone command line feed compiler that generates VB.Net or C# code files.

	* Build provider for .rssdl file (containing the list of feed URI(s) {"[including local files](including-local-files)"})

	* Build provider for .rss file (containing feed XML in RSS/Atom/RDF or OPML format)

* Support for generation of feeds in ASP.NET application including:

	* RSS HTTP handler (strongly typed HTTP handlers are generated automatically by the build providers) to generate the feed.

	* RSS Hyper Link control (that can point to RSS HTTP handler) to create RSS links

	* Optional secure encoding of user name into query string to allow generation of personalized feeds

* Set of classes for programmatic consumption  and generation of RSS feed in a late-bound way, without using strongly types generated classes

## How-to(s):

* Consuming feeds: [Consuming Feeds](Consuming-Feeds)

* Producing feeds: [Producing Feeds](Producing-Feeds)

* Feed aggregation: [OPML Support](OPML-Support)

* Feed caching: [Feed Cache](Feed-Cache)

## Packaging

The toolkit is packaged as an assembly (DLL) that can be either placed in GAC or in ‘bin’ directory of a web site application.  It is also usable from client (including WinForms) applications.

RSS Toolkit works in Medium Trust (RssToolkit.dll Assembly either in GAC or in ‘bin’) with the following caveats:

* If the ASP.NET application consumes RSS feeds, the trust level must be configured to allow outbound HTTP requests.

* To take advantage of disk caching, there must be a directory (configurable via AppSettings{"["rssTempDir"](_rssTempDir_)"}) where the trust level policy would allow write access.  However, disk caching is optional.

## History

* 6/15/2007 New Release (version 2.0.0.0)

	* Huge revamp of the project by Piyush Shah [http://blogs.msdn.com/shahpiyush/default.aspx](http://blogs.msdn.com/shahpiyush/default.aspx) to support strong-type feed generation. Added support for Atom, RDF. Added OPML aggregation, and schema validation of OMPL sub-feeds. Added ability to serve out feeds as RSS, Atom, RDF or OPML. Now supports qualified namespaces and enclosures. Download manager now can cache to application relative paths  (like the App_Data directory of a web site) to aid in medium trust deployments. Added unit tests via Visual Studio Team Foundation test framework.

* 3/26/2006 Update (version 1.0.0.1)

	* Added MaxItems property to RssDataSource to limit the number of items returned.

	* Added automatic generation of <link> tags from RssHyperLink control, to light up the RSS toolbar icon in IE7. For more information please see http://blogs.msdn.com/rssteam/articles/PublishersGuide.aspx

	* Added protected Context property (of type HttpContext) to RssHttpHandlerBase class, to allow access to the HTTP request while generating a feed.

	* Added generation of LoadChannel(string url) method in RssCodeGenerator so that one strongly typed channel class can be used to consume different channels.

	* Fixed problem expanding app relative (~/…) links containing query string when generating RSS feeds.

## Origins

The ASP.NET RSS Toolkit was conceived and created by Dmitry Robsman [http://blogs.msdn.com/dmitryr/](http://blogs.msdn.com/dmitryr/) and posted here by permission. Original blog postings:

Release 1.0.0.0 [http://blogs.msdn.com/dmitryr/archive/2006/02/21/536552.aspx](http://blogs.msdn.com/dmitryr/archive/2006/02/21/536552.aspx)

Release 1.0.0.1 [http://blogs.msdn.com/dmitryr/archive/2006/03/26/561200.aspx](http://blogs.msdn.com/dmitryr/archive/2006/03/26/561200.aspx)

