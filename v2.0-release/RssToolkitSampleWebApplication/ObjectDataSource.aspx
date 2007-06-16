<%@ Page Language="c#" MasterPageFile="~/MasterPage.master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="Server">
    <div>
        <h2>Consuming RSS feed using ObjectDataSource</h2>    
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataSourceID="ObjectDataSource1"
            ForeColor="#333333">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("link") %>' Text='<%# Eval("title") %>'></asp:HyperLink>
            </ItemTemplate>
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#E3EAEB" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        </asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="LoadRssItems"
            TypeName="MSNBCRss"></asp:ObjectDataSource>
    </div>
</asp:Content>