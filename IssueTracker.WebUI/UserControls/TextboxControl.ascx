<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextboxControl.ascx.cs" Inherits="IssueTracker.WebUI.UserControls.TextboxControl" %>
<div class="form-group">
    <asp:Label ID="Lbl" runat="server" Text="Key"></asp:Label><span id="M_Req" runat="server">*</span>
    <div>
        <asp:TextBox ID="Txt" runat="server"></asp:TextBox>
    </div>
</div>