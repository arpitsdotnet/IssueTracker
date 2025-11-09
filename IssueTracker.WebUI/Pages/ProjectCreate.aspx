<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectCreate.aspx.cs" Inherits="IssueTracker.WebUI.Pages.ProjectCreate" %>

<%@ Register Src="~/UserControls/TextboxControl.ascx" TagPrefix="uc" TagName="TextboxControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="jumbotron">
                <h2>Add project details</h2>
                <div class="row">
                    <div class="col-md-6">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label ID="Lbl_ProjectTitle" runat="server" Text="Name *"></asp:Label>
                                    <div>
                                        <asp:TextBox ID="Txt_ProjectTitle" runat="server" CssClass="form-control text-capitalize" OnTextChanged="Txt_ProjectTitle_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <small>Try a team name, project goal or milestones.</small>
                                    </div>
                                </div>
                                <uc:TextboxControl runat="server" ID="Txt_ProjectKey" IsRequired="true" LabelText="Key" CssClass="text-uppercase" ></uc:TextboxControl>                                
                                <div class="form-group">
                                    <asp:Label ID="Lbl_ProjectCategory" runat="server" Text="Category *"></asp:Label>
                                    <div>
                                        <asp:DropDownList ID="Ddl_ProjectCategory" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Txt_ProjectTitle" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div>
                                <asp:Label ID="Lbl_ProjectTemplate" runat="server" Text="Template *"></asp:Label>
                            </div>
                            <div>
                                <asp:RadioButtonList ID="Rbl_ProjectTemplate" runat="server" RepeatDirection="Horizontal" CssClass="easy-radio">
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div>
                                <asp:Label ID="Lbl_ProjectType" runat="server" Text="Type *"></asp:Label>
                            </div>
                            <div>
                                <asp:RadioButtonList ID="Rbl_ProjectType" runat="server" RepeatDirection="Horizontal" CssClass="easy-radio">
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 text-right">
                    <div class="form-group">
                        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
