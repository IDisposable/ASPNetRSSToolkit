<%@ WebHandler Language="C#" Class="RssHyperLinkFromCustomClass" %>

using System;
using System.Collections.Generic;
using System.Web;
using RssToolkit.Rss;

public class RssHyperLinkFromCustomClass: Sample5HttpHandlerBase
{
    protected override void PopulateRss(string rssName, string userName)
    {
        Rss.Channel = new Sample5Channel();
        
        Rss.Channel.Items = new List<Sample5Item>();
        if (!string.IsNullOrEmpty(rssName))
        {
            Rss.Channel.Title += " '" + rssName + "'";
        }

        if (!string.IsNullOrEmpty(userName))
        {
            Rss.Channel.Title += " (generated for " + userName + ")";
        }

        Rss.Channel.Link = "~/scenario6.aspx";
        Rss.Channel.Description = "Channel For Scenario6 in ASP.NET RSS Toolkit samples.";
        Rss.Channel.Ttl = "10";
        Rss.Channel.User = userName;


        Sample5Item item = new Sample5Item();
        item.Title = "CodeGeneratedClass";
        item.Description = "Consuming RSS feed programmatically using strongly typed classes";
        item.Link = "~/CodeGeneratedClass.aspx";
        Rss.Channel.Items.Add(item);

        item = new Sample5Item();
        item.Title = "ObjectDataSource";
        item.Description = "Consuming RSS feed using ObjectDataSource";
        item.Link = "~/ObjectDataSource.aspx";
        Rss.Channel.Items.Add(item);

        item = new Sample5Item();
        item.Title = "Opml";
        item.Description = "Using OPML Files to aggregate and produce one feed";
        item.Link = "~/Opml.aspx";
        Rss.Channel.Items.Add(item);

        item = new Sample5Item();
        item.Title = "RssDataSource";
        item.Description = "Consuming RSS feed using RssDataSource";
        item.Link = "~/RssDataSource.aspx";
        Rss.Channel.Items.Add(item);

        item = new Sample5Item();
        item.Title = "RssDocument";
        item.Description = "Consuming RSS feed programmatically using RssDocument";
        item.Link = "~/RssDocument.aspx";
        Rss.Channel.Items.Add(item);
    }    
}