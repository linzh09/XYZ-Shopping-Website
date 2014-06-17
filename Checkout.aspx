<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="65%">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Height="72px" Width="374px"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlLogin" runat="server" Width="80%">
                    Login
                    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="90%">
                        <tr>
                            <td colspan="2">
                                <hr color="#0000ff" size="3" width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong><font color="#000099" style="background-color: #ffff66">Existing Customers</font></strong>:
                                Please Login</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Username&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                Password&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtPW" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnLogin" runat="server" BackColor="#FFFF80" BorderColor="Red" BorderWidth="1px"
                                    OnClick="btnLogin_Click" Text="Login" Width="107px" /></td>
                            <td align="right">
                                <input style="width: 104px; height: 24px" type="reset" value="Reset" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="bottom" style="height: 67px">
                                <hr color="#0000ff" size="3" width="100%" />
                                &nbsp;
                                <asp:Label ID="lblStatus" runat="server" Height="73px" Width="392px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong><font color="#006600" style="background-color: #ccffff">New Customers</font></strong>:
                                please
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="NewCustomerReg.aspx">Click here</asp:HyperLink>
                                to Register.</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

