<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <h2>Generating Rss Hyperlink from App_code *.rss files</h2>
    <div>
        Simple feed:
        <cc1:RssHyperLink ID="RssHyperLink1" runat="server" IncludeUserName="False" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">Rss</cc1:RssHyperLink><br />
        Publish as Atom:
        <cc1:rsshyperlink id="RssHyperLink5" runat="server" includeusername="False" navigateurl="~/RssHyperLinkFromCustomClass.ashx?outputtype=atom">Atom</cc1:rsshyperlink><br />
        Publish as Rdf:
        <cc1:rsshyperlink id="RssHyperLink6" runat="server" includeusername="False" navigateurl="~/RssHyperLinkFromCustomClass.ashx?outputtype=rdf">Rdf</cc1:rsshyperlink><br />
        Publish as Opml:
        <cc1:rsshyperlink id="RssHyperLink7" runat="server" includeusername="False" navigateurl="~/RssHyperLinkFromCustomClass.ashx?outputtype=opml">Opml</cc1:rsshyperlink><br />
        Feed with channel name:<cc1:RssHyperLink ID="RssHyperLink2" runat="server" ChannelName="Channel1"
            IncludeUserName="False" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS Channel1</cc1:RssHyperLink><br />
        Feed with channel name:
        <cc1:RssHyperLink ID="RssHyperLink3" runat="server" ChannelName="Channel2" IncludeUserName="False"
            NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS Channel2</cc1:RssHyperLink><br />
        Feed for the particular user:
        <cc1:RssHyperLink ID="Rsshyperlink4" runat="server" IncludeUserName="True" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS</cc1:RssHyperLink>
    </div>
</asp:Content>
