<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCustomerReg.aspx.cs" Inherits="NewCustomerReg" Title="Untitled Page" %>
<%@ Register TagPrefix="EveCC" Namespace="CCValidator" Assembly="CCValidator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="middle" colspan="3">
                <asp:Label ID="lblStatus" runat="server" Width="338px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                First Name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                Last Name</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Last name cannot be empty" Width="259px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Address</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" BackColor="#FFFFC0" Width="216px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Address  cannot be empty" Width="281px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" BackColor="#FFFFC0" Width="80px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="City  cannot be empty" Width="192px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                State</td>
            <td>
                <asp:TextBox ID="txtState" runat="server" BackColor="#FFFFC0" Width="80px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtState"
                    ErrorMessage="RequiredFieldValidator" Width="192px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Zipcode</td>
            <td>
                <asp:TextBox ID="txtZipcode" runat="server" BackColor="#FFFFC0" Width="80px"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtZipcode"
                    ErrorMessage="invalid zipcode" ValidationExpression="\d{5}(-\d{4})?" Width="192px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right">
                Email Address</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" BackColor="#FFFFC0" Width="168px"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="invalid email address" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    Width="200px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right">
                Credit Card Number</td>
            <td>
                <asp:TextBox ID="txtCCNumber" runat="server" BackColor="#FFFFC0" Width="168px"></asp:TextBox></td>
            <td><EVECC:CCVALIDATE id="MyCCValidator" ErrorMessage="Please enter a valid credit card number" ControlToValidate="txtCCNumber"
											RunAt="server" ValidateCardType="True" AcceptedCreditCardTypes="VISA, MASTERCARD"></EVECC:CCVALIDATE>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 7px">
                Credit Card Type</td>
            <td style="height: 7px">
                <asp:DropDownList ID="ddlCCType" runat="server" BackColor="#FFFFC0" Width="136px">
                    <asp:ListItem Value="VISA">Visa</asp:ListItem>
                    <asp:ListItem Value="MASTERCARD">MasterCard</asp:ListItem>
                    <asp:ListItem Value="AMERICANEXPRESS">AmericanExpress</asp:ListItem>
                    <asp:ListItem Value="DISCOVER">Discover</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td align="right">
                Credit Card Expiration</td>
            <td>
                <asp:TextBox ID="txtCCExpiration" runat="server" BackColor="#FFFFC0" Width="64px"></asp:TextBox>
                (mm/yy)</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCCExpiration"
                    ErrorMessage="expiration cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Username cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Password</td>
            <td>
                <asp:TextBox ID="txtPW" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPW"
                    ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirmPW" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPW"
                    ControlToValidate="txtConfirmPW" ErrorMessage="passwords are not identical" Width="210px"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td align="right">
                Password Hint Question</td>
            <td>
                <asp:TextBox ID="txtPWHintQ" runat="server" BackColor="#FFFFC0" Width="216px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPWHintQ"
                    ErrorMessage="password hint cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Password Hint Answer</td>
            <td>
                <asp:TextBox ID="txtPWHintA" runat="server" BackColor="#FFFFC0" Width="112px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPWHintA"
                    ErrorMessage="password hint answer cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td>
                <asp:Button ID="btnRegister" runat="server" BackColor="Blue" BorderColor="Red" BorderWidth="1px"
                    ForeColor="Yellow" Text="Register" Width="112px" OnClick="btnRegister_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
            <td>
                <input style="width: 96px; height: 24px" type="reset" value="Reset" /></td>
        </tr>
    </table>
</asp:Content>

