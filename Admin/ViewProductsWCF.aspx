<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProductsWCF.aspx.cs" Inherits="Admin_ViewProductsWCF" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="1" cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblStatus" runat="server" Width="267px"></asp:Label>
                <asp:Button ID="btnLogoff" runat="server" BackColor="GreenYellow" BorderColor="Red"
                    OnClick="btnLogoff_Click" Text="Admin Logout" Width="109px" /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnPageIndexChanging="gv1_PageIndexChanging" PageSize="3">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <AlternatingRowStyle BackColor="#FFFFC0" />
                    <Columns>
                        <asp:TemplateField HeaderText="Edit Product">
                            <ItemTemplate>
                                <a href='EditProduct.aspx?PID=<%# Eval("ProductID") %>'>Edit </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Image">
                            <ItemTemplate>
                                <img src='../PImages/<%# Eval("ProductImage") %>'>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductLDesc" HeaderText="Product Description" />
                        <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="Price" />
                        <asp:BoundField DataField="Inventory" HeaderText="Inventory" />
                        <asp:BoundField DataField="ProductSDesc" HeaderText="Product Name" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

