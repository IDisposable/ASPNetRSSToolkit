<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <h2>Generating Rss Hyperlink from Custom generated classes</h2>
    <div>
        Simple feed:
        <cc1:RssHyperLink ID="RssHyperLink1" runat="server" IncludeUserName="False" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS</cc1:RssHyperLink><br />
        Feed with channel name:<cc1:RssHyperLink ID="RssHyperLink2" runat="server" ChannelName="Channel1"
            IncludeUserName="False" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS Channel1</cc1:RssHyperLink><br />
        Feed with channel name:
        <cc1:RssHyperLink ID="RssHyperLink3" runat="server" ChannelName="Channel2" IncludeUserName="False"
            NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS Channel2</cc1:RssHyperLink><br />
        Feed for the particular user:
        <cc1:RssHyperLink ID="Rsshyperlink4" runat="server" IncludeUserName="True" NavigateUrl="~/RssHyperLinkFromCustomClass.ashx">RSS</cc1:RssHyperLink>
    </div>
</asp:Content>
