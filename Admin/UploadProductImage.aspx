<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadProductImage.aspx.cs" Inherits="Admin_UploadProductImage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" style="width: 600px">
        <tr>
            <td>
            </td>
            <td>
                <asp:FileUpload ID="fUpload" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                File Name on Server&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 34px">
            </td>
            <td style="height: 34px">
                <asp:Button ID="btnUploadPImage" runat="server" BackColor="Yellow" Height="29px"
                    Text="Upload Product Image" Width="182px" OnClick="btnUploadPImage_Click" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblStatus" runat="server" Width="284px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

