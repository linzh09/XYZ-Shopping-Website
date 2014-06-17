<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmCheckout.aspx.cs" Inherits="ConfirmCheckout" Title="Untitled Page" %>
<%@ Register TagPrefix="EveCC" Namespace="CCValidator" Assembly="CCValidator" %>
<%@ Register Src="ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="95%">
        <tr>
            <td align="middle" colspan="2" style="height: 21px">
                <font color="#000099" size="4" style="background-color: #ffff66"><strong>Final Checkout
                    Summary</strong></font></td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="2">
                <uc1:ShoppingCart ID="ShoppingCart1" runat="server" />
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="2">
                <font color="#990066" size="4"><span style="color: #cc0000"><span>Please update the following
                    shipping and credit card information, if it is differen</span>t.</span></font></td>
        </tr>
        <tr>
            <td align="right">
                First Name:&nbsp;
            </td>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Width="168px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                Last Name:&nbsp;
            </td>
            <td>
                <asp:Label ID="lblLastName" runat="server" Width="168px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                Address</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="267px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <p align="right">
                    City</p>
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" Width="108px"></asp:TextBox>
                &nbsp;&nbsp; State
                <asp:TextBox ID="txtState" runat="server" Width="37px"></asp:TextBox>
                &nbsp; &nbsp; &nbsp;&nbsp; Zip Code
                <asp:TextBox ID="txtZipcode" runat="server" Width="56px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="184px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Credit Card Number</td>
            <td>
                <asp:TextBox ID="txtCCNumber" runat="server" Width="160px"></asp:TextBox>
                <EveCC:CCValidate ID="MyCCValidator" runat="server" AcceptedCreditCardTypes="VISA, MASTERCARD"
                    ControlToValidate="txtCCNumber" ErrorMessage="Please enter a valid credit card number"
                    ValidateCardType="True"></EveCC:CCValidate></td>
        </tr>
        <tr>
            <td align="right" style="height: 8px">
                Credit Card Type</td>
            <td style="height: 8px">
                <asp:DropDownList ID="ddlCCType" runat="server">
                    <asp:ListItem Value="VISA">Visa</asp:ListItem>
                    <asp:ListItem Value="MASTERCARD">MasterCard</asp:ListItem>
                    <asp:ListItem Value="AMERICANEXPRESS">AmericanExpress</asp:ListItem>
                    <asp:ListItem Value="DISCOVER">Discover</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">
                Expiration Date</td>
            <td>
                <asp:TextBox ID="txtExpiration" runat="server" Width="104px"></asp:TextBox>&nbsp;
                (mm/yy)</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnUpdateInfo" runat="server" BackColor="Yellow" Text="Update Info"
                    Width="98px" OnClick="btnUpdateInfo_Click" /></td>
            <td align="right">
                <asp:Button ID="btnConfirmCheckOut" runat="server" BackColor="Blue" Text="Confirm Check Out"
                    Width="158px" ForeColor="Yellow" OnClick="btnConfirmCheckOut_Click" /></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Width="353px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

