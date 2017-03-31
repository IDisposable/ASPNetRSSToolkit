# Using **{{RssDataSource}}**
This {{WebControl}} gives you the ability to databind to an RSS/Atom/RDF/OPML feed. It is derived from {{DataSourceControl}} and has the ability serve as a data source to any data-bound controls. The control has complete Designer support for configuring the datasource feed.

How to: [Consuming With RssDataSource](Consuming-With-RssDataSource)

# Using **{{RssDocument}}** class
This base-level class can be used to consume a feed in a weak-typed form (much the way Version 1.0 of the RssToolkit worked) where the feed dynamically determines the columns available. You can use this to either consume or publish feed in code-behind or even in a non-web situation. You can load a feed from a file, from a URL. from a {{XmlReader}} or from a {{String}}. The feed can be rendered out in XML form (as an RSS/Atom or PDF {{String}}) or can be rendered to a {{DataSet}} that contains a {{DataTable}} for each channel and a {{DataRow}} for each item. The columns of each {{DataRow}} are determined by the feed's elements.

How to: [Consuming with RssDocument](Consuming-with-RssDocument)

# Using compile-time generated classes
One of the best features of the ASP.Net RSS Toolkit is the ability to generate a class that gives strong-typed properties for the elements in each feed item. This allows you to programatically examine and manipulate the properties for the feed. If the feed uses external schema definitions for custom extension properties such as the Media Rss by Yahoo [http://search.yahoo.com/mrss](http://search.yahoo.com/mrss), they will be fully handled as well. The advantage of this approach is that you don't have to write code to handle the proper serialization of {{DateTime}}(s), {{Url}}(s) or even nested element types like those from the Yahoo Media Rss definitions. Additionally, the feed source can be a URL (served from some web site) or a file (cached from a previous fetch, or even just hand synthesized to reflect a storage). In fact, a feed file could be used as a self-created strong-typed configuration file.

There are two ways that these strong-typed classes can be generated:
## The **{{RssDl.exe}}** command-line compiler

How-to: [Consuming Feeds with RssDll Compiler](Consuming-Feeds-with-RssDll-Compiler)

## The **{{RssBuildProvider}}**
The final way to consume feeds works only with Web Site Projects or Web Application Projects. By adding a Build Provider [http://msdn2.microsoft.com/en-us/library/system.web.compilation.buildprovider.aspx](http://msdn2.microsoft.com/en-us/library/system.web.compilation.buildprovider.aspx) to your {{web.config}} you can have the RssToolkit automatically handle the generation of the strong-typed classed for the feed(s).

How-to: [Consuming Feeds with a Build Provider](Consuming-Feeds-with-a-Build-Provider)