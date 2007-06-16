//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RssToolkit.Rss;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;



[System.Serializable()]
[System.Xml.Serialization.XmlRoot("rss")]
public class MSNBCRss : RssToolkit.Rss.RssDocumentBase
{

    private string _version;

    private MSNBCChannel _channel;

    [XmlAttribute("version")]
    public string Version
    {
        get
        {
            return _version;
        }
        set
        {
            _version = value;
        }
    }

    [XmlElement("channel")]
    public MSNBCChannel Channel
    {
        get
        {
            return _channel;
        }
        set
        {
            _channel = value;
        }
    }

    public static MSNBCRss Load()
    {
        MSNBCRss doc;
        doc = MSNBCRss.Load(new System.Uri("http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml"));
        return doc;
    }

    public static MSNBCRss Load(System.Uri url)
    {
        if ((url == null))
        {
            throw new System.ArgumentNullException();
        }
        MSNBCRss doc;
        doc = RssDocumentBase.Load<MSNBCRss>(url);
        return doc;
    }

    public static MSNBCRss Load(System.Xml.XmlTextReader reader)
    {
        if ((reader == null))
        {
            throw new System.ArgumentNullException();
        }
        MSNBCRss doc;
        doc = RssDocumentBase.Load<MSNBCRss>(reader);
        return doc;
    }

    public static MSNBCRss Load(string xml)
    {
        if (String.IsNullOrEmpty(xml))
        {
            throw new System.ArgumentNullException();
        }
        MSNBCRss doc;
        doc = RssDocumentBase.Load<MSNBCRss>(xml);
        return doc;
    }

    public static System.Collections.Generic.List<MSNBCItem> LoadRssItems()
    {
        return Load().Channel.Items;
    }

    public override string ToXml(RssToolkit.Rss.DocumentType outputType)
    {
        return RssDocumentBase.ToXml<MSNBCRss>(outputType, this);
    }

    public virtual System.Data.DataSet ToDataSet()
    {
        return RssXmlHelper.ToDataSet(ToXml(DocumentType.Rss));
    }
}

public class MSNBCChannel
{

    private string _category;

    private string _copyright;

    private string _description;

    private List<MSNBCItem> _items;

    private string _lastBuildDate;

    private string _link;

    private string _ttl;

    private string _title;

    private MSNBCImage _image;

    private string _language;

    [XmlElement("category")]
    public string Category
    {
        get
        {
            return _category;
        }
        set
        {
            _category = value;
        }
    }

    [XmlElement("copyright")]
    public string Copyright
    {
        get
        {
            return _copyright;
        }
        set
        {
            _copyright = value;
        }
    }

    [XmlElement("description")]
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    [XmlElement("item")]
    public List<MSNBCItem> Items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
        }
    }

    [XmlElement("lastBuildDate")]
    public string LastBuildDate
    {
        get
        {
            return _lastBuildDate;
        }
        set
        {
            _lastBuildDate = value;
        }
    }

    [XmlElement("link")]
    public string Link
    {
        get
        {
            return _link;
        }
        set
        {
            _link = value;
        }
    }

    [XmlElement("ttl")]
    public string Ttl
    {
        get
        {
            return _ttl;
        }
        set
        {
            _ttl = value;
        }
    }

    [XmlElement("title")]
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }

    [XmlElement("image")]
    public MSNBCImage Image
    {
        get
        {
            return _image;
        }
        set
        {
            _image = value;
        }
    }

    [XmlElement("language")]
    public string Language
    {
        get
        {
            return _language;
        }
        set
        {
            _language = value;
        }
    }
}

public class MSNBCItem
{

    private string _category;

    private string _description;

    private MSNBCGuid _guid;

    private string _link;

    private string _pubDate;

    private string _pubDateParsed;

    private string _title;

    [XmlElement("category")]
    public string Category
    {
        get
        {
            return _category;
        }
        set
        {
            _category = value;
        }
    }

    [XmlElement("description")]
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    [XmlElement("guid")]
    public MSNBCGuid Guid
    {
        get
        {
            return _guid;
        }
        set
        {
            _guid = value;
        }
    }

    [XmlElement("link")]
    public string Link
    {
        get
        {
            return _link;
        }
        set
        {
            _link = value;
        }
    }

    [XmlElement("pubDate")]
    public string PubDate
    {
        get
        {
            return _pubDate;
        }
        set
        {
            _pubDate = value;
        }
    }

    [XmlElement("pubDateParsed")]
    public string PubDateParsed
    {
        get
        {
            return _pubDateParsed;
        }
        set
        {
            _pubDateParsed = value;
        }
    }

    [XmlElement("title")]
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
}

public class MSNBCGuid
{

    private string _isPermaLink;

    private string _text;

    [XmlAttribute("isPermaLink")]
    public string IsPermaLink
    {
        get
        {
            return _isPermaLink;
        }
        set
        {
            _isPermaLink = value;
        }
    }

    [XmlText()]
    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }
}

public class MSNBCImage
{

    private string _link;

    private string _title;

    private string _url;

    [XmlElement("link")]
    public string Link
    {
        get
        {
            return _link;
        }
        set
        {
            _link = value;
        }
    }

    [XmlElement("title")]
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }

    [XmlElement("url")]
    public string Url
    {
        get
        {
            return _url;
        }
        set
        {
            _url = value;
        }
    }
}

public class MSNBCHttpHandlerBase : RssToolkit.Rss.RssHttpHandlerBase<MSNBCRss>
{
}
