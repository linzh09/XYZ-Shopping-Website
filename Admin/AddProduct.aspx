<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Admin_AddProduct" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="WIDTH: 769px; HEIGHT: 250px; BACKGROUND-COLOR: #FFFFFF; overflow-y:scroll; SCROLLBAR-FACE-COLOR: #c2d3fc; SCROLLBAR-HIGHLIGHT-COLOR: #c2d3fc; SCROLLBAR-SHADOW-COLOR: BLACK; SCROLLBAR-3DLIGHT-COLOR: #c2d3fc; SCROLLBAR-ARROW-COLOR:#000000; SCROLLBAR-TRACK-COLOR: FFFFFF; SCROLLBAR-DARKSHADOW-COLOR: EAECEC">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="80%">
        <tr>
            <td align="center" colspan="2">
                <font color="#000099" size="4" style="background-color: #ffffcc"><strong>New Product
                    Specs - By Admins Only</strong></font></td>
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
                Category &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="176px">
                </asp:DropDownList></td>
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
                <asp:TextBox ID="txtPrice" runat="server" Width="88px"></asp:TextBox>&nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                Image File Name&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtImageFile" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                In Stock&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="chkInStock" runat="server" />
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                Inventory</td>
            <td>
                <asp:TextBox ID="txtInventory" runat="server" Width="88px"></asp:TextBox>&nbsp;
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Incorrect Inventory"
                    MaximumValue="1000" MinimumValue="1" Type="Integer" ControlToValidate="txtInventory"></asp:RangeValidator></td>
        </tr>
        <tr>
            <td>
                <input style="width: 80px; height: 24px" type="reset" value="Reset" /></td>
            <td align="middle">
                <asp:Button ID="btnAddProduct" runat="server" BackColor="Yellow" OnClick="btnAddProduct_Click"
                    Text="Add Product" Width="110px" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblStatus" runat="server" Height="23px" Width="373px"></asp:Label></td>
        </tr>
    </table>
    </div>
</asp:Content>

