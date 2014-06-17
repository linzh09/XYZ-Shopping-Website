<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="80%">
        <tr>
            <td align="center" colspan="2">
                <font color="#000099" size="4" style="background-color: #ffffcc"><strong>Product Modification
                    - By Admins Only</strong></font></td>
        </tr>
        <tr>
            <td align="right">
                Product ID&nbsp;
            </td>
            <td>
                <asp:Label ID="lblProductID" runat="server" Width="64px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                Category&nbsp;
            </td>
            <td>
                <asp:Label ID="lblCategory" runat="server" Width="232px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                Short Description&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtShortDesc" runat="server" Width="319px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Long Description&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtLongDesc" runat="server" Height="104px" MaxLength="50" Rows="5"
                    TextMode="MultiLine" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Price&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="88px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Image File Name&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtImageFile" runat="server"></asp:TextBox>
                <asp:Image ID="imgProduct" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                In Stock&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="chkInStock" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                Inventory&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtInventory" runat="server" Width="88px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCancel" runat="server" BackColor="Red" ForeColor="Yellow" Text="Cancel"
                    Width="110px" /></td>
            <td align="middle">
                <asp:Button ID="btnUpdate" runat="server" BackColor="Yellow" OnClick="btnUpdate_Click"
                    Text="Update" Width="99px" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblStatus" runat="server" Height="32px" Width="312px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

