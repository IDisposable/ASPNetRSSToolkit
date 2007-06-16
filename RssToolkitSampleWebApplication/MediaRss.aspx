<%@ Page Language="C#"  %>

<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Youtube Media Rss</title>

    <script language="c#" runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            YouTubeRss rss = YouTubeRss.Load();
            DataList1.DataSource = rss.Channel.Items;
            DataList1.DataBind();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        You Tube Top Favories(Media Rss)
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" GridLines="both">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="Server" ImageUrl='<%# Eval("Thumbnail.Url")  %>' /><br />
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("Player.Url") %>' Text='Link' runat="server" />
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>
