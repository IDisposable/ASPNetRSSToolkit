<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">

    <div>
        <h2>Consuming RSS feed using RssDataSource</h2>    
        <asp:GridView runat="Server" Id="GridView" DataSourceID="RssDataSource1"></asp:GridView>
        <cc1:rssdatasource id="RssDataSource1" runat="server" url="http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml" MaxItems="2"></cc1:rssdatasource>
    </div>
    <div>
        <h2>Consuming ATOM feed using RssDataSource</h2>    
        <asp:GridView runat="Server" Id="GridView1" DataSourceID="RssDataSource2"></asp:GridView>
        <cc1:rssdatasource id="RssDataSource2" runat="server" url="http://news.google.com/?output=atom" MaxItems="2"></cc1:rssdatasource>
    </div>
   </asp:Content>