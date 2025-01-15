<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueCreate.aspx.cs" Inherits="IssueTracker.WebUI.Pages.IssueCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="issue-model">
                <div class="issue-model-header">
                    <div class="issue-model-header__left">
                        <div class="issue-model-header__left-icon"><i class="fa mr-5 fa-pencil"></i>Add Epic</div>
                        <div class="issue-model-header__seperator"></div>
                        <div class="issue-model-header__left-icon"><i class="fa mr-5 fa-pencil"></i>Add Story</div>
                        <div class="issue-model-header__seperator"></div>
                        <div class="issue-model-header__left-icon"><i class="fa mr-5 fa-check-square text-info"></i>PROJ-1</div>
                    </div>
                    <div class="issue-model-header__right">
                        <div class="issue-model-header__right-icon mi-10"><i class="fa fa-times"></i></div>
                        <div class="issue-model-header__right-icon mi-10"><i class="fa fa-ellipsis"></i></div>
                        <div class="issue-model-header__right-icon mi-10"><i class="fa fa-share-nodes"></i></div>
                        <div class="issue-model-header__right-icon mi-10"><i class="fa fa-star"></i></div>
                        <div class="issue-model-header__right-icon mi-10"><i class="fa mr-5 fa-eye"></i>1</div>
                        <div class="issue-model-header__right-icon mi-10"><i class="fa fa-lock-open"></i></div>
                    </div>
                </div>
                <div class="issue-model-header-section">
                    <h3>Task Title</h3>
                    <button><i class="fa mr-5 fa-paperclip"></i>Attach</button>
                    <button><i class="fa mr-5 fa-circle-nodes"></i>Attach a child issue</button>
                    <button><i class="fa mr-5 fa-link"></i>Link issue</button>
                </div>
                <div class="issue-model-detail-section">
                </div>
                <div class="issue-model-footer">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
