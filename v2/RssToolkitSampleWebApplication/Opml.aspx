<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
<script language="c#" runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        RssToolkit.Rss.RssDocument rss = RssToolkit.Rss.RssDocument.Load(new System.Uri("http://static2.podcatch.com/blogs/gems/opml/mySubscriptions.opml"));
        GridView1.DataSource = rss.SelectItems();
        GridView1.DataBind();
    }
</script>
    <h2>Using OPML Files to aggregate and produce one feed</h2>

    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PageIndex="10" Width="700px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
    </div>
</asp:Content>