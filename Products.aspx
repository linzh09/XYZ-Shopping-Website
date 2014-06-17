<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblProducts" runat="server" BackColor="#FFFFC0"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblStatus" runat="server" Width="271px"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Small">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <Columns>
                        <asp:BoundField DataField="ProductSDesc" HeaderText="Product Description" />
                        <asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="ProductDisplay.aspx?PID={0}"
                            HeaderText="Product Detail" Text="detail" />
                        <asp:ImageField DataImageUrlField="ProductImage" DataImageUrlFormatString="~/PImages/{0}"
                            HeaderText="Product Picture">
                        </asp:ImageField>
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <AlternatingRowStyle BackColor="#FFFF80" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

