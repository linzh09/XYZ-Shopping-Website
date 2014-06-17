<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Login1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="3" cellspacing="5" width="600">
        <tr>
            <td align="middle" bordercolorlight="#339900">
                <hr color="blue" designtimedragdrop="111" size="2" width="100%" />
            </td>
        </tr>
        <tr>
            <td align="middle" bordercolorlight="#339900">
                <font color="#000099" size="5"><strong><font color="darkviolet"><font size="4">Please
                    Login To Access Admin Pages</font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </font>&nbsp;</strong></font></td>
        </tr>
        <tr>
            <td align="center">
                <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Height="23px" Width="114px">User Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Height="20px" Width="141px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="User name is required" Height="21px" Width="198px"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Height="28px" Width="108px">Password:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" Height="20px" TextMode="Password" Width="141px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                                ErrorMessage="Password is required" Height="20px" Width="199px"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                    <asp:Button ID="btnLogin" runat="server" BackColor="#FFFF80" BorderColor="Blue" BorderWidth="1px"
                        ForeColor="#0000C0" Height="28px" Text="Login" Width="143px" OnClick="btnLogin_Click" /></td>
        </tr>
        <tr>
            <td>
                <p align="center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Height="25px" Visible="False"
                        Width="349px">Invalid Login, try again.</asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </p>
            </td>
        </tr>
        <tr>
            <td>
                <hr color="blue" size="2" width="100%" />
                <p align="center">
                    </p>
            </td>
        </tr>
        <tr>
            <td>
                <p align="center">
                </p>
            </td>
        </tr>
    </table>
</asp:Content>

