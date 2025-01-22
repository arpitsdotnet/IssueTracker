<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropdownControl.ascx.cs" Inherits="IssueTracker.WebUI.UserControls.DropdownControl" %>
<div class="main">
    <div class="dropdown" id="dropdown">
        <div href="#" class="dropdown-toggle" data-toggle="dropdown">
            <span id="options-display">Options</span>
            <b class="caret"></b>
        </div>
        <ul class="dropdown-menu" id="options">
            <li data-value="Android">
                <a href="#"><i class="fa fa-check-square text-info mr-5"></i>Task</a>
            </li>
            <li data-value="Angular">
                <a href="#"><i class="fa fa-bookmark text-success mr-5"></i>Story</a>
            </li>
            <li data-value="Amazon">
                <a href="#"><i class="fa fa-circle mr-5"></i>Epic</a>
            </li>
        </ul>
    </div>
</div>
