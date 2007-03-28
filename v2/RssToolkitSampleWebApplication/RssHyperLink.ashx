<%@ WebHandler Language="C#" Class="RssHyperLinkFromRssFile" %>

using System;
using System.Web;
using System.Collections.Generic;
using RssToolkit.Rss;

public class RssHyperLinkFromRssFile :  RssToolkit.Rss.RssDocumentHttpHandler
{
    protected override void PopulateRss(string channelName, string userName) 
    {
        Rss.Channel = new RssChannel();
        Rss.Channel.Items = new List<RssItem>();
        if (!string.IsNullOrEmpty(channelName))
        {
            Rss.Channel.Title += " '" + channelName + "'";
        }

        if (!string.IsNullOrEmpty(userName))
        {
            Rss.Channel.Title += " (generated for " + userName + ")";
        }

        RssItem item = new RssItem();
        item.Title = "CodeGeneratedClass";
        item.Description = "Consuming RSS feed programmatically using strongly typed classes";
        item.Link = "~/CodeGeneratedClass.aspx";
        Rss.Channel.Items.Add(item);

        item = new RssItem();
        item.Title = "ObjectDataSource";
        item.Description = "Consuming RSS feed using ObjectDataSource";
        item.Link = "~/ObjectDataSource.aspx";
        Rss.Channel.Items.Add(item);

        item = new RssItem();
        item.Title = "Opml";
        item.Description = "Using OPML Files to aggregate and produce one feed";
        item.Link = "~/Opml.aspx";
        Rss.Channel.Items.Add(item);

        item = new RssItem();
        item.Title = "RssDataSource";
        item.Description = "Consuming RSS feed using RssDataSource";
        item.Link = "~/RssDataSource.aspx";
        Rss.Channel.Items.Add(item);
        
        item = new RssItem();
        item.Title = "RssDocument";
        item.Description = "Consuming RSS feed programmatically using RssDocument";
        item.Link = "~/RssDocument.aspx";
        Rss.Channel.Items.Add(item);
    }    
}