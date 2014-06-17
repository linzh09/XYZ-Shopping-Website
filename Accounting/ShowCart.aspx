<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowCart.aspx.cs" Inherits="Accounting_ShowCart" Title="Untitled Page" %>

<%@ Register Src="../ShoppingCart.ascx" TagName="MYUSERCTL" TagPrefix="PQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="90%">
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <PQR:MYUSERCTL ID="ShoppingCart1" runat="server" />
            </td>
            
            <td>
               <PQR:MYUSERCTL ID="ShoppingCart2" runat="server" />
  
            </td>
        </tr>
    </table>
</asp:Content>

