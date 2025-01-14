<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectCreate.aspx.cs" Inherits="IssueTracker.WebUI.Pages.ProjectCreate" %>

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
                                    <div>
                                        <asp:Label ID="Lbl_ProjectTitle" runat="server" Text="Name *"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="Txt_ProjectTitle" runat="server" CssClass="form-control" OnTextChanged="Txt_ProjectTitle_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <small>Try a team name, project goal or milestones.</small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div>
                                        <asp:Label ID="Lbl_ProjectKey" runat="server" Text="Key *"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="Txt_ProjectKey" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div>
                                        <asp:Label ID="Lbl_ProjectCategory" runat="server" Text="Category *"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:DropDownList ID="Ddl_ProjectCategory" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Software Management" Value="1" Selected="True" />
                                            <asp:ListItem Text="Service Management" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div>
                                <asp:Label ID="Lbl_ProjectTemplate" runat="server" Text="Template *"></asp:Label>
                            </div>
                            <div>
                                <asp:RadioButtonList ID="Ddl_ProjectTemplate" runat="server" RepeatDirection="Horizontal" CssClass="easy-radio">
                                    <asp:ListItem Text="Scrum" Value="SCRUM" Selected="True" />
                                    <asp:ListItem Text="Kanban" Value="KANBAN" />
                                    <asp:ListItem Text="Bug Tracking" Value="BUGTRKNG" />
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div>
                                <asp:Label ID="Lbl_ProjectType" runat="server" Text="Type *"></asp:Label>
                            </div>
                            <div>
                                <asp:RadioButtonList ID="Rbl_ProjectType" runat="server" RepeatDirection="Horizontal" CssClass="easy-radio">
                                    <asp:ListItem Text="Team-Managed" Value="TEAM" Selected="True" />
                                    <asp:ListItem Text="Company-Managed" Value="COMPANY" />
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
