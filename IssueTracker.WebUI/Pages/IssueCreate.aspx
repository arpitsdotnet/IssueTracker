<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueCreate.aspx.cs" Inherits="IssueTracker.WebUI.Pages.IssueCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="divIssueModel" class="issue-model">
                <div class="im__header">
                    <div class="imh__left">
                        <div class="imhl__icon"><i class="fa mr-5 fa-pencil"></i>Add Epic</div>
                        <div class="imhl__seperator"></div>
                        <div class="imhl__icon"><i class="fa mr-5 fa-pencil"></i>Add Story</div>
                        <div class="imhl__seperator"></div>
                        <div class="imhl__icon"><i class="fa mr-5 fa-check-square text-info"></i>PROJ-1</div>
                    </div>
                    <div class="imh__right">
                        <div class="imhr__icon"><i class="fa fa-times"></i></div>
                        <div class="imhr__icon imhri__expand" onclick="goFullScreen('divIssueModel');"><i class="fa fa-expand"></i></div>
                        <div class="imhr__icon imhri__compress" onclick="exitFullScreen();"><i class="fa fa-compress"></i></div>
                        <div class="imhr__icon"><i class="fa fa-share-nodes"></i></div>
                        <div class="imhr__icon"><i class="fa-regular fa-star"></i></div>
                        <div class="imhr__icon"><i class="fa mr-5 fa-eye"></i>1</div>
                    </div>
                </div>
                <div class="im__content">
                    <div class="imc__left">
                        <div class="imcl__title">
                            <h3>Task Title</h3>
                            <button><i class="fa mr-5 fa-paperclip"></i>Attach</button>
                            <button><i class="fa mr-5 fa-circle-nodes"></i>Attach a child issue</button>
                            <button><i class="fa mr-5 fa-link"></i>Link issue</button>
                        </div>
                        <div class="imcl_detail">
                            <div class="form-group">
                                <label for="description">Description</label>
                                <textarea id="description" name="description" placeholder="Add a description..."></textarea>
                            </div>
                            <div>
                                <h4>Activity</h4>
                                <button type="button"><i class="fa-regular fa-comment"></i>Comments</button>
                                <button type="button"><i class="fa fa-history"></i>History</button>
                            </div>
                            <div class="form-group">
                                <label for="comment">Add a comment</label>
                                <textarea id="comment" name="comment" placeholder="Add a comment..."></textarea>
                                <p>Pro tip: press <strong>M</strong> to comment</p>
                            </div>
                        </div>
                    </div>
                    <div class="imc__right">
                        <div class="imcr_status">
                            To Do 
                        </div>
                        <div class="imcr_detail">
                            <h4>Details</h4>
                            <div>
                                <label for="assignee">Assignee</label>
                                <input type="text" id="assignee" name="assignee" value="kepegox194" readonly>
                            </div>
                            <div>
                                <label for="labels">Labels</label>
                                <select id="labels" name="labels">
                                    <option value="VoiceOver">VoiceOver</option>
                                </select>
                            </div>
                            <div>
                                <label for="reporter">Reporter</label>
                                <input type="text" id="reporter" name="reporter" value="VoiceOver" readonly>
                            </div>
                        </div>
                        <div class="imcr_footer">
                            <p>Created 1 minute ago</p>
                            <p>Updated 1 minute ago</p>
                        </div>
                    </div>
                </div>
                <div class="im__footer">
                    <button><i class="fa mr-5 fa-eraser"></i>Clear</button>
                    <button><i class="fa mr-5 fa-save"></i>Save</button>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
