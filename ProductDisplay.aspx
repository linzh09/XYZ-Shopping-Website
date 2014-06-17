<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDisplay.aspx.cs" Inherits="ProductDisplay" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" style="height: 123px"
        width="800">
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblProdDesc" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Purple"
                    Width="427px"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblPrice" runat="server" Width="256px">Label</asp:Label></td>
        </tr>
        <tr>
            <td align="left">
                <img src='PImages/<%=ds.Tables[0].Rows[0]["ProductImage"].ToString()%>' /></td>
 			<TD><%=ds.Tables[0].Rows[0]["ProductLDesc"].ToString()%></TD>
         </tr>
        <tr>
            <td align="right" colspan="2">
                <hr color="#0000cc" size="3" width="100%" />
            </td>
        </tr>
        <tr>
            <td align="right">
                Please Enter Quantity</td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server" Width="77px">1</asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddToCart" runat="server"  Text="Add To Cart" Width="144px" 
                    OnClick="btnAddToCart_Click" SkinID="mainSkin" />
                &nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblAddToCart" runat="server" Width="393px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 19px">
            </td>
            <td align="left" colspan="2" style="height: 19px">
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" colspan="2">
                <asp:Button ID="btnViewCart" runat="server" BackColor="Yellow" BorderColor="#8080FF"
                    Text="View Cart" Width="146px" OnClick="btnViewCart_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnContinueShopping" runat="server" BackColor="#80FF80" Text="Continue Shopping"
                    Width="169px" OnClick="btnContinueShopping_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" colspan="2">
                <asp:Label ID="lblStatus" runat="server" Width="335px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

