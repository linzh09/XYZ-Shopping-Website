<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" Title="Untitled Page" %>

<%@ Register Src="ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="90%">
        <tr>
            <td>
                <uc1:ShoppingCart ID="ShoppingCart1" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCheckOut" runat="server" BackColor="#80FF80" BorderColor="Blue"
                    Text="Check Out" Width="128px" OnClick="btnCheckOut_Click" /></td>
            <td>
                <asp:Button ID="btnContinueShopping" runat="server" BackColor="#FFFF80" BorderColor="Red"
                    Text="Continue Shopping" Width="163px" OnClick="btnContinueShopping_Click" /></td>
        </tr>
    </table>
</asp:Content>

