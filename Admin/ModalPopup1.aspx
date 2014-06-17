<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModalPopup1.aspx.cs" Inherits="Admin_ModalPopup1" Title="Untitled Page" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function onOK() {
        pid = $get('<%=txtProductID.ClientID%>').value;
        passw = $get('<%=txtPassword.ClientID%>').value;
        Productservice.UpdatePrice(pid, passw, myCallBack);
    }

    function myCallBack(res) {
        $get('<%=lblStatus.ClientID%>').innerText = res;
        $get('<%=TextBox1.ClientID%>').value = res;
        $get('<%=txtPassword.ClientID%>').value = "";
    }
</script>
<table class="style2">
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text=""/> 
            </td>
        </tr>
        <tr>
        <td>
            <!-- style=display:none still allows you to postback where
 			as visible=false causes AJAX postback errors -->
            <asp:LinkButton ID="btnFinalUpdate" runat="server" style="display:none" />
            Product ID  :<asp:TextBox ID="txtProductID" Text="" runat="server"/>
            <asp:Button ID="btnUpdatePrice" runat="server" Text="Delete Product" 
                onclick="btnUpdatePrice_Click1" SkinID="mainSkin" />
        </td>
        </tr>
        <tr>
            <td>
             <asp:Panel ID="panConfirm" runat="server" Style="display: none" CssClass="modalPopup">
            <asp:Panel ID="Panel3" runat="server" 
            Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black">
                <div>
                    <p>Confirm delete product :</p>
                </div>
            </asp:Panel>
                <div>
                     <p>
                        Enter Password : 
                         <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>                    </p>
                    <p style="text-align: center;">
                        <asp:Button ID="OkButton" runat="server" Text="OK" />
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                    </p>
                </div>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" 
            TargetControlID="btnUpdatePrice"
            PopupControlID="panConfirm" 
            BackgroundCssClass="modalBackground"
            OkControlID="OkButton"
            OnOkScript="onOK()"
            CancelControlID="CancelButton" 
            DropShadow="true"
            PopupDragHandleControlID="Panel3" />
                <asp:TextBox ID="TextBox1" runat="server" Width="253px" BorderStyle = "None" Appearance = "Flat"></asp:TextBox>
        <br />
              </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

