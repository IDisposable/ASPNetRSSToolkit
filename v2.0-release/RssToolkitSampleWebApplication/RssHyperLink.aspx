<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <h2>Publishing RSS feed using RssDocument</h2>
    <div>
        Simple feed:
        <cc1:rsshyperlink id="RssHyperLink1" runat="server" includeusername="False" navigateurl="~/RssHyperLink.ashx">Rss</cc1:rsshyperlink><br />
        Publish as Atom:
        <cc1:rsshyperlink id="RssHyperLink5" runat="server" includeusername="False" navigateurl="~/RssHyperLink.ashx?outputtype=atom">Atom</cc1:rsshyperlink><br />
        Publish as Rdf:
        <cc1:rsshyperlink id="RssHyperLink6" runat="server" includeusername="False" navigateurl="~/RssHyperLink.ashx?outputtype=rdf">Rdf</cc1:rsshyperlink><br />
        Publish as Opml:
        <cc1:rsshyperlink id="RssHyperLink7" runat="server" includeusername="False" navigateurl="~/RssHyperLink.ashx?outputtype=opml">Opml</cc1:rsshyperlink><br />
        Feed with channel name:<cc1:RssHyperLink ID="RssHyperLink2" runat="server" ChannelName="Channel1" IncludeUserName="False" NavigateUrl="~/RssHyperLink.ashx">RSS Channel1</cc1:RssHyperLink><br />
        Feed with channel name:
        <cc1:RssHyperLink ID="RssHyperLink3" runat="server" ChannelName="Channel2" IncludeUserName="False"
            NavigateUrl="~/RssHyperLink.ashx">RSS Channel2</cc1:RssHyperLink><br />
        Feed for the particular user:
        <cc1:RssHyperLink ID="Rsshyperlink4" runat="server" IncludeUserName="True" NavigateUrl="~/RssHyperLink.ashx">RSS</cc1:RssHyperLink></div>
</asp:Content>