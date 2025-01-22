<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueCreate.aspx.cs" Inherits="IssueTracker.WebUI.Pages.IssueCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h3>Create Issue</h3>
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Project<span class="required"></span></label>
                            <asp:DropDownList ID="Ddl_Projects" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Issue Type<span class="required"></span></label>
                            <asp:DropDownList ID="Ddl_IssueTypes" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Epic" />
                                <asp:ListItem Text="Story" />
                                <asp:ListItem Text="Task" Selected="True" />
                                <asp:ListItem Text="Sub-Task" />
                                <asp:ListItem Text="Bug" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Priority<span class="required"></span></label>
                            <div>
                                <asp:RadioButtonList ID="Ddl_ProjectTemplate" runat="server" RepeatDirection="Horizontal" CssClass="easy-radio small">
                                    <asp:ListItem Value="H"><i class="fa fa-arrow-up"></i></asp:ListItem>
                                    <asp:ListItem Value="M" Selected="True"><i class="fa fa-circle-dot"></i></asp:ListItem>
                                    <asp:ListItem Value="L"><i class="fa fa-arrow-down"></i></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="Project">Summary<span class="required"></span></label>
                            <asp:TextBox ID="Txt_IssueSummary" runat="server" CssClass="form-control" placeholder="Summary"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Epic Links<span class="not-required"></span></label>
                            <asp:DropDownList ID="Ddl_EpicLinks" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select Epic-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Story Links<span class="not-required"></span></label>
                            <asp:DropDownList ID="Ddl_StoryLinks" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select Story-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Start Date<span class="required"></span></label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select date-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Due Date<span class="not-required"></span></label>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select date-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="Project">Description<span class="not-required"></span></label>
                            <asp:TextBox ID="Txt_Description" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Description"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Reporter<span class="required"></span></label>
                            <asp:DropDownList ID="Ddl_Reporters" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select Reporter-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Project">Assignee<span class="not-required"></span></label>
                            <asp:DropDownList ID="Ddl_Assignees" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select Assignee-" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-right">
                        <asp:Button ID="Btn_Clear" runat="server" CssClass="btn btn-default" Text="Clear" OnClick="Btn_Clear_Click"/>
                        <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="Btn_Submit_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
