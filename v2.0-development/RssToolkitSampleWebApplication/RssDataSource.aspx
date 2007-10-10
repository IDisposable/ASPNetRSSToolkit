<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="art" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <div>
        <h2>Consuming RSS feed using RssDataSource</h2>    
        <asp:GridView runat="Server" Id="GridView1" DataSourceID="RssDataSource1"></asp:GridView>
        <art:RssDataSource id="RssDataSource1" runat="server" url="http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml" MaxItems="2" />
    </div>
    <div>
        <h2>Consuming ATOM feed using RssDataSource</h2>    
        <asp:GridView runat="Server" Id="GridView2" DataSourceID="RssDataSource2"></asp:GridView>
        <art:RssDataSource id="RssDataSource2" runat="server" url="http://news.google.com/?output=atom" MaxItems="2" />
    </div>
        <div>
        <h2>Consuming feed that has lots of CDATA</h2>    
        <asp:GridView runat="Server" Id="GridView3" DataSourceID="RssDataSource3" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="link" DataNavigateUrlFormatString="{0}"
                    DataTextField="title" HeaderText="Title" />
                <asp:BoundField DataField="description" HeaderText="Description" HtmlEncode="False"
                    InsertVisible="False" ReadOnly="True" SortExpression="description" />
            </Columns>
        </asp:GridView>
        <art:RssDataSource id="RssDataSource3" runat="server" url="http://news.baidu.com/ns?word=good&tn=newsrss&sr=0&cl=2&rn=20&ct=0" MaxItems="3" />
    </div>
   </asp:Content>