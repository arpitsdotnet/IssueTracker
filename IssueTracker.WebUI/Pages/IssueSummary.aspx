<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueSummary.aspx.cs" Inherits="IssueTracker.WebUI.Pages.IssueSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divIssueModel" class="issue-model">
                <div class="im__header">
                    <div class="imh__left">
                        <div class="imhl__icon"><i class="fa fa-pencil mr-5"></i>Add Epic</div>
                        <div class="imhl__seperator"></div>
                        <div class="imhl__icon"><i class="fa fa-pencil mr-5"></i>Add Story</div>
                        <div class="imhl__seperator"></div>
                        <div class="imhl__icon"><i class="fa fa-check-square mr-5 text-info"></i>PROJ-1</div>
                    </div>
                    <div class="imh__right">
                        <div class="imhr__icon" title="Close"><i class="fa fa-times"></i></div>
                        <div class="imhr__icon imhri__expand" title="Expand"><i class="fa fa-expand"></i></div>
                        <div class="imhr__icon imhri__compress" title="Collapse"><i class="fa fa-compress"></i></div>
                        <div class="imhr__icon" title="Print"><i class="fa fa-print"></i></div>
                        <div class="imhr__icon" title="Share"><i class="fa fa-share-nodes"></i></div>
                        <div class="imhr__icon" title="Favorite"><i class="fa-regular fa-star"></i></div>
                        <div class="imhr__icon" title="Watch"><i class="fa fa-eye mr-5"></i>1300</div>
                    </div>
                </div>
                <div class="im__content">
                    <div class="imc__left">
                        <div class="imcl__title">
                            <div class="form-group">
                                <asp:TextBox ID="Txt_Title" runat="server" CssClass="form-control w100p display-3" placeholder="Add a story, topic, or task..." Text="Amortization Create Page"></asp:TextBox>
                            </div>
                            <div>
                                <button><i class="fa fa-paperclip mr-5"></i>Attach</button>
                                <button><i class="fa fa-circle-nodes mr-5"></i>Attach a child issue</button>
                                <button><i class="fa fa-link mr-5"></i>Link issue</button>
                            </div>
                        </div>
                        <div class="imcl__detail">
                            <div class="form-group">
                                <div>
                                    <label for="description">Description</label>
                                </div>
                                <asp:TextBox ID="Txt_Description" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Add a description..."></asp:TextBox>
                            </div>
                            <div class="imfl__section">
                                <div class="form-group">
                                    <div>
                                        <label for="comment" class="pr-10">Add a comment</label><small class="text-grey">(press <kbd>ctrl + ↩</kbd> to submit)</small>
                                    </div>
                                    <asp:TextBox ID="Txt_Comment" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Add a comment..."></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <label for="activity">Activity </label>                                
                                <button type="button"><i class="fa-regular fa-comment mr-5"></i>Comments</button>
                                <button type="button"><i class="fa fa-history mr-5"></i>History</button>
                            </div>
                        </div>
                    </div>
                    <div class="imc__right">
                        <div class="imcr__status">
                            <div class="form-group">
                                <asp:DropDownList ID="Ddl_IssueStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Pending" Value="0" />
                                    <asp:ListItem Text="In Progress" Value="0" />
                                    <asp:ListItem Text="At Risk" Value="0" />
                                    <asp:ListItem Text="Under Discussion" Value="0" />
                                    <asp:ListItem Text="No Change" Value="0" />
                                    <asp:ListItem Text="Blocked" Value="0" />
                                    <asp:ListItem Text="Closed" Value="0" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="Ddl_IssuePriority" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="High" Value="0" />
                                    <asp:ListItem Text="Medium" Value="0" />
                                    <asp:ListItem Text="Low" Value="0" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="imcr__detail">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="show" data-parent="#accordion" href="#collapse1">Details</a>
                                        </h4>
                                    </div>
                                    <div id="collapse1" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <div>
                                                <div>
                                                    <label for="assignee">Assignee</label>
                                                </div>
                                                <div>
                                                    <input type="text" id="assignee" name="assignee" value="kepegox194" readonly="readonly" />
                                                </div>
                                            </div>
                                            <div>
                                                <div>
                                                    <label for="reporter">Reporter</label>
                                                </div>
                                                <div>
                                                    <input type="text" id="reporter" name="reporter" value="VoiceOver" readonly="readonly" />
                                                </div>
                                            </div>
                                            <div>
                                                <div>
                                                    <label for="labels">Labels</label>
                                                </div>
                                                <div>
                                                    <select id="labels" name="labels">
                                                        <option value="VoiceOver">VoiceOver</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="hide" data-parent="#accordion" href="#collapse2">More Fields</a>
                                        </h4>
                                    </div>
                                    <div id="collapse2" class="panel-collapse collapse">
                                        <div class="panel-body">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="imcr__footer">
                            <p>Created 1 minute ago</p>
                            <p>Updated 1 minute ago</p>
                        </div>
                    </div>
                </div>
                <div class="im__footer">
                    <div class="imf__left">
                    </div>
                    <div class="imf__right">
                        <div class="imfr__section">
                            &nbsp;
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
