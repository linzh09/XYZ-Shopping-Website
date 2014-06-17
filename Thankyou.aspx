<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thankyou.aspx.cs" Inherits="Thankyou" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="1" cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblSummary" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnContinueShopping" runat="server" BackColor="#C0FFFF" Text="Continue Shopping" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnLogout" runat="server" BackColor="Yellow" Text="Logout" Width="70px" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblStatus" runat="server" Width="299px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

