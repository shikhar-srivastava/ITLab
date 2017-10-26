<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_Validate.aspx.cs" Inherits="Manager_Validate"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div style="width: 600px; margin: 100px auto 200px; padding: 15px;">
        <div class="card">
            <asp:Label ID="msg" runat="server" Text=""></asp:Label><br />
            Passcode: <asp:Textbox ID="passcode" runat="server"></asp:Textbox>
            <asp:CustomValidator ControlToValidate="passcode" ID="CustomValidator1" runat="server" ErrorMessage="Passcode should contain digits only!" ForeColor="Red"
                ValidateEmptyText="false" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <asp:Button ID="submit" runat="server" Text="Submit" onclick="submit_Click" PostBackUrl="~/Manager.aspx"/>
        </div>
    </div>
</asp:Content>
