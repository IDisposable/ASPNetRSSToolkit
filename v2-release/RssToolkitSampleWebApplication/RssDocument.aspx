<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>
<script language="c#" runat="server">
    
 void Page_Load(object sender, EventArgs e)
 {
    RssToolkit.Rss.RssDocument rss = RssToolkit.Rss.RssDocument.Load(new System.Uri("http://rss.msnbc.msn.com/id/3032091/device/rss/rss.xml"));
    Image1.ImageUrl = rss.Channel.Image.Url;
    GridView1.DataSource = rss.SelectItems();
    GridView1.DataBind();
 }
</script>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <h2>Consuming RSS feed programmatically using RssDocument</h2>
            <asp:Image ID="Image1" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
   
</asp:Content>